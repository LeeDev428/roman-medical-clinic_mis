namespace roman_medical_clinic_mis
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

            // Main components
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblClinicName = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblLoginTitle = new System.Windows.Forms.Label();
            this.pnlSignup = new System.Windows.Forms.Panel();
            this.lblSignupTitle = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);

            // Login controls
            this.lblLoginUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblLoginPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();

            // Signup controls
            this.lblFullname = new System.Windows.Forms.Label();
            this.txtFullname = new System.Windows.Forms.TextBox();
            this.lblFullAddress = new System.Windows.Forms.Label();
            this.txtFullAddress = new System.Windows.Forms.TextBox();
            this.lblContactNumber = new System.Windows.Forms.Label();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.lblUserType = new System.Windows.Forms.Label();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.lblUsernameSignup = new System.Windows.Forms.Label();
            this.txtUsernameSignup = new System.Windows.Forms.TextBox();
            this.lblPasswordSignup = new System.Windows.Forms.Label();
            this.txtPasswordSignup = new System.Windows.Forms.TextBox();
            this.btnShowPasswordSignup = new System.Windows.Forms.Button();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnSignup = new System.Windows.Forms.Button();

            // Window controls
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();

            // Initialize containers
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.pnlSignup.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlHeader.Controls.Add(this.lblClinicName);
            this.pnlHeader.Controls.Add(this.lblAddress1);
            this.pnlHeader.Controls.Add(this.lblAddress2);
            this.pnlHeader.Controls.Add(this.btnMinimize);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(950, 130);
            this.pnlHeader.TabIndex = 0;

            // lblClinicName
            this.lblClinicName.AutoSize = true;
            this.lblClinicName.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblClinicName.ForeColor = System.Drawing.Color.White;
            this.lblClinicName.Location = new System.Drawing.Point(300, 30);
            this.lblClinicName.Name = "lblClinicName";
            this.lblClinicName.Size = new System.Drawing.Size(380, 37);
            this.lblClinicName.Text = "ROMAN MEDICAL CLINIC";
            this.lblClinicName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblAddress1
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Font = new System.Drawing.Font("Arial", 12F);
            this.lblAddress1.ForeColor = System.Drawing.Color.White;
            this.lblAddress1.Location = new System.Drawing.Point(390, 75);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(200, 18);
            this.lblAddress1.Text = "Rizal, Imatong Pililla Rizal";

            // lblAddress2
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Font = new System.Drawing.Font("Arial", 12F);
            this.lblAddress2.ForeColor = System.Drawing.Color.White;
            this.lblAddress2.Location = new System.Drawing.Point(390, 95);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(200, 18);
            this.lblAddress2.Text = "Rizal, Philippines, 1910";

            // btnMinimize
            this.btnMinimize.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnMinimize.FlatAppearance.BorderSize = 1;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(878, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 0;
            this.btnMinimize.Text = "-";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);

            // btnClose
            this.btnClose.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.FlatAppearance.BorderSize = 1;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(908, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // pnlLogin
            this.pnlLogin.BackColor = System.Drawing.Color.White;
            this.pnlLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogin.Controls.Add(this.lblLoginTitle);
            this.pnlLogin.Controls.Add(this.picLogo);
            this.pnlLogin.Controls.Add(this.lblLoginUsername);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Controls.Add(this.lblLoginPassword);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.btnShowPassword);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Location = new System.Drawing.Point(12, 140);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(460, 450);
            this.pnlLogin.TabIndex = 0;

            // lblLoginTitle
            this.lblLoginTitle.AutoSize = true;
            this.lblLoginTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblLoginTitle.Location = new System.Drawing.Point(20, 10);
            this.lblLoginTitle.Name = "lblLoginTitle";
            this.lblLoginTitle.Size = new System.Drawing.Size(70, 22);
            this.lblLoginTitle.Text = "LOGIN";

            // picLogo
            this.picLogo.Image = global::roman_medical_clinic_mis.Properties.Resources.rmc;
            this.picLogo.Location = new System.Drawing.Point(130, 35);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(200, 200);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;

            // lblLoginUsername
            this.lblLoginUsername.AutoSize = true;
            this.lblLoginUsername.Font = new System.Drawing.Font("Arial", 10F);
            this.lblLoginUsername.Location = new System.Drawing.Point(20, 250);
            this.lblLoginUsername.Name = "lblLoginUsername";
            this.lblLoginUsername.Size = new System.Drawing.Size(70, 16);
            this.lblLoginUsername.Text = "Username";

            // txtUsername
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Arial", 11F);
            this.txtUsername.Location = new System.Drawing.Point(20, 270);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(420, 24);
            this.txtUsername.TabIndex = 0;

            // lblLoginPassword
            this.lblLoginPassword.AutoSize = true;
            this.lblLoginPassword.Font = new System.Drawing.Font("Arial", 10F);
            this.lblLoginPassword.Location = new System.Drawing.Point(20, 310);
            this.lblLoginPassword.Name = "lblLoginPassword";
            this.lblLoginPassword.Size = new System.Drawing.Size(69, 16);
            this.lblLoginPassword.Text = "Password";

            // txtPassword
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Arial", 11F);
            this.txtPassword.Location = new System.Drawing.Point(20, 330);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(385, 24);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;

            // btnShowPassword
            this.btnShowPassword.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPassword.Font = new System.Drawing.Font("Arial", 8F);
            this.btnShowPassword.ForeColor = System.Drawing.Color.White;
            this.btnShowPassword.Location = new System.Drawing.Point(405, 330);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(35, 24);
            this.btnShowPassword.TabIndex = 2;
            this.btnShowPassword.Text = "👁";
            this.btnShowPassword.UseVisualStyleBackColor = false;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);

            // btnLogin
            this.btnLogin.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(180, 380);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 40);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // pnlSignup
            this.pnlSignup.BackColor = System.Drawing.Color.White;
            this.pnlSignup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSignup.Controls.Add(this.lblSignupTitle);
            this.pnlSignup.Controls.Add(this.lblFullname);
            this.pnlSignup.Controls.Add(this.txtFullname);
            this.pnlSignup.Controls.Add(this.lblFullAddress);
            this.pnlSignup.Controls.Add(this.txtFullAddress);
            this.pnlSignup.Controls.Add(this.lblContactNumber);
            this.pnlSignup.Controls.Add(this.txtContactNumber);
            this.pnlSignup.Controls.Add(this.lblEmailAddress);
            this.pnlSignup.Controls.Add(this.txtEmailAddress);
            this.pnlSignup.Controls.Add(this.lblUserType);
            this.pnlSignup.Controls.Add(this.cmbUserType);
            this.pnlSignup.Controls.Add(this.lblUsernameSignup);
            this.pnlSignup.Controls.Add(this.txtUsernameSignup);
            this.pnlSignup.Controls.Add(this.lblPasswordSignup);
            this.pnlSignup.Controls.Add(this.txtPasswordSignup);
            this.pnlSignup.Controls.Add(this.btnShowPasswordSignup);
            this.pnlSignup.Controls.Add(this.lblConfirmPassword);
            this.pnlSignup.Controls.Add(this.txtConfirmPassword);
            this.pnlSignup.Controls.Add(this.btnSignup);
            this.pnlSignup.Location = new System.Drawing.Point(478, 140);
            this.pnlSignup.Name = "pnlSignup";
            this.pnlSignup.Size = new System.Drawing.Size(460, 450);
            this.pnlSignup.TabIndex = 1;

            // lblSignupTitle
            this.lblSignupTitle.AutoSize = true;
            this.lblSignupTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblSignupTitle.Location = new System.Drawing.Point(20, 10);
            this.lblSignupTitle.Name = "lblSignupTitle";
            this.lblSignupTitle.Size = new System.Drawing.Size(84, 22);
            this.lblSignupTitle.Text = "SIGNUP";

            // lblFullname
            this.lblFullname.AutoSize = true;
            this.lblFullname.Font = new System.Drawing.Font("Arial", 10F);
            this.lblFullname.Location = new System.Drawing.Point(20, 40);
            this.lblFullname.Name = "lblFullname";
            this.lblFullname.Size = new System.Drawing.Size(69, 16);
            this.lblFullname.Text = "Fullname";

            // txtFullname
            this.txtFullname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullname.Font = new System.Drawing.Font("Arial", 11F);
            this.txtFullname.Location = new System.Drawing.Point(20, 60);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.Size = new System.Drawing.Size(420, 24);
            this.txtFullname.TabIndex = 0;

            // lblFullAddress
            this.lblFullAddress.AutoSize = true;
            this.lblFullAddress.Font = new System.Drawing.Font("Arial", 10F);
            this.lblFullAddress.Location = new System.Drawing.Point(20, 90);
            this.lblFullAddress.Name = "lblFullAddress";
            this.lblFullAddress.Size = new System.Drawing.Size(88, 16);
            this.lblFullAddress.Text = "Full Address";

            // txtFullAddress
            this.txtFullAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullAddress.Font = new System.Drawing.Font("Arial", 11F);
            this.txtFullAddress.Location = new System.Drawing.Point(20, 110);
            this.txtFullAddress.Name = "txtFullAddress";
            this.txtFullAddress.Size = new System.Drawing.Size(420, 24);
            this.txtFullAddress.TabIndex = 1;

            // lblContactNumber
            this.lblContactNumber.AutoSize = true;
            this.lblContactNumber.Font = new System.Drawing.Font("Arial", 10F);
            this.lblContactNumber.Location = new System.Drawing.Point(20, 140);
            this.lblContactNumber.Name = "lblContactNumber";
            this.lblContactNumber.Size = new System.Drawing.Size(112, 16);
            this.lblContactNumber.Text = "Contact Number";

            // txtContactNumber
            this.txtContactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContactNumber.Font = new System.Drawing.Font("Arial", 11F);
            this.txtContactNumber.Location = new System.Drawing.Point(20, 160);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(200, 24);
            this.txtContactNumber.TabIndex = 2;

            // lblEmailAddress
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Font = new System.Drawing.Font("Arial", 10F);
            this.lblEmailAddress.Location = new System.Drawing.Point(240, 140);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(101, 16);
            this.lblEmailAddress.Text = "Email Address";

            // txtEmailAddress
            this.txtEmailAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailAddress.Font = new System.Drawing.Font("Arial", 11F);
            this.txtEmailAddress.Location = new System.Drawing.Point(240, 160);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(200, 24);
            this.txtEmailAddress.TabIndex = 3;

            // lblUserType
            this.lblUserType.AutoSize = true;
            this.lblUserType.Font = new System.Drawing.Font("Arial", 10F);
            this.lblUserType.Location = new System.Drawing.Point(20, 190);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(75, 16);
            this.lblUserType.Text = "User Type";

            // cmbUserType
            this.cmbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserType.Font = new System.Drawing.Font("Arial", 11F);
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Items.AddRange(new object[] { "Staff", "Doctor", "Nurse", "Admin" });
            this.cmbUserType.Location = new System.Drawing.Point(20, 210);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(200, 25);
            this.cmbUserType.TabIndex = 4;

            // lblUsernameSignup
            this.lblUsernameSignup.AutoSize = true;
            this.lblUsernameSignup.Font = new System.Drawing.Font("Arial", 10F);
            this.lblUsernameSignup.Location = new System.Drawing.Point(240, 190);
            this.lblUsernameSignup.Name = "lblUsernameSignup";
            this.lblUsernameSignup.Size = new System.Drawing.Size(75, 16);
            this.lblUsernameSignup.Text = "Username";

            // txtUsernameSignup
            this.txtUsernameSignup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsernameSignup.Font = new System.Drawing.Font("Arial", 11F);
            this.txtUsernameSignup.Location = new System.Drawing.Point(240, 210);
            this.txtUsernameSignup.Name = "txtUsernameSignup";
            this.txtUsernameSignup.Size = new System.Drawing.Size(200, 24);
            this.txtUsernameSignup.TabIndex = 5;

            // lblPasswordSignup
            this.lblPasswordSignup.AutoSize = true;
            this.lblPasswordSignup.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPasswordSignup.Location = new System.Drawing.Point(20, 240);
            this.lblPasswordSignup.Name = "lblPasswordSignup";
            this.lblPasswordSignup.Size = new System.Drawing.Size(69, 16);
            this.lblPasswordSignup.Text = "Password";

            // txtPasswordSignup
            this.txtPasswordSignup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordSignup.Font = new System.Drawing.Font("Arial", 11F);
            this.txtPasswordSignup.Location = new System.Drawing.Point(20, 260);
            this.txtPasswordSignup.Name = "txtPasswordSignup";
            this.txtPasswordSignup.Size = new System.Drawing.Size(165, 24);
            this.txtPasswordSignup.TabIndex = 6;
            this.txtPasswordSignup.UseSystemPasswordChar = true;

            // btnShowPasswordSignup
            this.btnShowPasswordSignup.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnShowPasswordSignup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPasswordSignup.Font = new System.Drawing.Font("Arial", 8F);
            this.btnShowPasswordSignup.ForeColor = System.Drawing.Color.White;
            this.btnShowPasswordSignup.Location = new System.Drawing.Point(185, 260);
            this.btnShowPasswordSignup.Name = "btnShowPasswordSignup";
            this.btnShowPasswordSignup.Size = new System.Drawing.Size(35, 24);
            this.btnShowPasswordSignup.TabIndex = 7;
            this.btnShowPasswordSignup.Text = "👁";
            this.btnShowPasswordSignup.UseVisualStyleBackColor = false;
            this.btnShowPasswordSignup.Click += new System.EventHandler(this.btnShowPasswordSignup_Click);

            // lblConfirmPassword
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Arial", 10F);
            this.lblConfirmPassword.Location = new System.Drawing.Point(240, 240);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(123, 16);
            this.lblConfirmPassword.Text = "Confirm Password";

            // txtConfirmPassword
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Arial", 11F);
            this.txtConfirmPassword.Location = new System.Drawing.Point(240, 260);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 24);
            this.txtConfirmPassword.TabIndex = 8;
            this.txtConfirmPassword.UseSystemPasswordChar = true;

            // btnSignup
            this.btnSignup.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSignup.FlatAppearance.BorderSize = 0;
            this.btnSignup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignup.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.btnSignup.ForeColor = System.Drawing.Color.White;
            this.btnSignup.Location = new System.Drawing.Point(340, 320);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(100, 40);
            this.btnSignup.TabIndex = 9;
            this.btnSignup.Text = "SIGNUP";
            this.btnSignup.UseVisualStyleBackColor = false;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);

            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlFooter.Controls.Add(this.lblDateTime);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 600);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(950, 36);
            this.pnlFooter.TabIndex = 2;

            // lblDateTime
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(770, 10);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(168, 19);
            this.lblDateTime.Text = "6/30/2025   8:51:12 AM";

            // timer1
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(950, 636);

            // Add controls to form
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlSignup);
            this.Controls.Add(this.pnlFooter);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roman Medical Clinic MIS - Login/Signup";

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlSignup.ResumeLayout(false);
            this.pnlSignup.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblClinicName;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblLoginTitle;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblLoginUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblLoginPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnShowPassword;
        private System.Windows.Forms.Button btnLogin;

        private System.Windows.Forms.Panel pnlSignup;
        private System.Windows.Forms.Label lblSignupTitle;
        private System.Windows.Forms.Label lblFullname;
        private System.Windows.Forms.TextBox txtFullname;
        private System.Windows.Forms.Label lblFullAddress;
        private System.Windows.Forms.TextBox txtFullAddress;
        private System.Windows.Forms.Label lblContactNumber;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label lblUserType;
        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.Label lblUsernameSignup;
        private System.Windows.Forms.TextBox txtUsernameSignup;
        private System.Windows.Forms.Label lblPasswordSignup;
        private System.Windows.Forms.TextBox txtPasswordSignup;
        private System.Windows.Forms.Button btnShowPasswordSignup;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnSignup;

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Timer timer1;
    }
}