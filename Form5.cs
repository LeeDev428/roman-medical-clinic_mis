using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace roman_medical_clinic_mis
{
    public partial class Form5 : Form
    {
        // Database connection string
        private string connectionString = "server=localhost;database=db_roman_clinic;uid=root;pwd=;";

        // User information - we'll store these locally instead of using Properties.Settings
        private string currentUserType = "Admin";
        private string currentUsername = "IAN";
        private string currentFullName = "Ian Phillip C Roman";

        // Timer for automatic midnight queue cleanup
        private System.Windows.Forms.Timer midnightTimer = new System.Windows.Forms.Timer();

        public Form5()
        {
            InitializeComponent();

            // Set up midnight timer to check and clean queue at midnight
            SetupMidnightTimer();
        }

        // Constructor that accepts user information
        public Form5(string userType, string username, string fullName)
        {
            InitializeComponent();

            this.currentUserType = userType;
            this.currentUsername = username;
            this.currentFullName = fullName;

            // Set up midnight timer to check and clean queue at midnight
            SetupMidnightTimer();
        }

        private void SetupMidnightTimer()
        {
            // Calculate time until next midnight (Philippines time)
            DateTime now = DateTime.Now;
            DateTime midnight = now.Date.AddDays(1); // Next midnight
            TimeSpan timeUntilMidnight = midnight - now;

            // Set timer to trigger at midnight
            midnightTimer.Interval = (int)timeUntilMidnight.TotalMilliseconds;
            midnightTimer.Tick += MidnightTimer_Tick;
            midnightTimer.Start();
        }

        private void MidnightTimer_Tick(object sender, EventArgs e)
        {
            // Clean the queue at midnight
            CleanPatientQueue();

            // Reset timer for next midnight
            midnightTimer.Interval = 24 * 60 * 60 * 1000; // 24 hours in milliseconds
        }

        private void CleanPatientQueue()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM daily_patient_queue WHERE date_added < CURDATE()";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Refresh dashboard after cleaning
                    LoadDashboardData();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error cleaning queue: {ex.Message}");
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                // Set login info in footer
                lblLoginInfo.Text = $"Login As: {currentUserType} | Username: {currentUsername} | " +
                    $"Fullname: {currentFullName} | {DateTime.Now:MM/dd/yyyy hh:mm:ss tt} | " +
                    $"Copyright 2023 | All Rights Reserved | Powered by: Ian Philip Roman";

                // Set welcome message
                lblWelcome.Text = $"HI {currentUsername}";

                // Setup data grid for today's patients and queue
                SetupDataGridView();

                // Load dashboard data
                LoadDashboardData();

                // Make sure we clean up any outdated queue records on startup
                CleanPatientQueue();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            // Configure DataGridView columns
            dgvTodayPatients.AutoGenerateColumns = false;
            dgvTodayPatients.Columns.Clear();

            // Add columns for the queue
            dgvTodayPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "queue_number",
                DataPropertyName = "queue_number",
                HeaderText = "QUEUE#",
                Width = 70
            });

            dgvTodayPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "patient_type",
                DataPropertyName = "patient_type",
                HeaderText = "TYPE",
                Width = 70
            });

            dgvTodayPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "patient_name",
                DataPropertyName = "patient_name",
                HeaderText = "PATIENT NAME",
                Width = 200
            });

            dgvTodayPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "age",
                DataPropertyName = "age",
                HeaderText = "AGE",
                Width = 50
            });

            dgvTodayPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "sex",
                DataPropertyName = "sex",
                HeaderText = "SEX",
                Width = 50
            });

            dgvTodayPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "time_added",
                DataPropertyName = "time_added",
                HeaderText = "TIME ADDED",
                Width = 120
            });

            dgvTodayPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "status",
                DataPropertyName = "status",
                HeaderText = "STATUS",
                Width = 100
            });
        }

        private void LoadDashboardData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Load patient counts
                LoadPatientCounts(connection);

                // Load user account statistics
                LoadUserAccountStats(connection);

                // Load today's patient queue (this replaces the old LoadTodayPatients)
                LoadPatientQueue(connection);
            }
        }

        private void LoadPatientCounts(MySqlConnection connection)
        {
            try
            {
                // Get count of pedia patients
                string pediaQuery = "SELECT COUNT(*) FROM pedia_patients";
                using (MySqlCommand command = new MySqlCommand(pediaQuery, connection))
                {
                    int pediaCount = Convert.ToInt32(command.ExecuteScalar());
                    lblPediaCount.Text = pediaCount.ToString("N0"); // Format with thousand separators
                }

                // Get count of adult patients
                string adultQuery = "SELECT COUNT(*) FROM adult_patients";
                using (MySqlCommand command = new MySqlCommand(adultQuery, connection))
                {
                    int adultCount = Convert.ToInt32(command.ExecuteScalar());
                    lblAdultCount.Text = adultCount.ToString("N0"); // Format with thousand separators
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patient counts: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserAccountStats(MySqlConnection connection)
        {
            try
            {
                // Get count of all user accounts
                string totalQuery = "SELECT COUNT(*) FROM users";
                using (MySqlCommand command = new MySqlCommand(totalQuery, connection))
                {
                    int totalCount = Convert.ToInt32(command.ExecuteScalar());
                    lblUserAccountsCount.Text = totalCount.ToString();
                }

                // Check if users table has an account_status column instead of status
                string checkColumnQuery = @"
                    SELECT COLUMN_NAME 
                    FROM INFORMATION_SCHEMA.COLUMNS 
                    WHERE TABLE_SCHEMA = 'db_roman_clinic' 
                    AND TABLE_NAME = 'users' 
                    AND (COLUMN_NAME LIKE '%status%' OR COLUMN_NAME LIKE '%approved%')";

                string statusColumnName = null;
                using (MySqlCommand command = new MySqlCommand(checkColumnQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            statusColumnName = reader.GetString(0);
                        }
                    }
                }

                // If we found a status-related column, use it for filtering
                if (statusColumnName != null)
                {
                    // Get count of approved accounts
                    string approvedQuery = $"SELECT COUNT(*) FROM users WHERE {statusColumnName} = 'Approved'";
                    using (MySqlCommand command = new MySqlCommand(approvedQuery, connection))
                    {
                        int approvedCount = Convert.ToInt32(command.ExecuteScalar());
                        lblApprovedCount.Text = approvedCount.ToString();
                    }

                    // Get count of pending accounts
                    string pendingQuery = $"SELECT COUNT(*) FROM users WHERE {statusColumnName} = 'Pending'";
                    using (MySqlCommand command = new MySqlCommand(pendingQuery, connection))
                    {
                        int pendingCount = Convert.ToInt32(command.ExecuteScalar());
                        lblPendingCount.Text = pendingCount.ToString();
                    }
                }
                else
                {
                    // If we couldn't find a status column, just display 0 or add appropriate fallback logic
                    lblApprovedCount.Text = "0";
                    lblPendingCount.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading account statistics: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPatientQueue(MySqlConnection connection)
        {
            try
            {
                // Load patients from daily queue
                string queueQuery = @"
                    SELECT 
                        queue_number,
                        patient_type,
                        CONCAT(givenname, ' ', IFNULL(middlename, ''), ' ', surname) AS patient_name,
                        age,
                        sex,
                        DATE_FORMAT(added_at, '%h:%i:%s %p') AS time_added,
                        status
                    FROM daily_patient_queue
                    WHERE date_added = CURDATE()
                    ORDER BY queue_number ASC";  // First-come-first-serve order

                using (MySqlCommand command = new MySqlCommand(queueQuery, connection))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable queueTable = new DataTable();
                    adapter.Fill(queueTable);

                    // Update the DataGridView
                    dgvTodayPatients.DataSource = queueTable;

                    // Update the title and count
                    lblTotalToday.Text = $"PEDIA AND ADULT PATIENTS FOR TODAY: {queueTable.Rows.Count}";

                    // If there are no patients in queue, display a message
                    if (queueTable.Rows.Count == 0)
                    {
                        DataTable emptyTable = new DataTable();
                        emptyTable.Columns.Add("Message");
                        emptyTable.Rows.Add("No patients in queue today. Queue is cleared at midnight.");
                        dgvTodayPatients.DataSource = emptyTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patient queue: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region UI Event Handlers
        private void btnPediaMedRecords_Click(object sender, EventArgs e)
        {
            Form2 pediatricForm = new Form2(currentUserType, currentUsername, currentFullName);
            pediatricForm.Show();
            this.Hide();
        }

        private void btnAdultMedRecords_Click(object sender, EventArgs e)
        {
            Form3 adultForm = new Form3(currentUserType, currentUsername, currentFullName);
            adultForm.Show();
            this.Hide();
        }

        private void btnUserAccounts_Click(object sender, EventArgs e)
        {
            // Open Form9 and pass user info for admin check
            Form9 userAccountsForm = new Form9(currentUserType, currentUsername, currentFullName);
            userAccountsForm.Show();
            this.Hide();
        }

        private void btnAboutLicense_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About & License feature is not implemented in this example.",
                "Feature Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Return to login form
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            // Refresh dashboard data when dashboard label is clicked
            Form5 dashboardForm = new Form5(currentUserType, currentUsername, currentFullName);
            dashboardForm.Show();
            this.Hide();
        }

        private void btnRefreshQueue_Click(object sender, EventArgs e)
        {
            // Refresh just the queue
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                LoadPatientQueue(connection);
            }
        }

        private void dgvTodayPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    // Get queue item info
                    string patientType = dgvTodayPatients.Rows[e.RowIndex].Cells["patient_type"].Value.ToString();
                    string status = dgvTodayPatients.Rows[e.RowIndex].Cells["status"].Value.ToString();
                    int queueNumber = Convert.ToInt32(dgvTodayPatients.Rows[e.RowIndex].Cells["queue_number"].Value);

                    // Ask to update status
                    if (status == "waiting")
                    {
                        DialogResult result = MessageBox.Show(
                            "Update patient status to 'in_progress'?",
                            "Update Status",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            UpdateQueueItemStatus(queueNumber, "in_progress");
                        }
                    }
                    else if (status == "in_progress")
                    {
                        DialogResult result = MessageBox.Show(
                            "Update patient status to 'completed'?",
                            "Update Status",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            UpdateQueueItemStatus(queueNumber, "completed");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating queue status: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateQueueItemStatus(int queueNumber, string newStatus)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = @"
                        UPDATE daily_patient_queue 
                        SET status = @Status 
                        WHERE queue_number = @QueueNumber 
                        AND date_added = CURDATE()";

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Status", newStatus);
                        command.Parameters.AddWithValue("@QueueNumber", queueNumber);
                        command.ExecuteNonQuery();
                    }

                    // Refresh the queue display
                    LoadPatientQueue(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating queue status: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void pnlPendingAccounts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPendingCount_Click(object sender, EventArgs e)
        {

        }

        private void lblApprovedCount_Click(object sender, EventArgs e)
        {

        }
    }
}