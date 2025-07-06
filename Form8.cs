using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace roman_medical_clinic_mis
{
    public partial class Form8 : Form
    {
        // Database connection string
        private string connectionString = "server=localhost;database=db_roman_clinic;uid=root;pwd=;";

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            // Load the current licensure data
            LoadLicensureData();
        }

        private void LoadLicensureData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // First check if the clinic_info table exists
                    EnsureClinicInfoTableExists(connection);

                    // Get the licensure data
                    string query = "SELECT licensure_number FROM clinic_info WHERE id = 1";
                    MySqlCommand command = new MySqlCommand(query, connection);

                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        txtLicensure.Text = result.ToString();
                    }
                    else
                    {
                        // Insert a default record if none exists
                        string insertQuery = "INSERT INTO clinic_info (id, licensure_number) VALUES (1, 'S2: 030037RM23-026')";
                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                        insertCommand.ExecuteNonQuery();

                        txtLicensure.Text = "S2: 030037RM23-026";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading licensure data: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnsureClinicInfoTableExists(MySqlConnection connection)
        {
            try
            {
                // Check if the table exists - FIX: Use correct database name
                string checkTableQuery = @"
                    SELECT COUNT(*)
                    FROM information_schema.tables
                    WHERE table_schema = 'db_roman_clinic'
                    AND table_name = 'clinic_info'";

                MySqlCommand checkCommand = new MySqlCommand(checkTableQuery, connection);
                int tableExists = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (tableExists == 0)
                {
                    // Create the table
                    string createTableQuery = @"
                        CREATE TABLE clinic_info (
                            id INT PRIMARY KEY,
                            licensure_number VARCHAR(50),
                            last_updated TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
                        )";

                    MySqlCommand createCommand = new MySqlCommand(createTableQuery, connection);
                    createCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting up database: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Update the licensure number
                    string query = "UPDATE clinic_info SET licensure_number = @LicensureNumber WHERE id = 1";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@LicensureNumber", txtLicensure.Text.Trim());

                    int rowsAffected = command.ExecuteNonQuery();

                    // If no rows were affected, the record might not exist yet
                    if (rowsAffected == 0)
                    {
                        string insertQuery = "INSERT INTO clinic_info (id, licensure_number) VALUES (1, @LicensureNumber)";
                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@LicensureNumber", txtLicensure.Text.Trim());
                        insertCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Licensure information saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving licensure data: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}