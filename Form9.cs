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
    public partial class Form9 : Form
    {
        private string connectionString = "server=localhost;database=db_roman_clinic;uid=root;pwd=;";
        private string currentUserType;
        private string currentUsername;
        private string currentFullName;

        public Form9(string userType, string username, string fullName)
        {
            InitializeComponent();
            currentUserType = userType;
            currentUsername = username;
            currentFullName = fullName;

            // Attach FormClosing event
            this.FormClosing += Form9_FormClosing;
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            LoadUserAccounts();
            // Enable buttons only for admin, and only if a row is selected
            UpdateButtonStates();
            dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
        }

        private void DgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            bool isAdmin = currentUserType.ToLower() == "admin";
            bool hasSelection = dgvUsers.SelectedRows.Count > 0;
            btnApprove.Enabled = btnDecline.Enabled = isAdmin && hasSelection;
        }

        private void LoadUserAccounts()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT id, fullname, username, usertype, email, 
                        CASE WHEN is_approved = 1 THEN 'Approved' ELSE 'Pending' END AS approval_status
                    FROM users
                    WHERE usertype <> 'admin'
                    ORDER BY is_approved ASC, id DESC";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvUsers.DataSource = dt;
                }
            }
            UpdateButtonStates();
        }

        private int? GetSelectedUserId()
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["id"].Value);
            }
            return null;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (currentUserType.ToLower() != "admin")
            {
                MessageBox.Show("Only admins can approve accounts.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var userId = GetSelectedUserId();
            if (userId.HasValue)
            {
                UpdateApprovalStatus(userId.Value, true);
                GoBackToForm2();
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            if (currentUserType.ToLower() != "admin")
            {
                MessageBox.Show("Only admins can decline accounts.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var userId = GetSelectedUserId();
            if (userId.HasValue)
            {
                UpdateApprovalStatus(userId.Value, false);
                GoBackToForm2();
            }
        }

        private void UpdateApprovalStatus(int userId, bool approve)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE users SET is_approved = @IsApproved WHERE id = @UserId";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IsApproved", approve ? 1 : 0);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
            // No need to reload accounts, since we are closing the form
        }

        private void GoBackToForm2()
        {
            // Show Form2 and pass user info
            Form2 form2 = new Form2(currentUserType, currentUsername, currentFullName);
            form2.Show();
            this.FormClosing -= Form9_FormClosing; // Prevent double open
            this.Close();
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Always go back to Form2 if not already open
            bool form2Open = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form2)
                {
                    form2Open = true;
                    f.Show();
                    break;
                }
            }
            if (!form2Open)
            {
                Form2 form2 = new Form2(currentUserType, currentUsername, currentFullName);
                form2.Show();
            }
        }
    }
}
