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
        private string connectionString = "server=localhost;database=roman_medical_clinic_db;uid=root;pwd=;";

        // User information - we'll store these locally instead of using Properties.Settings
        private string currentUserType = "Admin";
        private string currentUsername = "IAN";
        private string currentFullName = "Ian Phillip C Roman";

        public Form5()
        {
            InitializeComponent();
        }

        // Constructor that accepts user information
        public Form5(string userType, string username, string fullName)
        {
            InitializeComponent();

            this.currentUserType = userType;
            this.currentUsername = username;
            this.currentFullName = fullName;
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

                // Setup data grid for today's patients
                SetupDataGridView();

                // Load dashboard data
                LoadDashboardData();
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

            // Add columns
            dgvTodayPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                DataPropertyName = "id",
                HeaderText = "ID#",
                Width = 70
            });

            dgvTodayPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "date",
                DataPropertyName = "date",
                HeaderText = "DATE",
                Width = 120
            });

            dgvTodayPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "type",
                DataPropertyName = "type",
                HeaderText = "TYPE",
                Width = 80
            });

            dgvTodayPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "patient",
                DataPropertyName = "patient",
                HeaderText = "PATIENT",
                Width = 240
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

                // Load today's patients
                LoadTodayPatients(connection);
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
                    WHERE TABLE_SCHEMA = 'roman_medical_clinic_db' 
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

        private void LoadTodayPatients(MySqlConnection connection)
        {
            try
            {
                DataTable combinedResults = new DataTable();
                combinedResults.Columns.Add("id", typeof(int));
                combinedResults.Columns.Add("date", typeof(DateTime));
                combinedResults.Columns.Add("type", typeof(string));
                combinedResults.Columns.Add("patient", typeof(string));

                // Get pedia patients for today
                string pediaQuery = @"
                    SELECT 
                        patient_id AS id,
                        consultation_date AS date,
                        'PEDIA' AS type,
                        CONCAT(given_name, ' ', surname) AS patient
                    FROM pedia_patients
                    WHERE DATE(consultation_date) = CURDATE()
                    ORDER BY consultation_date";

                using (MySqlCommand command = new MySqlCommand(pediaQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            combinedResults.Rows.Add(
                                reader["id"],
                                reader["date"],
                                reader["type"],
                                reader["patient"]
                            );
                        }
                    }
                }

                // Get adult patients for today
                string adultQuery = @"
                    SELECT 
                        patient_id AS id,
                        consultation_date AS date,
                        'ADULT' AS type,
                        CONCAT(given_name, ' ', surname) AS patient
                    FROM adult_patients
                    WHERE DATE(consultation_date) = CURDATE()
                    ORDER BY consultation_date";

                using (MySqlCommand command = new MySqlCommand(adultQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            combinedResults.Rows.Add(
                                reader["id"],
                                reader["date"],
                                reader["type"],
                                reader["patient"]
                            );
                        }
                    }
                }

                // Set the DataGridView data source
                dgvTodayPatients.DataSource = combinedResults;

                // Update total count
                lblTotalToday.Text = $"Total No. of PATIENTS TODAY: {combinedResults.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading today's patients: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region UI Event Handlers
        private void btnPediaMedRecords_Click(object sender, EventArgs e)
        {
            Form2 pediatricForm = new Form2();
            pediatricForm.Show();
            this.Hide();
        }

        private void btnAdultMedRecords_Click(object sender, EventArgs e)
        {
            Form3 adultRecordsForm = new Form3();
            adultRecordsForm.Show();
            this.Hide();
        }

        private void btnUserAccounts_Click(object sender, EventArgs e)
        {
            MessageBox.Show("User Accounts feature is not implemented in this example.",
                "Feature Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            LoadDashboardData();
        }
        #endregion
    }
}
