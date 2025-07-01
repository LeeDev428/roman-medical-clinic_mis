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
        private string connectionString = "server=localhost;database=roman_medical_clinic_db;uid=root;pwd=;";

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
                FROM adult_medications 
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
                FROM adult_examinations 
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
                FROM adult_clinical_data 
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
                        chkHaemophilus.Checked = Convert.ToBoolean(reader["haemophilus_influenza"]);
                        chkPneumococcal.Checked = Convert.ToBoolean(reader["pneumococcal"]);
                        chkPoliovirus.Checked = Convert.ToBoolean(reader["inactivated_poliovirus"]);
                        chkInfluenza.Checked = Convert.ToBoolean(reader["influenza"]);
                        chkMMR.Checked = Convert.ToBoolean(reader["measles_mumps_rubella"]);
                        chkVaricella.Checked = Convert.ToBoolean(reader["varicella"]);
                        chkHepatitisA.Checked = Convert.ToBoolean(reader["hepatitis_a"]);
                        chkMeningococcal.Checked = Convert.ToBoolean(reader["meningococcal"]);

                        // History data
                        txtChiefComplaint.Text = reader["chief_complaint"]?.ToString() ?? string.Empty;
                        txtHistory.Text = reader["history"]?.ToString() ?? string.Empty;
                        txtPastMedicalHistory.Text = reader["past_medical_history"]?.ToString() ?? string.Empty;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Save all data to respective tables
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Begin a transaction for data consistency
                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Save medications data
                            SaveMedicationsData(connection, transaction);

                            // Save examination and diagnosis data
                            SaveExaminationData(connection, transaction);

                            // Save clinical data
                            SaveClinicalData(connection, transaction);

                            // Commit transaction if all operations successful
                            transaction.Commit();

                            MessageBox.Show("Consultation data saved successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            hasUnsavedChanges = false;
                        }
                        catch (Exception ex)
                        {
                            // Roll back transaction on error
                            transaction.Rollback();
                            throw new Exception($"Transaction failed: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveMedicationsData(MySqlConnection connection, MySqlTransaction transaction)
        {
            // First check if a record already exists
            string checkQuery = @"
                SELECT medication_id 
                FROM adult_medications 
                WHERE patient_id = @PatientId 
                AND DATE(consultation_date) = DATE(@ConsultationDate)
                LIMIT 1";

            bool recordExists = false;
            int medicationId = 0;

            using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection, transaction))
            {
                checkCommand.Parameters.AddWithValue("@PatientId", patientId);
                checkCommand.Parameters.AddWithValue("@ConsultationDate", consultationDate);

                using (MySqlDataReader reader = checkCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        recordExists = true;
                        medicationId = reader.GetInt32("medication_id");
                    }
                }
            }

            if (recordExists)
            {
                // Update existing record
                string updateQuery = @"
                    UPDATE adult_medications 
                    SET medication_details = @MedicationDetails,
                        updated_at = @UpdatedAt
                    WHERE medication_id = @MedicationId";

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection, transaction))
                {
                    command.Parameters.AddWithValue("@MedicationId", medicationId);
                    command.Parameters.AddWithValue("@MedicationDetails", txtMedications.Text.Trim());
                    command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
            else
            {
                // Insert new record
                string insertQuery = @"
                    INSERT INTO adult_medications (
                        patient_id,
                        consultation_date,
                        medication_details,
                        created_at
                    ) VALUES (
                        @PatientId,
                        @ConsultationDate,
                        @MedicationDetails,
                        @CreatedAt
                    )";

                using (MySqlCommand command = new MySqlCommand(insertQuery, connection, transaction))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);
                    command.Parameters.AddWithValue("@ConsultationDate", consultationDate);
                    command.Parameters.AddWithValue("@MedicationDetails", txtMedications.Text.Trim());
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void SaveExaminationData(MySqlConnection connection, MySqlTransaction transaction)
        {
            // First check if a record already exists
            string checkQuery = @"
                SELECT examination_id 
                FROM adult_examinations 
                WHERE patient_id = @PatientId 
                AND DATE(consultation_date) = DATE(@ConsultationDate)
                LIMIT 1";

            bool recordExists = false;
            int examinationId = 0;

            using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection, transaction))
            {
                checkCommand.Parameters.AddWithValue("@PatientId", patientId);
                checkCommand.Parameters.AddWithValue("@ConsultationDate", consultationDate);

                using (MySqlDataReader reader = checkCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        recordExists = true;
                        examinationId = reader.GetInt32("examination_id");
                    }
                }
            }

            if (recordExists)
            {
                // Update existing record
                string updateQuery = @"
                    UPDATE adult_examinations 
                    SET physical_examination = @PhysicalExamination,
                        diagnosis = @Diagnosis,
                        updated_at = @UpdatedAt
                    WHERE examination_id = @ExaminationId";

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection, transaction))
                {
                    command.Parameters.AddWithValue("@ExaminationId", examinationId);
                    command.Parameters.AddWithValue("@PhysicalExamination", txtPhysicalExamination.Text.Trim());
                    command.Parameters.AddWithValue("@Diagnosis", txtDiagnosis.Text.Trim());
                    command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
            else
            {
                // Insert new record
                string insertQuery = @"
                    INSERT INTO adult_examinations (
                        patient_id,
                        consultation_date,
                        physical_examination,
                        diagnosis,
                        created_at
                    ) VALUES (
                        @PatientId,
                        @ConsultationDate,
                        @PhysicalExamination,
                        @Diagnosis,
                        @CreatedAt
                    )";

                using (MySqlCommand command = new MySqlCommand(insertQuery, connection, transaction))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);
                    command.Parameters.AddWithValue("@ConsultationDate", consultationDate);
                    command.Parameters.AddWithValue("@PhysicalExamination", txtPhysicalExamination.Text.Trim());
                    command.Parameters.AddWithValue("@Diagnosis", txtDiagnosis.Text.Trim());
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void SaveClinicalData(MySqlConnection connection, MySqlTransaction transaction)
        {
            // First check if a record already exists
            string checkQuery = @"
                SELECT clinical_data_id 
                FROM adult_clinical_data 
                WHERE patient_id = @PatientId 
                AND DATE(consultation_date) = DATE(@ConsultationDate)
                LIMIT 1";

            bool recordExists = false;
            int clinicalDataId = 0;

            using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection, transaction))
            {
                checkCommand.Parameters.AddWithValue("@PatientId", patientId);
                checkCommand.Parameters.AddWithValue("@ConsultationDate", consultationDate);

                using (MySqlDataReader reader = checkCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        recordExists = true;
                        clinicalDataId = reader.GetInt32("clinical_data_id");
                    }
                }
            }

            if (recordExists)
            {
                // Update existing record
                string updateQuery = @"
                    UPDATE adult_clinical_data 
                    SET covid_vaccine = @CovidVaccine,
                        hepatitis_b = @HepatitisB,
                        rotavirus = @Rotavirus,
                        diphtheria_tetanus_pertussis = @Diphtheria,
                        haemophilus_influenza = @Haemophilus,
                        pneumococcal = @Pneumococcal,
                        inactivated_poliovirus = @Poliovirus,
                        influenza = @Influenza,
                        measles_mumps_rubella = @MMR,
                        varicella = @Varicella,
                        hepatitis_a = @HepatitisA,
                        meningococcal = @Meningococcal,
                        chief_complaint = @ChiefComplaint,
                        history = @History,
                        past_medical_history = @PastMedicalHistory,
                        updated_at = @UpdatedAt
                    WHERE clinical_data_id = @ClinicalDataId";

                using (MySqlCommand command = new MySqlCommand(updateQuery, connection, transaction))
                {
                    command.Parameters.AddWithValue("@ClinicalDataId", clinicalDataId);

                    // Vaccination checkboxes
                    command.Parameters.AddWithValue("@CovidVaccine", chkCovidVaccine.Checked);
                    command.Parameters.AddWithValue("@HepatitisB", chkHepatitisB.Checked);
                    command.Parameters.AddWithValue("@Rotavirus", chkRotavirus.Checked);
                    command.Parameters.AddWithValue("@Diphtheria", chkDiphtheria.Checked);
                    command.Parameters.AddWithValue("@Haemophilus", chkHaemophilus.Checked);
                    command.Parameters.AddWithValue("@Pneumococcal", chkPneumococcal.Checked);
                    command.Parameters.AddWithValue("@Poliovirus", chkPoliovirus.Checked);
                    command.Parameters.AddWithValue("@Influenza", chkInfluenza.Checked);
                    command.Parameters.AddWithValue("@MMR", chkMMR.Checked);
                    command.Parameters.AddWithValue("@Varicella", chkVaricella.Checked);
                    command.Parameters.AddWithValue("@HepatitisA", chkHepatitisA.Checked);
                    command.Parameters.AddWithValue("@Meningococcal", chkMeningococcal.Checked);

                    // Text fields
                    command.Parameters.AddWithValue("@ChiefComplaint", txtChiefComplaint.Text.Trim());
                    command.Parameters.AddWithValue("@History", txtHistory.Text.Trim());
                    command.Parameters.AddWithValue("@PastMedicalHistory", txtPastMedicalHistory.Text.Trim());
                    command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
            else
            {
                // Insert new record
                string insertQuery = @"
                    INSERT INTO adult_clinical_data (
                        patient_id,
                        consultation_date,
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
                        past_medical_history,
                        created_at
                    ) VALUES (
                        @PatientId,
                        @ConsultationDate,
                        @CovidVaccine,
                        @HepatitisB,
                        @Rotavirus,
                        @Diphtheria,
                        @Haemophilus,
                        @Pneumococcal,
                        @Poliovirus,
                        @Influenza,
                        @MMR,
                        @Varicella,
                        @HepatitisA,
                        @Meningococcal,
                        @ChiefComplaint,
                        @History,
                        @PastMedicalHistory,
                        @CreatedAt
                    )";

                using (MySqlCommand command = new MySqlCommand(insertQuery, connection, transaction))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);
                    command.Parameters.AddWithValue("@ConsultationDate", consultationDate);

                    // Vaccination checkboxes
                    command.Parameters.AddWithValue("@CovidVaccine", chkCovidVaccine.Checked);
                    command.Parameters.AddWithValue("@HepatitisB", chkHepatitisB.Checked);
                    command.Parameters.AddWithValue("@Rotavirus", chkRotavirus.Checked);
                    command.Parameters.AddWithValue("@Diphtheria", chkDiphtheria.Checked);
                    command.Parameters.AddWithValue("@Haemophilus", chkHaemophilus.Checked);
                    command.Parameters.AddWithValue("@Pneumococcal", chkPneumococcal.Checked);
                    command.Parameters.AddWithValue("@Poliovirus", chkPoliovirus.Checked);
                    command.Parameters.AddWithValue("@Influenza", chkInfluenza.Checked);
                    command.Parameters.AddWithValue("@MMR", chkMMR.Checked);
                    command.Parameters.AddWithValue("@Varicella", chkVaricella.Checked);
                    command.Parameters.AddWithValue("@HepatitisA", chkHepatitisA.Checked);
                    command.Parameters.AddWithValue("@Meningococcal", chkMeningococcal.Checked);

                    // Text fields
                    command.Parameters.AddWithValue("@ChiefComplaint", txtChiefComplaint.Text.Trim());
                    command.Parameters.AddWithValue("@History", txtHistory.Text.Trim());
                    command.Parameters.AddWithValue("@PastMedicalHistory", txtPastMedicalHistory.Text.Trim());
                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
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