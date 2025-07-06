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
    public partial class Form6 : Form
    {
        // Database connection string
        private string connectionString = "server=localhost;database=db_roman_clinic;uid=root;pwd=;";

        // Patient data properties
        private int patientId = 0;
        private string patientFullName = "";
        private DateTime consultationDate;
        private bool isLoadingData = false;
        private bool hasUnsavedChanges = false;

        // User information - store these locally instead of using Properties.Settings
        private string currentUserType = "Admin";
        private string currentUsername = "IAN";
        private string currentFullName = "Ian Phillip C Roman";

        public Form6()
        {
            InitializeComponent();
        }

        // Constructor that accepts patient information
        public Form6(int patientId, string surname, string givenName, string middleName, int age, DateTime consultDate)
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
        public Form6(int patientId, string surname, string givenName, string middleName, int age, DateTime consultDate,
            string userType, string username, string fullName) : this(patientId, surname, givenName, middleName, age, consultDate)
        {
            this.currentUserType = userType;
            this.currentUsername = username;
            this.currentFullName = fullName;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                // Set login info in footer
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
        }

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

        private void btnAboutLicense_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About & License feature is not implemented in this example.",
                "Feature Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUserAccounts_Click(object sender, EventArgs e)
        {
            MessageBox.Show("User Accounts feature is not implemented in this example.",
                "Feature Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAdultMedRecords_Click(object sender, EventArgs e)
        {
            // Navigate to Adult Medical Records
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

            Form3 adultForm = new Form3();
            adultForm.Show();
            this.Close();
        }

        private void btnPediaMedRecords_Click(object sender, EventArgs e)
        {
            // Navigate back to Pediatric Medical Records
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

        private void lblDashboard_Click(object sender, EventArgs e)
        {
            // Navigate to dashboard
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

                    // Save vaccinations data
                    SaveVaccinationsData(connection);

                    // Save past medical history data
                    SavePastMedicalData(connection);
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

                    // Load vaccinations data
                    LoadVaccinationsData(connection);

                    // Load past medical history data
                    LoadPastMedicalData(connection);
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
                SELECT medi1, medi2, medi3, medi4, medi5, medi6, medi7, medi8, medi9, medi10
                FROM pedia_medications 
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
                        // Combine all medication fields into one text
                        StringBuilder medications = new StringBuilder();
                        for (int i = 1; i <= 10; i++)
                        {
                            string medi = reader[$"medi{i}"]?.ToString();
                            if (!string.IsNullOrEmpty(medi))
                            {
                                medications.AppendLine(medi);
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
                SELECT pexam1, pexam2, pexam3, pexam4, pexam5, pexam6, pexam7, pexam8, pexam9, pexam10
                FROM pedia_physical_exam 
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
                        // Combine all physical exam fields into one text
                        StringBuilder physicalExam = new StringBuilder();
                        for (int i = 1; i <= 10; i++)
                        {
                            string pexam = reader[$"pexam{i}"]?.ToString();
                            if (!string.IsNullOrEmpty(pexam))
                            {
                                physicalExam.AppendLine(pexam);
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
                SELECT diag1, diag2, diag3, diag4, diag5, diag6, diag7, diag8, diag9, diag10
                FROM pedia_diagnosis 
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
                        // Combine all diagnosis fields into one text
                        StringBuilder diagnosis = new StringBuilder();
                        for (int i = 1; i <= 10; i++)
                        {
                            string diag = reader[$"diag{i}"]?.ToString();
                            if (!string.IsNullOrEmpty(diag))
                            {
                                diagnosis.AppendLine(diag);
                            }
                        }
                        txtDiagnosis.Text = diagnosis.ToString().Trim();
                    }
                }
            }
        }

        private void LoadVaccinationsData(MySqlConnection connection)
        {
            string query = @"
                SELECT covidvaccines, hepatitisB, rotavirus, diphtheria, haemophilus, 
                       pneumococcal, poliovirus, influenza, measles, varicella, hepatitisA, meningococcal
                FROM pedia_vaccinations 
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
                        chkHepatitisA.Checked = reader["hepatitisA"]?.ToString() == "1";
                        // Add other checkboxes as needed based on your form controls
                    }
                }
            }
        }

        private void LoadPastMedicalData(MySqlConnection connection)
        {
            string query = @"
                SELECT medi1, medi2, medi3, medi4, medi5, medi6, medi7, medi8, medi9, medi10
                FROM pedia_past_medi 
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
                        // Combine all past medical history fields into one text
                        StringBuilder pastMedical = new StringBuilder();
                        for (int i = 1; i <= 10; i++)
                        {
                            string medi = reader[$"medi{i}"]?.ToString();
                            if (!string.IsNullOrEmpty(medi))
                            {
                                pastMedical.AppendLine(medi);
                            }
                        }
                        txtPastMedicalHistory.Text = pastMedical.ToString().Trim();
                    }
                }
            }
        }

        #region Save Methods

        private void SaveMedicationsData(MySqlConnection connection)
        {
            // Split the medications text into lines and save to medi1-medi10 fields
            string[] medications = txtMedications.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string query = @"
                INSERT INTO pedia_medications (surname, givername, middlename, medi1, medi2, medi3, medi4, medi5, medi6, medi7, medi8, medi9, medi10, date1)
                VALUES (@Surname, @GivenName, @MiddleName, @Medi1, @Medi2, @Medi3, @Medi4, @Medi5, @Medi6, @Medi7, @Medi8, @Medi9, @Medi10, @Date1)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                command.Parameters.AddWithValue("@Date1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                // Add medication parameters (up to 10)
                for (int i = 1; i <= 10; i++)
                {
                    string mediValue = (i <= medications.Length) ? medications[i - 1] : "";
                    command.Parameters.AddWithValue($"@Medi{i}", mediValue);
                }

                command.ExecuteNonQuery();
            }
        }

        private void SavePhysicalExamData(MySqlConnection connection)
        {
            // Split the physical examination text into lines and save to pexam1-pexam10 fields
            string[] physicalExams = txtPhysicalExamination.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string query = @"
                INSERT INTO pedia_physical_exam (surname, givername, middlename, pexam1, pexam2, pexam3, pexam4, pexam5, pexam6, pexam7, pexam8, pexam9, pexam10, date1)
                VALUES (@Surname, @GivenName, @MiddleName, @Pexam1, @Pexam2, @Pexam3, @Pexam4, @Pexam5, @Pexam6, @Pexam7, @Pexam8, @Pexam9, @Pexam10, @Date1)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                command.Parameters.AddWithValue("@Date1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                // Add physical exam parameters (up to 10)
                for (int i = 1; i <= 10; i++)
                {
                    string pexamValue = (i <= physicalExams.Length) ? physicalExams[i - 1] : "";
                    command.Parameters.AddWithValue($"@Pexam{i}", pexamValue);
                }

                command.ExecuteNonQuery();
            }
        }

        private void SaveDiagnosisData(MySqlConnection connection)
        {
            // Split the diagnosis text into lines and save to diag1-diag10 fields
            string[] diagnoses = txtDiagnosis.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string query = @"
                INSERT INTO pedia_diagnosis (surname, givername, middlename, diag1, diag2, diag3, diag4, diag5, diag6, diag7, diag8, diag9, diag10, date1)
                VALUES (@Surname, @GivenName, @MiddleName, @Diag1, @Diag2, @Diag3, @Diag4, @Diag5, @Diag6, @Diag7, @Diag8, @Diag9, @Diag10, @Date1)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                command.Parameters.AddWithValue("@Date1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                // Add diagnosis parameters (up to 10)
                for (int i = 1; i <= 10; i++)
                {
                    string diagValue = (i <= diagnoses.Length) ? diagnoses[i - 1] : "";
                    command.Parameters.AddWithValue($"@Diag{i}", diagValue);
                }

                command.ExecuteNonQuery();
            }
        }

        private void SaveVaccinationsData(MySqlConnection connection)
        {
            string query = @"
                INSERT INTO pedia_vaccinations (surname, givenname, middlename, covidvaccines, hepatitisB, rotavirus, diphtheria, haemophilus, pneumococcal, poliovirus, influenza, measles, varicella, hepatitisA, meningococcal, date1)
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
                command.Parameters.AddWithValue("@HepatitisA", chkHepatitisA.Checked ? "1" : "0");

                // Add default values for other vaccinations if checkboxes don't exist
                command.Parameters.AddWithValue("@Haemophilus", "0");
                command.Parameters.AddWithValue("@Pneumococcal", "0");
                command.Parameters.AddWithValue("@Poliovirus", "0");
                command.Parameters.AddWithValue("@Influenza", "0");
                command.Parameters.AddWithValue("@Measles", "0");
                command.Parameters.AddWithValue("@Varicella", "0");
                command.Parameters.AddWithValue("@Meningococcal", "0");

                command.ExecuteNonQuery();
            }
        }

        private void SavePastMedicalData(MySqlConnection connection)
        {
            // Split the past medical history text into lines and save to medi1-medi10 fields
            string[] pastMedical = txtPastMedicalHistory.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            string query = @"
                INSERT INTO pedia_past_medi (surname, givername, middlename, medi1, medi2, medi3, medi4, medi5, medi6, medi7, medi8, medi9, medi10, date1)
                VALUES (@Surname, @GivenName, @MiddleName, @Medi1, @Medi2, @Medi3, @Medi4, @Medi5, @Medi6, @Medi7, @Medi8, @Medi9, @Medi10, @Date1)";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Surname", txtSurname.Text);
                command.Parameters.AddWithValue("@GivenName", txtGivenName.Text);
                command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                command.Parameters.AddWithValue("@Date1", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                // Add past medical parameters (up to 10)
                for (int i = 1; i <= 10; i++)
                {
                    string mediValue = (i <= pastMedical.Length) ? pastMedical[i - 1] : "";
                    command.Parameters.AddWithValue($"@Medi{i}", mediValue);
                }

                command.ExecuteNonQuery();
            }
        }

        #endregion
    }
}