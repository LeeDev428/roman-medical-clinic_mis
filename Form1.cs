using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace roman_medical_clinic_mis
{
    public partial class Form1 : Form
    {
        // Update this connection string for your Laragon MySQL setup
        private string connectionString = "server=localhost;database=db_roman_clinic;uid=root;pwd=;";

        public Form1()
        {
            InitializeComponent();
            cmbUserType.SelectedIndex = 0; // Default to Staff
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("M/d/yyyy h:mm:ss tt");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            btnShowPassword.Text = txtPassword.UseSystemPasswordChar ? "👁" : "🙈";
        }

        private void btnShowPasswordSignup_Click(object sender, EventArgs e)
        {
            txtPasswordSignup.UseSystemPasswordChar = !txtPasswordSignup.UseSystemPasswordChar;
            btnShowPasswordSignup.Text = txtPasswordSignup.UseSystemPasswordChar ? "👁" : "🙈";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLoginInput())
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT id, usertype, fullname FROM users WHERE username = @Username AND password = @Password AND status = 'Active' AND is_approved = 1";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                            command.Parameters.AddWithValue("@Password", HashPassword(txtPassword.Text));

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int userId = reader.GetInt32("id");
                                    string userType = reader.GetString("usertype");
                                    string fullName = reader.GetString("fullname");

                                    MessageBox.Show($"Welcome, {fullName}!\nUser Type: {userType}", "Login Successful",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    txtUsername.Clear();
                                    txtPassword.Clear();

                                    Form2 pediatricRecordsForm = new Form2(userType, txtUsername.Text.Trim(), fullName);
                                    pediatricRecordsForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid username, password, or your account is not yet approved.", "Login Failed",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (ValidateSignupInput())
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();

                        // Check if username already exists
                        string checkQuery = "SELECT COUNT(*) FROM users WHERE username = @Username";
                        using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@Username", txtUsernameSignup.Text.Trim());
                            int userCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                            if (userCount > 0)
                            {
                                MessageBox.Show("Username already exists. Please choose a different username.",
                                    "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // Check if email already exists
                        string checkEmailQuery = "SELECT COUNT(*) FROM users WHERE email = @Email";
                        using (MySqlCommand checkEmailCommand = new MySqlCommand(checkEmailQuery, connection))
                        {
                            checkEmailCommand.Parameters.AddWithValue("@Email", txtEmailAddress.Text.Trim());
                            int emailCount = Convert.ToInt32(checkEmailCommand.ExecuteScalar());

                            if (emailCount > 0)
                            {
                                MessageBox.Show("Email address already exists. Please use a different email.",
                                    "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        // Insert new user
                        string insertQuery = @"INSERT INTO users (fullname, fulladdress, contactno, email, 
                                             usertype, username, password, dateregistration, status, is_approved) 
                                             VALUES (@FullName, @FullAddress, @ContactNumber, @Email, 
                                             @UserType, @Username, @Password, @DateRegistration, @Status, 0)";

                        using (MySqlCommand command = new MySqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@FullName", txtFullname.Text.Trim());
                            command.Parameters.AddWithValue("@FullAddress", txtFullAddress.Text.Trim());
                            command.Parameters.AddWithValue("@ContactNumber", txtContactNumber.Text.Trim());
                            command.Parameters.AddWithValue("@Email", txtEmailAddress.Text.Trim());
                            command.Parameters.AddWithValue("@UserType", cmbUserType.SelectedItem.ToString());
                            command.Parameters.AddWithValue("@Username", txtUsernameSignup.Text.Trim());
                            command.Parameters.AddWithValue("@Password", HashPassword(txtPasswordSignup.Text));
                            command.Parameters.AddWithValue("@DateRegistration", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            command.Parameters.AddWithValue("@Status", "Active");

                            command.ExecuteNonQuery();

                            MessageBox.Show("Registration successful! You can now login with your credentials.",
                                "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear signup form
                            ClearSignupForm();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateLoginInput()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter your username.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter your password.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateSignupInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullname.Text))
            {
                MessageBox.Show("Please enter your full name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullname.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFullAddress.Text))
            {
                MessageBox.Show("Please enter your full address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullAddress.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContactNumber.Text))
            {
                MessageBox.Show("Please enter your contact number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNumber.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmailAddress.Text))
            {
                MessageBox.Show("Please enter your email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailAddress.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmailAddress.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailAddress.Focus();
                return false;
            }

            if (cmbUserType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a user type.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbUserType.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsernameSignup.Text))
            {
                MessageBox.Show("Please enter a username.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsernameSignup.Focus();
                return false;
            }

            if (txtUsernameSignup.Text.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters long.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsernameSignup.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPasswordSignup.Text))
            {
                MessageBox.Show("Please enter a password.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswordSignup.Focus();
                return false;
            }

            if (txtPasswordSignup.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPasswordSignup.Focus();
                return false;
            }

            if (txtPasswordSignup.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password + "RomanClinicSalt2025"));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void ClearSignupForm()
        {
            txtFullname.Clear();
            txtFullAddress.Clear();
            txtContactNumber.Clear();
            txtEmailAddress.Clear();
            txtUsernameSignup.Clear();
            txtPasswordSignup.Clear();
            txtConfirmPassword.Clear();
            cmbUserType.SelectedIndex = 0;
        }
    }
}