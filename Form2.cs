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
        private string connectionString = "server=localhost;database=roman_medical_clinic_db;uid=root;pwd=;";
        private int selectedPatientId = 0;
        private bool isEditMode = false;

        public Form2()
        {
            InitializeComponent();

            // Initialize UI components
            cmbSex.SelectedIndex = 0; // Default to SELECT
            SetupDataGridView();
            ClearFields();

            // Set default dates
            dtpBirthdate.Value = DateTime.Today;
            dtpConsultDate.Value = DateTime.Today;
            dtpSearchConsult.Value = DateTime.Today;
            dtpFromDate.Value = DateTime.Today.AddDays(-30);
            dtpToDate.Value = DateTime.Today;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Load patient data
            LoadPatients();
            CalculateAge();
        }

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
            MessageBox.Show("About & License feature is not implemented in this example.",
                "Feature Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
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
                selectedPatientId = Convert.ToInt32(dgvPatients.Rows[e.RowIndex].Cells["patient_id"].Value);
                LoadPatientDetails(selectedPatientId);
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
                    UpdatePatient();
                    LoadPatients();
                    ClearFields();
                    isEditMode = false;
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
                // Keep patient information but set a new consultation date
                dtpConsultDate.Value = DateTime.Today;
                
                // Clear the ID to make it save as a new record
                int tempId = selectedPatientId;
                selectedPatientId = 0;
                
                MessageBox.Show("Please update any necessary information and click Save to create a new consultation record.", 
                    "Reconsultation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // If they cancel, we need the ID to restore the original record
                btnCancel.Tag = tempId;
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
                // In a real application, this would open a prescription form
                // For now, show a placeholder message
                string patientName = $"{txtGivenName.Text} {txtSurname.Text}";
                MessageBox.Show($"Prescription module for {patientName} would be displayed here.\n\nThis feature will be implemented in a future update.", 
                    "Prescriptions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                // Future implementation might look like:
                // PrescriptionForm prescriptionForm = new PrescriptionForm(selectedPatientId, patientName);
                // prescriptionForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a patient record first.", 
                    "No Patient Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                Name = "patient_id",
                DataPropertyName = "patient_id",
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
                Name = "given_name",
                DataPropertyName = "given_name",
                HeaderText = "Given Name",
                Width = 120
            });

            dgvPatients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "middle_name",
                DataPropertyName = "middle_name",
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
                Name = "consultation_date",
                DataPropertyName = "consultation_date",
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
                            patient_id,
                            surname,
                            given_name,
                            middle_name,
                            address,
                            sex,
                            birthdate,
                            TIMESTAMPDIFF(YEAR, birthdate, CURDATE()) as age,
                            consultation_date
                        FROM pedia_patients
                        ORDER BY consultation_date DESC, surname ASC";

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
                            patient_id,
                            surname,
                            given_name,
                            middle_name,
                            address,
                            sex,
                            birthdate,
                            TIMESTAMPDIFF(YEAR, birthdate, CURDATE()) as age,
                            consultation_date
                        FROM pedia_patients
                        WHERE 1=1");

                    // Add search criteria
                    List<MySqlParameter> parameters = new List<MySqlParameter>();

                    // Name search (across surname, given_name, and middle_name)
                    if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
                    {
                        string searchTerm = $"%{txtSearchName.Text.Trim()}%";
                        queryBuilder.Append(" AND (surname LIKE @SearchTerm OR given_name LIKE @SearchTerm OR middle_name LIKE @SearchTerm)");
                        parameters.Add(new MySqlParameter("@SearchTerm", searchTerm));
                    }

                    // Date range search
                    queryBuilder.Append(" AND consultation_date BETWEEN @FromDate AND @ToDate");
                    parameters.Add(new MySqlParameter("@FromDate", dtpFromDate.Value.Date));
                    parameters.Add(new MySqlParameter("@ToDate", dtpToDate.Value.Date.AddDays(1).AddSeconds(-1)));

                    // Specific consultation date
                    if (dtpSearchConsult.Checked)
                    {
                        queryBuilder.Append(" AND DATE(consultation_date) = DATE(@ConsultDate)");
                        parameters.Add(new MySqlParameter("@ConsultDate", dtpSearchConsult.Value.Date));
                    }

                    queryBuilder.Append(" ORDER BY consultation_date DESC, surname ASC");

                    using (MySqlCommand command = new MySqlCommand(queryBuilder.ToString(), connection))
                    {
                        // Add parameters to command
                        foreach (var param in parameters)
                        {
                            command.Parameters.Add(param);
                        }

                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvPatients.DataSource = dataTable;

                        // Update filtered count
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
                            patient_id,
                            surname,
                            given_name,
                            middle_name,
                            address,
                            sex,
                            birthdate,
                            consultation_date
                        FROM pedia_patients
                        WHERE patient_id = @PatientId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientId", patientId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate form fields
                                txtSurname.Text = reader["surname"].ToString();
                                txtGivenName.Text = reader["given_name"].ToString();
                                txtMiddleName.Text = reader["middle_name"].ToString();
                                txtAddress.Text = reader["address"].ToString();
                                cmbSex.Text = reader["sex"].ToString();
                                dtpBirthdate.Value = Convert.ToDateTime(reader["birthdate"]);
                                dtpConsultDate.Value = Convert.ToDateTime(reader["consultation_date"]);

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
                            given_name,
                            middle_name,
                            address,
                            sex,
                            birthdate,
                            consultation_date,
                            created_at
                        ) VALUES (
                            @Surname,
                            @GivenName,
                            @MiddleName,
                            @Address,
                            @Sex,
                            @Birthdate,
                            @ConsultationDate,
                            @CreatedAt
                        )";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim());
                        command.Parameters.AddWithValue("@GivenName", txtGivenName.Text.Trim());
                        command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text.Trim());
                        command.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        command.Parameters.AddWithValue("@Sex", cmbSex.Text);
                        command.Parameters.AddWithValue("@Birthdate", dtpBirthdate.Value.Date);
                        command.Parameters.AddWithValue("@ConsultationDate", dtpConsultDate.Value);
                        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

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
                            given_name = @GivenName,
                            middle_name = @MiddleName,
                            address = @Address,
                            sex = @Sex,
                            birthdate = @Birthdate,
                            consultation_date = @ConsultationDate,
                            updated_at = @UpdatedAt
                        WHERE patient_id = @PatientId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientId", selectedPatientId);
                        command.Parameters.AddWithValue("@Surname", txtSurname.Text.Trim());
                        command.Parameters.AddWithValue("@GivenName", txtGivenName.Text.Trim());
                        command.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text.Trim());
                        command.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                        command.Parameters.AddWithValue("@Sex", cmbSex.Text);
                        command.Parameters.AddWithValue("@Birthdate", dtpBirthdate.Value.Date);
                        command.Parameters.AddWithValue("@ConsultationDate", dtpConsultDate.Value);
                        command.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

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

                    string query = "DELETE FROM pedia_patients WHERE patient_id = @PatientId";

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