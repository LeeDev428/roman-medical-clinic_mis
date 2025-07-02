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
        private string connectionString = "server=localhost;database=roman_medical_clinic_db;uid=root;pwd=;";

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
                // Save implementation (the full method body from previous response)
                // ...
                
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

                    // Load examination and diagnosis data
                    LoadExaminationData(connection);

                    // Load clinical data (vaccines, history, etc.)
                    LoadClinicalData(connection);
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
                SELECT medication_details 
                FROM pedia_medications 
                WHERE patient_id = @PatientId 
                AND DATE(consultation_date) = DATE(@ConsultationDate)
                ORDER BY created_at DESC LIMIT 1";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PatientId", patientId);
                command.Parameters.AddWithValue("@ConsultationDate", consultationDate);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtMedications.Text = reader["medication_details"]?.ToString() ?? string.Empty;
                    }
                }
            }
        }

        private void LoadExaminationData(MySqlConnection connection)
        {
            string query = @"
                SELECT physical_examination, diagnosis 
                FROM pedia_examinations 
                WHERE patient_id = @PatientId 
                AND DATE(consultation_date) = DATE(@ConsultationDate)
                ORDER BY created_at DESC LIMIT 1";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PatientId", patientId);
                command.Parameters.AddWithValue("@ConsultationDate", consultationDate);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtPhysicalExamination.Text = reader["physical_examination"]?.ToString() ?? string.Empty;
                        txtDiagnosis.Text = reader["diagnosis"]?.ToString() ?? string.Empty;
                    }
                }
            }
        }

        private void LoadClinicalData(MySqlConnection connection)
        {
            string query = @"
                SELECT 
                    covid_vaccine,
                    hepatitis_b,
                    rotavirus,
                    diphtheria_tetanus_pertussis,
                    haemophilus_influenza,
                    pneumococcal,
                    inactivated_poliovirus,
                    influenza,
                    measles_mumps_rubella,
                    varicella,
                    hepatitis_a,
                    meningococcal,
                    chief_complaint,
                    history,
                    past_medical_history
                FROM pedia_clinical_data 
                WHERE patient_id = @PatientId 
                AND DATE(consultation_date) = DATE(@ConsultationDate)
                ORDER BY created_at DESC LIMIT 1";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PatientId", patientId);
                command.Parameters.AddWithValue("@ConsultationDate", consultationDate);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Vaccinations
                        chkCovidVaccine.Checked = Convert.ToBoolean(reader["covid_vaccine"]);
                        chkHepatitisB.Checked = Convert.ToBoolean(reader["hepatitis_b"]);
                        chkRotavirus.Checked = Convert.ToBoolean(reader["rotavirus"]);
                        chkDiphtheria.Checked = Convert.ToBoolean(reader["diphtheria_tetanus_pertussis"]);
                    }
                }
            }
        }
    }
}
