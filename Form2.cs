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
    public partial class Form2 : Form
    {
        // Database connection string
        private string connectionString = "server=localhost;database=db_roman_clinic;uid=root;pwd=;";
        private int selectedPatientId = 0;
        private bool isEditMode = false;

        public Form2()
        {
            InitializeComponent();

            // Initialize UI components
            cmbSex.SelectedIndex = 0; // Default to SELECT
            SetupDataGridView();
            ClearFields();

            // Set default dates - keep only birthdate and consultation date for new patients
            dtpBirthdate.Value = DateTime.Today;
            dtpConsultDate.Value = DateTime.Today;

            // Make search date pickers blank/unchecked initially
            dtpSearchConsult.ShowCheckBox = true;
            dtpSearchConsult.Checked = false;

            // Set from/to dates to extreme ranges but don't use them in filtering
            dtpFromDate.Value = DateTime.Today.AddYears(-50); // Very old date
            dtpToDate.Value = DateTime.Today.AddYears(1);     // Future date
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Load patient data
            LoadPatients();
            CalculateAge();

            // Clean old queue records on form load (in case app wasn't running at midnight)
            CleanOldQueueRecords();
        }

        #region Queue Management
        private void CleanOldQueueRecords()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Delete records that are not from today (Philippine time)
                    string query = "DELETE FROM daily_patient_queue WHERE date_added < CURDATE()";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error but don't show to user on form load
                System.Diagnostics.Debug.WriteLine($"Error cleaning old queue records: {ex.Message}");
            }
        }

        private int GetNextQueueNumber()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT COALESCE(MAX(queue_number), 0) + 1 as next_number 
                        FROM daily_patient_queue 
                        WHERE date_added = CURDATE()";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception)
            {
                return 1; // Default to 1 if error
            }
        }

        private bool AddPatientToQueue(int patientId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // First check if patient is already in today's queue
                    string checkQuery = @"
                        SELECT COUNT(*) 
                        FROM daily_patient_queue 
                        WHERE patient_id = @PatientId 
                        AND patient_type = 'pedia' 
                        AND date_added = CURDATE()
                        AND status != 'completed'";

                    using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@PatientId", patientId);
                        int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (existingCount > 0)
                        {
                            MessageBox.Show("This patient is already in today's queue!", "Already in Queue",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }

                    // Get patient details
                    string patientQuery = @"
                        SELECT surname, givenname, middlename, age, sex 
                        FROM pedia_patients 
                        WHERE id = @PatientId";

                    using (MySqlCommand patientCommand = new MySqlCommand(patientQuery, connection))
                    {
                        patientCommand.Parameters.AddWithValue("@PatientId", patientId);

                        using (MySqlDataReader reader = patientCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string surname = reader["surname"].ToString();
                                string givenname = reader["givenname"].ToString();
                                string middlename = reader["middlename"].ToString();
                                int age = Convert.ToInt32(reader["age"]);
                                string sex = reader["sex"].ToString();

                                reader.Close();

                                // Add to queue
                                int queueNumber = GetNextQueueNumber();

                                string insertQuery = @"
                                    INSERT INTO daily_patient_queue 
                                    (patient_id, patient_type, surname, givenname, middlename, age, sex, queue_number, added_at, date_added, status) 
                                    VALUES 
                                    (@PatientId, 'pedia', @Surname, @GivenName, @MiddleName, @Age, @Sex, @QueueNumber, NOW(), CURDATE(), 'waiting')";

                                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@PatientId", patientId);
                                    insertCommand.Parameters.AddWithValue("@Surname", surname);
                                    insertCommand.Parameters.AddWithValue("@GivenName", givenname);
                                    insertCommand.Parameters.AddWithValue("@MiddleName", middlename);
                                    insertCommand.Parameters.AddWithValue("@Age", age);
                                    insertCommand.Parameters.AddWithValue("@Sex", sex);
                                    insertCommand.Parameters.AddWithValue("@QueueNumber", queueNumber);

                                    insertCommand.ExecuteNonQuery();

                                    MessageBox.Show($"Patient {givenname} {surname} added to today's queue!\nQueue Number: {queueNumber}",
                                        "Added to Queue", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding patient to queue: {ex.Message}", "Queue Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return false;
        }
        #endregion

        #region Age Calculation
        private void CalculateAge()
        {
            DateTime birthdate = dtpBirthdate.Value;
            DateTime today = DateTime.Today;

            int age = today.Year - birthdate.Year;

            // Adjust age if the birthday hasn't occurred yet this year
            if (birthdate.Date > today.AddYears(-age))
            {
                age--;
            }

            txtAge.Text = age.ToString();
        }

        private void dtpBirthdate_ValueChanged(object sender, EventArgs e)
        {
            CalculateAge();
        }
        #endregion

        #region UI Event Handlers
        private void btnPediaMedRecords_Click(object sender, EventArgs e)
        {
            // Already on this form, refresh data
            LoadPatients();
        }

        private void btnAdultMedRecords_Click(object sender, EventArgs e)
        {
            // Navigate to adult medical records form
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
            // Create and show the About & License form
            Form8 aboutForm = new Form8();
            aboutForm.ShowDialog(); // Use ShowDialog to make it modal
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Show login form when closing
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if (isEditMode && selectedPatientId > 0)
                {
                    UpdatePatient();
                }
                else
                {
                    SaveNewPatient();
                }

                LoadPatients();
                ClearFields();
                isEditMode = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedPatientId > 0)
            {
                isEditMode = true;
                // UI is already populated from selection in the grid
                MessageBox.Show("You can now edit the patient information. Click Save when done.",
                    "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a patient record to edit first.",
                    "No Patient Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Tag != null && btnCancel.Tag is int originalId)
            {
                // Restore the original patient after canceling reconsultation
                selectedPatientId = originalId;
                LoadPatientDetails(selectedPatientId);
                btnCancel.Tag = null;
            }
            else
            {
                // Regular cancel operation
                ClearFields();
                selectedPatientId = 0;
                isEditMode = false;
            }
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedPatientId = Convert.ToInt32(dgvPatients.Rows[e.RowIndex].Cells["id"].Value);
                LoadPatientDetails(selectedPatientId);
                // Remove the immediate navigation to Form6 to allow editing in this form first
            }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            FilterPatients();
        }

        private void dtpSearchConsult_ValueChanged(object sender, EventArgs e)
        {
            FilterPatients();
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            FilterPatients();
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            FilterPatients();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*",
                    Title = "Select File to Import"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Basic implementation - this would need to be expanded based on file format
                    MessageBox.Show($"Import functionality would be implemented for: {openFileDialog.FileName}",
                        "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Placeholder for actual import logic
                    // ImportPatientsFromFile(openFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during import: {ex.Message}", "Import Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*",
                    Title = "Export Patients",
                    FileName = $"PediaPatients_{DateTime.Now:yyyyMMdd}"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Basic implementation - would need to be expanded based on chosen format
                    MessageBox.Show($"Export functionality would be implemented to: {saveFileDialog.FileName}",
                        "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Placeholder for actual export logic
                    // ExportPatientsToFile(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during export: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedPatientId > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this patient record?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeletePatient(selectedPatientId);
                    LoadPatients();
                    ClearFields();
                }
            }
            else
            {
                MessageBox.Show("Please select a patient record to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            selectedPatientId = 0;
            isEditMode = false;
            txtSurname.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (selectedPatientId > 0)
            {
                MessageBox.Show("Print functionality would generate a printable report of the selected patient record.",
                    "Print", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Placeholder for actual print functionality
                // PrintPatientRecord(selectedPatientId);
            }
            else
            {
                MessageBox.Show("Please select a patient record to print.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedPatientId > 0)
            {
                if (ValidateInput())
                {
                    try
                    {
                        // Instead of updating the patient first, directly navigate to Form6
                        // Retrieve the patient's details
                        using (MySqlConnection connection = new MySqlConnection(connectionString))
                        {
                            connection.Open();

                            string query = @"
                                SELECT 
                                    surname,
                                    givenname,
                                    middlename,
                                    age,
                                    consultation
                                FROM pedia_patients
                                WHERE id = @PatientId";

                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@PatientId", selectedPatientId);

                                using (MySqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        string surname = reader["surname"].ToString();
                                        string givenName = reader["givenname"].ToString();
                                        string middleName = reader["middlename"].ToString();
                                        int age = Convert.ToInt32(reader["age"]);
                                        DateTime consultDate = Convert.ToDateTime(reader["consultation"]);

                                        // Navigate to Form6 with the selected patient information
                                        Form6 consultationForm = new Form6(
                                            selectedPatientId,
                                            surname,
                                            givenName,
                                            middleName,
                                            age,
                                            consultDate);

                                        consultationForm.Show();
                                        this.Hide();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a patient record to update first.",
                    "No Patient Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReconsultation_Click(object sender, EventArgs e)
        {
            if (selectedPatientId > 0)
            {
                // Add patient to today's queue
                if (AddPatientToQueue(selectedPatientId))
                {
                    // Navigate to dashboard to show the queue
                    Form5 dashboardForm = new Form5();
                    dashboardForm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please select a patient record first.",
                    "No Patient Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrescriptions_Click(object sender, EventArgs e)
        {
            if (selectedPatientId > 0)
            {
                try
                {
                    // Retrieve patient information needed for prescription
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = @"
                    SELECT 
                        surname,
                        givenname,
                        middlename,
                        address,
                        sex,
                        age,
                        birthdate
                    FROM pedia_patients
                    WHERE id = @PatientId";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@PatientId", selectedPatientId);

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string fullName = $"{reader["givenname"]} {reader["middlename"]} {reader["surname"]}";
                                    string address = reader["address"].ToString();
                                    string sexAge = $"{reader["sex"]}/{reader["age"]}";

                                    // Navigate to Form7 with patient details
                                    Form7 prescriptionForm = new Form7(
                                        selectedPatientId,
                                        fullName,
                                        address,
                                        sexAge,
                                        DateTime.Today
                                    );

                                    prescriptionForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Could not retrieve patient information.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error preparing prescription: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a patient record first.",
                    "No Patient Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            // Navigate to dashboard
            Form5 dashboardForm = new Form5();
            dashboardForm.Show();
            this.Hide();
        }

        private void lblDashboard_MouseEnter(object sender, EventArgs e)
        {
            // Change appearance when mouse hovers over the dashboard text
            lblDashboard.ForeColor = System.Drawing.Color.Yellow; // Highlight color
            lblDashboard.Font = new Font(lblDashboard.Font, FontStyle.Bold | FontStyle.Underline);
        }

        private void lblDashboard_MouseLeave(object sender, EventArgs e)
        {
            // Restore original appearance when mouse leaves
            lblDashboard.ForeColor = System.Drawing.Color.White;
            lblDashboard.Font = new Font(lblDashboard.Font.FontFamily, lblDashboard.Font.Size, FontStyle.Bold);
        }
        #endregion

        #region Database Operations
        private void SetupDataGridView()
        {
            // Configure DataGridView columns
            dgvPatients.AutoGenerateColumns = false;
            dgvPatients.Columns.Clear();

            // Add columns
            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "id",
                DataPropertyName = "id",
                HeaderText = "ID",
                Visible = false
            });

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "surname",
                DataPropertyName = "surname",
                HeaderText = "Surname",
                Width = 120
            });

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "givenname",
                DataPropertyName = "givenname",
                HeaderText = "Given Name",
                Width = 120
            });

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "middlename",
                DataPropertyName = "middlename",
                HeaderText = "Middle Name",
                Width = 120
            });

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "address",
                DataPropertyName = "address",
                HeaderText = "Address",
                Width = 200
            });

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "sex",
                DataPropertyName = "sex",
                HeaderText = "Sex",
                Width = 60
            });

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "birthdate",
                DataPropertyName = "birthdate",
                HeaderText = "Birthdate",
                Width = 100
            });

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "age",
                DataPropertyName = "age",
                HeaderText = "Age",
                Width = 50
            });

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "consultation",
                DataPropertyName = "consultation",
                HeaderText = "Consultation Date",
                Width = 120
            });
        }

        private void LoadPatients()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            id,
                            surname,
                            givenname,
                            middlename,
                            address,
                            sex,
                            birthdate,
                            age,
                            consultation
                        FROM pedia_patients
                        ORDER BY consultation DESC, surname ASC";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvPatients.DataSource = dataTable;

                    // Update patient count
                    lblTotalPatients.Text = $"Total No. of Pedia Patients: {dataTable.Rows.Count}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patients: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterPatients()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    StringBuilder queryBuilder = new StringBuilder();
                    queryBuilder.Append(@"
                        SELECT 
                            id,
                            surname,
                            givenname,
                            middlename,
                            address,
                            sex,
                            birthdate,
                            age,
                            consultation
                        FROM pedia_patients
                        WHERE 1=1");

                    List<MySqlParameter> parameters = new List<MySqlParameter>();

                    // 1. Name search - works independently of date filters
                    if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                    {
                        string searchTerm = $"%{txtSearchName.Text.Trim()}%";
                        queryBuilder.Append(" AND (surname LIKE @SearchTerm OR givenname LIKE @SearchTerm OR middlename LIKE @SearchTerm)");
                        parameters.Add(new MySqlParameter("@SearchTerm", searchTerm));
                    }

                    // 2. Only apply date filters if specifically checked/selected by user
                    if (dtpSearchConsult.Checked)
                    {
                        queryBuilder.Append(" AND consultation = @ConsultDate");
                        parameters.Add(new MySqlParameter("@ConsultDate", dtpSearchConsult.Value.ToString("yyyy-MM-dd")));
                    }

                    // 3. Date range filtering - only if user has actually modified the range significantly
                    DateTime veryOldDate = DateTime.Today.AddYears(-50);
                    DateTime futureDate = DateTime.Today.AddYears(1);

                    bool hasCustomDateRange = dtpFromDate.Value.Date != veryOldDate.Date ||
                                            dtpToDate.Value.Date != futureDate.Date;

                    if (hasCustomDateRange && !dtpSearchConsult.Checked)
                    {
                        queryBuilder.Append(" AND consultation BETWEEN @FromDate AND @ToDate");
                        parameters.Add(new MySqlParameter("@FromDate", dtpFromDate.Value.ToString("yyyy-MM-dd")));
                        parameters.Add(new MySqlParameter("@ToDate", dtpToDate.Value.ToString("yyyy-MM-dd")));
                    }

                    queryBuilder.Append(" ORDER BY consultation DESC, surname ASC");

                    using (MySqlCommand command = new MySqlCommand(queryBuilder.ToString(), connection))
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(param);
                        }

                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvPatients.DataSource = dataTable;
                        lblTotalPatients.Text = $"Total No. of Pedia Patients: {dataTable.Rows.Count}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering patients: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPatientDetails(int patientId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            id,
                            surname,
                            givenname,
                            middlename,
                            address,
                            sex,
                            birthdate,
                            consultation
                        FROM pedia_patients
                        WHERE id = @PatientId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientId", patientId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate form fields
                                txtSurname.Text = reader["surname"].ToString();
                                txtGivenName.Text = reader["givenname"].ToString();
                                txtMiddleName.Text = reader["middlename"].ToString();
                                txtAddress.Text = reader["address"].ToString();
                                cmbSex.Text = reader["sex"].ToString();

                                // Handle birthdate as string
                                if (DateTime.TryParse(reader["birthdate"].ToString(), out DateTime birthdate))
                                {
                                    dtpBirthdate.Value = birthdate;
                                }

                                // Handle consultation as string
                                if (DateTime.TryParse(reader["consultation"].ToString(), out DateTime consultation))
                                {
                                    dtpConsultDate.Value = consultation;
                                }

                                // Calculate age based on birthdate
                                CalculateAge();
                            }
                            else
                            {
                                MessageBox.Show("Patient record not found.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patient details: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                MessageBox.Show("Please enter the surname.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSurname.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGivenName.Text))
            {
                MessageBox.Show("Please enter the given name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGivenName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter the address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }

            if (cmbSex.SelectedIndex == 0) // "SELECT" option
            {
                MessageBox.Show("Please select the sex.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSex.Focus();
                return false;
            }

            if (dtpBirthdate.Value > DateTime.Today)
            {
                MessageBox.Show("Birthdate cannot be in the future.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpBirthdate.Focus();
                return false;
            }

            // Pediatric-specific validation: Check if patient is 18 years and 364 days or younger
            DateTime birthdate = dtpBirthdate.Value;
            DateTime today = DateTime.Today;

            // Calculate age in years
            int ageInYears = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-ageInYears))
                ageInYears--;

            // If patient is 19 or older, they cannot be in pediatric records
            if (ageInYears >= 19)
            {
                MessageBox.Show(
                    "This patient cannot be registered in Pediatric Records.\n\n" +
                    "Pediatrics is for patients up to 18 years and 364 days old.\n" +
                    "Adult Records are for patients 19 years old and above.\n\n" +
                    "Please use the Adult Medical Records form instead.",
                    "Age Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpBirthdate.Focus();
                return false;
            }

            // Additional check: if patient is exactly 18 years old, check if they've reached 365 days (19th birthday)
            if (ageInYears == 18)
            {
                DateTime eighteenthBirthday = birthdate.AddYears(18);
                DateTime nineteenthBirthday = birthdate.AddYears(19);

                // If today is the 19th birthday or after, they're too old for pediatrics
                if (today >= nineteenthBirthday)
                {
                    MessageBox.Show(
                        "This patient cannot be registered in Pediatric Records.\n\n" +
                        "Pediatrics is for patients up to 18 years and 364 days old.\n" +
                        "This patient is now 19 years old or older.\n\n" +
                        "Please use the Adult Medical Records form instead.",
                        "Age Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpBirthdate.Focus();
                    return false;
                }
            }

            return true;
        }

        private void SaveNewPatient()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO pedia_patients (
                            surname,
                            givenname,
                            middlename,
                            address,
                            sex,
                            birthdate,
                            age,
                            consultation,
                            dateadded,
                            idtime
                        ) VALUES (
                            @Surname,
                            @GivenName,
                            @MiddleName,
                            @Address,
                            @Sex,
                            @Birthdate,
                            @Age,
                            @Consultation,
                            @DateAdded,
                            @IdTime
                        )";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim());
                        command.Parameters.AddWithValue("@GivenName", txtGivenName.Text.Trim());
                        command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text.Trim());
                        command.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        command.Parameters.AddWithValue("@Sex", cmbSex.Text);
                        command.Parameters.AddWithValue("@Birthdate", dtpBirthdate.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
                        command.Parameters.AddWithValue("@Consultation", dtpConsultDate.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@DateAdded", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@IdTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        command.ExecuteNonQuery();

                        MessageBox.Show("Patient record saved successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving patient: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePatient()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                        UPDATE pedia_patients SET
                            surname = @Surname,
                            givenname = @GivenName,
                            middlename = @MiddleName,
                            address = @Address,
                            sex = @Sex,
                            birthdate = @Birthdate,
                            age = @Age,
                            consultation = @Consultation,
                            dateupdated = @DateUpdated
                        WHERE id = @PatientId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientId", selectedPatientId);
                        command.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim());
                        command.Parameters.AddWithValue("@GivenName", txtGivenName.Text.Trim());
                        command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text.Trim());
                        command.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        command.Parameters.AddWithValue("@Sex", cmbSex.Text);
                        command.Parameters.AddWithValue("@Birthdate", dtpBirthdate.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@Age", int.Parse(txtAge.Text));
                        command.Parameters.AddWithValue("@Consultation", dtpConsultDate.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@DateUpdated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        command.ExecuteNonQuery();

                        MessageBox.Show("Patient record updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating patient: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeletePatient(int patientId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM pedia_patients WHERE id = @PatientId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientId", patientId);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Patient record deleted successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting patient: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtSurname.Clear();
            txtGivenName.Clear();
            txtMiddleName.Clear();
            txtAddress.Clear();
            cmbSex.SelectedIndex = 0; // Reset to "SELECT"
            dtpBirthdate.Value = DateTime.Today;
            dtpConsultDate.Value = DateTime.Today;
            txtAge.Text = "0";
            selectedPatientId = 0;
        }
        #endregion
    }
}