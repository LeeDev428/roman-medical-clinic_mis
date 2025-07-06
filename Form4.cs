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
    public partial class Form4 : Form
    {
        // Database connection string
        private string connectionString = "server=localhost;database=db_roman_clinic;uid=root;pwd=;";

        // Patient data properties
        private int patientId = 0;
        private string patientFullName = "";
        private DateTime consultationDate;
        private bool isLoadingData = false;
        private bool hasUnsavedChanges = false;

        // User information - we'll store these locally instead of using Properties.Settings
        private string currentUserType = "Admin";
        private string currentUsername = "IAN";
        private string currentFullName = "Ian Phillip C Roman";

        public Form4()
        {
            InitializeComponent();
        }

        // Constructor that accepts patient information
        public Form4(int patientId, string surname, string givenName, string middleName, int age, DateTime consultDate)
        {
            InitializeComponent();

            this.patientId = patientId;
            patientFullName = $"{givenName} {surname}";
            consultationDate = consultDate;

            // Set the patient information on the form
            txtSurname.Text = surname;
            txtGivenName.Text = givenName;
            txtMiddleName.Text = middleName;
            txtAge.Text = age.ToString();
        }

        // Optional: Constructor that also accepts user information
        public Form4(int patientId, string surname, string givenName, string middleName, int age, DateTime consultDate,
            string userType, string username, string fullName) : this(patientId, surname, givenName, middleName, age, consultDate)
        {
            this.currentUserType = userType;
            this.currentUsername = username;
            this.currentFullName = fullName;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                // Set login info in footer - using local variables instead of Properties.Settings
                lblLoginInfo.Text = $"Login As: {currentUserType} | Username: {currentUsername} | " +
                    $"Fullname: {currentFullName} | {DateTime.Now:MM/dd/yyyy hh:mm:ss tt} | " +
                    $"Copyright 2023 | All Rights Reserved | Powered by: Ian Philip Roman";

                // Initialize tabs
                tabConsultation.SelectedIndex = 0;

                // Register event handlers for change tracking
                RegisterChangeEvents();

                // Load existing data if available
                LoadConsultationData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing form: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterChangeEvents()
        {
            // Register TextChanged events for all textboxes to track changes
            txtMedications.TextChanged += new EventHandler(TextBox_TextChanged);
            txtPhysicalExamination.TextChanged += new EventHandler(TextBox_TextChanged);
            txtDiagnosis.TextChanged += new EventHandler(TextBox_TextChanged);
            txtChiefComplaint.TextChanged += new EventHandler(TextBox_TextChanged);
            txtHistory.TextChanged += new EventHandler(TextBox_TextChanged);
            txtPastMedicalHistory.TextChanged += new EventHandler(TextBox_TextChanged);

            // Register CheckedChanged events for all checkboxes
            chkCovidVaccine.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            chkHepatitisA.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            chkHepatitisB.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            chkRotavirus.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            chkDiphtheria.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            chkHaemophilus.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            chkPneumococcal.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            chkPoliovirus.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            chkInfluenza.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            chkMMR.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            chkVaricella.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            chkMeningococcal.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
        }

        private void LoadConsultationData()
        {
            if (patientId <= 0)
            {
                MessageBox.Show("Invalid patient ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            isLoadingData = true;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Load medications data
                    LoadMedicationsData(connection);

                    // Load physical examination data
                    LoadPhysicalExamData(connection);

                    // Load diagnosis data
                    LoadDiagnosisData(connection);

                    // Load complaints (chief complaint) data
                    LoadComplaintsData(connection);

                    // Load history data
                    LoadHistoryData(connection);

                    // Load past medical history data
                    LoadPastMedicalData(connection);

                    // Load vaccinations data
                    LoadVaccinationsData(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading consultation data: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoadingData = false;
                hasUnsavedChanges = false;
            }
        }

        private void LoadMedicationsData(MySqlConnection connection)
        {
            string query = @"
                SELECT info1, info2, info3, info4, info5
                FROM adult_medications 
                WHERE surname = @Surname AND givername = @GivenName AND middlename = @MiddleName
                ORDER BY id DESC LIMIT 1";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Combine all info fields into one text
                        StringBuilder medications = new StringBuilder();
                        for (int i = 1; i <= 5; i++)
                        {
                            string info = reader[$"info{i}"]?.ToString();
                            if (!string.IsNullOrEmpty(info))
                            {
                                medications.AppendLine(info);
                            }
                        }
                        txtMedications.Text = medications.ToString().Trim();
                    }
                }
            }
        }

        private void LoadPhysicalExamData(MySqlConnection connection)
        {
            string query = @"
                SELECT info1, info2, info3, info4, info5
                FROM adult_physical_exam 
                WHERE surname = @Surname AND givername = @GivenName AND middlename = @MiddleName
                ORDER BY id DESC LIMIT 1";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Combine all info fields into one text
                        StringBuilder physicalExam = new StringBuilder();
                        for (int i = 1; i <= 5; i++)
                        {
                            string info = reader[$"info{i}"]?.ToString();
                            if (!string.IsNullOrEmpty(info))
                            {
                                physicalExam.AppendLine(info);
                            }
                        }
                        txtPhysicalExamination.Text = physicalExam.ToString().Trim();
                    }
                }
            }
        }

        private void LoadDiagnosisData(MySqlConnection connection)
        {
            string query = @"
                SELECT info1, info2, info3, info4, info5
                FROM adult_diagnosis 
                WHERE surname = @Surname AND givername = @GivenName AND middlename = @MiddleName
                ORDER BY id DESC LIMIT 1";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Combine all info fields into one text
                        StringBuilder diagnosis = new StringBuilder();
                        for (int i = 1; i <= 5; i++)
                        {
                            string info = reader[$"info{i}"]?.ToString();
                            if (!string.IsNullOrEmpty(info))
                            {
                                diagnosis.AppendLine(info);
                            }
                        }
                        txtDiagnosis.Text = diagnosis.ToString().Trim();
                    }
                }
            }
        }

        private void LoadComplaintsData(MySqlConnection connection)
        {
            string query = @"
                SELECT info1, info2, info3, info4, info5
                FROM adult_complaints 
                WHERE surname = @Surname AND givername = @GivenName AND middlename = @MiddleName
                ORDER BY id DESC LIMIT 1";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Combine all info fields into one text
                        StringBuilder complaints = new StringBuilder();
                        for (int i = 1; i <= 5; i++)
                        {
                            string info = reader[$"info{i}"]?.ToString();
                            if (!string.IsNullOrEmpty(info))
                            {
                                complaints.AppendLine(info);
                            }
                        }
                        txtChiefComplaint.Text = complaints.ToString().Trim();
                    }
                }
            }
        }

        private void LoadHistoryData(MySqlConnection connection)
        {
            string query = @"
                SELECT info1, info2, info3, info4, info5
                FROM adult_history 
                WHERE surname = @Surname AND givername = @GivenName AND middlename = @MiddleName
                ORDER BY id DESC LIMIT 1";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Combine all info fields into one text
                        StringBuilder history = new StringBuilder();
                        for (int i = 1; i <= 5; i++)
                        {
                            string info = reader[$"info{i}"]?.ToString();
                            if (!string.IsNullOrEmpty(info))
                            {
                                history.AppendLine(info);
                            }
                        }
                        txtHistory.Text = history.ToString().Trim();
                    }
                }
            }
        }

        private void LoadPastMedicalData(MySqlConnection connection)
        {
            string query = @"
                SELECT info1
                FROM adult_past_medi 
                WHERE surname = @Surname AND givername = @GivenName AND middlename = @MiddleName
                ORDER BY id DESC LIMIT 1";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtPastMedicalHistory.Text = reader["info1"]?.ToString() ?? string.Empty;
                    }
                }
            }
        }

        private void LoadVaccinationsData(MySqlConnection connection)
        {
            string query = @"
                SELECT covidvaccines, hepatitisB, rotavirus, diphtheria, haemophilus, 
                       pneumococcal, poliovirus, influenza, measles, varicella, hepatitisA, meningococcal
                FROM adult_vaccinations 
                WHERE surname = @Surname AND givenname = @GivenName AND middlename = @MiddleName
                ORDER BY id DESC LIMIT 1";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Set checkboxes based on database values (assuming "1" means checked, "0" means unchecked)
                        chkCovidVaccine.Checked = reader["covidvaccines"]?.ToString() == "1";
                        chkHepatitisB.Checked = reader["hepatitisB"]?.ToString() == "1";
                        chkRotavirus.Checked = reader["rotavirus"]?.ToString() == "1";
                        chkDiphtheria.Checked = reader["diphtheria"]?.ToString() == "1";
                        chkHaemophilus.Checked = reader["haemophilus"]?.ToString() == "1";
                        chkPneumococcal.Checked = reader["pneumococcal"]?.ToString() == "1";
                        chkPoliovirus.Checked = reader["poliovirus"]?.ToString() == "1";
                        chkInfluenza.Checked = reader["influenza"]?.ToString() == "1";
                        chkMMR.Checked = reader["measles"]?.ToString() == "1";
                        chkVaricella.Checked = reader["varicella"]?.ToString() == "1";
                        chkHepatitisA.Checked = reader["hepatitisA"]?.ToString() == "1";
                        chkMeningococcal.Checked = reader["meningococcal"]?.ToString() == "1";
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Save medications data
                    SaveMedicationsData(connection);

                    // Save physical examination data
                    SavePhysicalExamData(connection);

                    // Save diagnosis data
                    SaveDiagnosisData(connection);

                    // Save complaints data
                    SaveComplaintsData(connection);

                    // Save history data
                    SaveHistoryData(connection);

                    // Save past medical data
                    SavePastMedicalData(connection);

                    // Save vaccinations data
                    SaveVaccinationsData(connection);
                }

                hasUnsavedChanges = false;
                MessageBox.Show("Consultation data saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Save Methods

        private void SaveMedicationsData(MySqlConnection connection)
        {
            // Split the medications text into lines and save to info1-info5 fields
            string[] medications = txtMedications.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string query = @"
                INSERT INTO adult_medications (surname, givername, middlename, info1, info2, info3, info4, info5, date1)
                VALUES (@Surname, @GivenName, @MiddleName, @Info1, @Info2, @Info3, @Info4, @Info5, @Date1)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                command.Parameters.AddWithValue("@Date1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                // Add info parameters (up to 5)
                for (int i = 1; i <= 5; i++)
                {
                    string infoValue = (i <= medications.Length) ? medications[i - 1] : "";
                    command.Parameters.AddWithValue($"@Info{i}", infoValue);
                }

                command.ExecuteNonQuery();
            }
        }

        private void SavePhysicalExamData(MySqlConnection connection)
        {
            // Split the physical examination text into lines and save to info1-info5 fields
            string[] physicalExams = txtPhysicalExamination.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string query = @"
                INSERT INTO adult_physical_exam (surname, givername, middlename, info1, info2, info3, info4, info5, date1)
                VALUES (@Surname, @GivenName, @MiddleName, @Info1, @Info2, @Info3, @Info4, @Info5, @Date1)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                command.Parameters.AddWithValue("@Date1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                // Add info parameters (up to 5)
                for (int i = 1; i <= 5; i++)
                {
                    string infoValue = (i <= physicalExams.Length) ? physicalExams[i - 1] : "";
                    command.Parameters.AddWithValue($"@Info{i}", infoValue);
                }

                command.ExecuteNonQuery();
            }
        }

        private void SaveDiagnosisData(MySqlConnection connection)
        {
            // Split the diagnosis text into lines and save to info1-info5 fields
            string[] diagnoses = txtDiagnosis.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string query = @"
                INSERT INTO adult_diagnosis (surname, givername, middlename, info1, info2, info3, info4, info5, date1)
                VALUES (@Surname, @GivenName, @MiddleName, @Info1, @Info2, @Info3, @Info4, @Info5, @Date1)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                command.Parameters.AddWithValue("@Date1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                // Add info parameters (up to 5)
                for (int i = 1; i <= 5; i++)
                {
                    string infoValue = (i <= diagnoses.Length) ? diagnoses[i - 1] : "";
                    command.Parameters.AddWithValue($"@Info{i}", infoValue);
                }

                command.ExecuteNonQuery();
            }
        }

        private void SaveComplaintsData(MySqlConnection connection)
        {
            // Split the complaints text into lines and save to info1-info5 fields
            string[] complaints = txtChiefComplaint.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string query = @"
                INSERT INTO adult_complaints (surname, givername, middlename, info1, info2, info3, info4, info5, date1)
                VALUES (@Surname, @GivenName, @MiddleName, @Info1, @Info2, @Info3, @Info4, @Info5, @Date1)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                command.Parameters.AddWithValue("@Date1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                // Add info parameters (up to 5)
                for (int i = 1; i <= 5; i++)
                {
                    string infoValue = (i <= complaints.Length) ? complaints[i - 1] : "";
                    command.Parameters.AddWithValue($"@Info{i}", infoValue);
                }

                command.ExecuteNonQuery();
            }
        }

        private void SaveHistoryData(MySqlConnection connection)
        {
            // Split the history text into lines and save to info1-info5 fields
            string[] history = txtHistory.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string query = @"
                INSERT INTO adult_history (surname, givername, middlename, info1, info2, info3, info4, info5, date1)
                VALUES (@Surname, @GivenName, @MiddleName, @Info1, @Info2, @Info3, @Info4, @Info5, @Date1)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                command.Parameters.AddWithValue("@Date1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                // Add info parameters (up to 5)
                for (int i = 1; i <= 5; i++)
                {
                    string infoValue = (i <= history.Length) ? history[i - 1] : "";
                    command.Parameters.AddWithValue($"@Info{i}", infoValue);
                }

                command.ExecuteNonQuery();
            }
        }

        private void SavePastMedicalData(MySqlConnection connection)
        {
            string query = @"
                INSERT INTO adult_past_medi (surname, givername, middlename, info1, date1)
                VALUES (@Surname, @GivenName, @MiddleName, @Info1, @Date1)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                command.Parameters.AddWithValue("@Info1", txtPastMedicalHistory.Text.Trim());
                command.Parameters.AddWithValue("@Date1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                command.ExecuteNonQuery();
            }
        }

        private void SaveVaccinationsData(MySqlConnection connection)
        {
            string query = @"
                INSERT INTO adult_vaccinations (surname, givenname, middlename, covidvaccines, hepatitisB, rotavirus, diphtheria, haemophilus, pneumococcal, poliovirus, influenza, measles, varicella, hepatitisA, meningococcal, date1)
                VALUES (@Surname, @GivenName, @MiddleName, @CovidVaccines, @HepatitisB, @Rotavirus, @Diphtheria, @Haemophilus, @Pneumococcal, @Poliovirus, @Influenza, @Measles, @Varicella, @HepatitisA, @Meningococcal, @Date1)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                command.Parameters.AddWithValue("@Date1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                // Add vaccination parameters (using "1" for checked, "0" for unchecked)
                command.Parameters.AddWithValue("@CovidVaccines", chkCovidVaccine.Checked ? "1" : "0");
                command.Parameters.AddWithValue("@HepatitisB", chkHepatitisB.Checked ? "1" : "0");
                command.Parameters.AddWithValue("@Rotavirus", chkRotavirus.Checked ? "1" : "0");
                command.Parameters.AddWithValue("@Diphtheria", chkDiphtheria.Checked ? "1" : "0");
                command.Parameters.AddWithValue("@Haemophilus", chkHaemophilus.Checked ? "1" : "0");
                command.Parameters.AddWithValue("@Pneumococcal", chkPneumococcal.Checked ? "1" : "0");
                command.Parameters.AddWithValue("@Poliovirus", chkPoliovirus.Checked ? "1" : "0");
                command.Parameters.AddWithValue("@Influenza", chkInfluenza.Checked ? "1" : "0");
                command.Parameters.AddWithValue("@Measles", chkMMR.Checked ? "1" : "0");
                command.Parameters.AddWithValue("@Varicella", chkVaricella.Checked ? "1" : "0");
                command.Parameters.AddWithValue("@HepatitisA", chkHepatitisA.Checked ? "1" : "0");
                command.Parameters.AddWithValue("@Meningococcal", chkMeningococcal.Checked ? "1" : "0");

                command.ExecuteNonQuery();
            }
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (hasUnsavedChanges)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes. Are you sure you want to cancel?",
                    "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            // Return to previous form
            this.Close();
        }

        private void btnAdultMedRecords_Click(object sender, EventArgs e)
        {
            // Navigate back to Adult Medical Records
            if (hasUnsavedChanges)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes. Do you want to save before leaving?",
                    "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    btnSave_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            Form3 adultRecordsForm = new Form3();
            adultRecordsForm.Show();
            this.Close();
        }

        private void btnPediaMedRecords_Click(object sender, EventArgs e)
        {
            // Navigate to Pediatric Medical Records
            if (hasUnsavedChanges)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes. Do you want to save before leaving?",
                    "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    btnSave_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            Form2 pediatricForm = new Form2();
            pediatricForm.Show();
            this.Close();
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
            if (hasUnsavedChanges)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes. Do you want to save before logging out?",
                    "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    btnSave_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            // Return to login form
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        // Fixed: Renamed from TextChanged to TextBox_TextChanged to avoid CS0108 warning
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!isLoadingData)
            {
                hasUnsavedChanges = true;
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!isLoadingData)
            {
                hasUnsavedChanges = true;
            }
        }
    }
}