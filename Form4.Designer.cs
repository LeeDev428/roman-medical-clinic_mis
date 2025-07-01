namespace roman_medical_clinic_mis
{
    partial class Form4
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
            // Main layout panels
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();

            // Sidebar controls
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.btnPediaMedRecords = new System.Windows.Forms.Button();
            this.btnAdultMedRecords = new System.Windows.Forms.Button();
            this.btnUserAccounts = new System.Windows.Forms.Button();
            this.btnAboutLicense = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();

            // Header controls
            this.lblClinicName = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();

            // Main form controls
            this.pnlConsultationDetails = new System.Windows.Forms.Panel();
            this.lblConsultationDetails = new System.Windows.Forms.Label();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblGivenName = new System.Windows.Forms.Label();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtGivenName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();

            // Action buttons
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // Tab control
            this.tabConsultation = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();

            // Tab Page 1 - Medications
            this.lblMedications = new System.Windows.Forms.Label();
            this.txtMedications = new System.Windows.Forms.TextBox();

            // Tab Page 2 - Physical Examination & Diagnosis
            this.lblPhysicalExamination = new System.Windows.Forms.Label();
            this.txtPhysicalExamination = new System.Windows.Forms.TextBox();
            this.lblDiagnosis = new System.Windows.Forms.Label();
            this.txtDiagnosis = new System.Windows.Forms.TextBox();

            // Tab Page 3 - Vaccination, Complaints & History
            this.pnlVaccination = new System.Windows.Forms.Panel();
            this.lblVaccination = new System.Windows.Forms.Label();
            this.chkCovidVaccine = new System.Windows.Forms.CheckBox();
            this.chkHepatitisB = new System.Windows.Forms.CheckBox();
            this.chkRotavirus = new System.Windows.Forms.CheckBox();
            this.chkDiphtheria = new System.Windows.Forms.CheckBox();
            this.chkHaemophilus = new System.Windows.Forms.CheckBox();
            this.chkPneumococcal = new System.Windows.Forms.CheckBox();
            this.chkPoliovirus = new System.Windows.Forms.CheckBox();
            this.chkInfluenza = new System.Windows.Forms.CheckBox();
            this.chkMMR = new System.Windows.Forms.CheckBox();
            this.chkVaricella = new System.Windows.Forms.CheckBox();
            this.chkHepatitisA = new System.Windows.Forms.CheckBox();
            this.chkMeningococcal = new System.Windows.Forms.CheckBox();

            this.pnlHistory = new System.Windows.Forms.Panel();
            this.lblChiefComplaint = new System.Windows.Forms.Label();
            this.txtChiefComplaint = new System.Windows.Forms.TextBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.txtHistory = new System.Windows.Forms.TextBox();
            this.lblPastMedicalHistory = new System.Windows.Forms.Label();
            this.txtPastMedicalHistory = new System.Windows.Forms.TextBox();

            // Footer with login info
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblLoginInfo = new System.Windows.Forms.Label();

            // Initialize containers
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlConsultationDetails.SuspendLayout();
            this.tabConsultation.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.pnlVaccination.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlSidebar.Controls.Add(this.btnLogout);
            this.pnlSidebar.Controls.Add(this.picLogo);
            this.pnlSidebar.Controls.Add(this.lblDashboard);
            this.pnlSidebar.Controls.Add(this.btnPediaMedRecords);
            this.pnlSidebar.Controls.Add(this.btnAdultMedRecords);
            this.pnlSidebar.Controls.Add(this.btnUserAccounts);
            this.pnlSidebar.Controls.Add(this.btnAboutLicense);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 700);
            this.pnlSidebar.TabIndex = 0;

            // picLogo
            this.picLogo.Image = global::roman_medical_clinic_mis.Properties.Resources.rmc;
            this.picLogo.Location = new System.Drawing.Point(50, 20);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(100, 100);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;

            // lblDashboard
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashboard.ForeColor = System.Drawing.Color.White;
            this.lblDashboard.Location = new System.Drawing.Point(12, 140);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(110, 19);
            this.lblDashboard.TabIndex = 1;
            this.lblDashboard.Text = "DASHBOARD";

            // btnPediaMedRecords
            this.btnPediaMedRecords.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnPediaMedRecords.FlatAppearance.BorderSize = 0;
            this.btnPediaMedRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPediaMedRecords.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPediaMedRecords.ForeColor = System.Drawing.Color.White;
            this.btnPediaMedRecords.Location = new System.Drawing.Point(0, 180);
            this.btnPediaMedRecords.Name = "btnPediaMedRecords";
            this.btnPediaMedRecords.Size = new System.Drawing.Size(200, 40);
            this.btnPediaMedRecords.TabIndex = 2;
            this.btnPediaMedRecords.Text = "Pedia Med. Records";
            this.btnPediaMedRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPediaMedRecords.UseVisualStyleBackColor = false;
            this.btnPediaMedRecords.Click += new System.EventHandler(this.btnPediaMedRecords_Click);

            // btnAdultMedRecords
            this.btnAdultMedRecords.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdultMedRecords.FlatAppearance.BorderSize = 0;
            this.btnAdultMedRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdultMedRecords.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdultMedRecords.ForeColor = System.Drawing.Color.White;
            this.btnAdultMedRecords.Location = new System.Drawing.Point(0, 220);
            this.btnAdultMedRecords.Name = "btnAdultMedRecords";
            this.btnAdultMedRecords.Size = new System.Drawing.Size(200, 40);
            this.btnAdultMedRecords.TabIndex = 3;
            this.btnAdultMedRecords.Text = "Adult Med. Records";
            this.btnAdultMedRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdultMedRecords.UseVisualStyleBackColor = false;
            this.btnAdultMedRecords.Click += new System.EventHandler(this.btnAdultMedRecords_Click);

            // btnUserAccounts
            this.btnUserAccounts.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnUserAccounts.FlatAppearance.BorderSize = 0;
            this.btnUserAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserAccounts.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserAccounts.ForeColor = System.Drawing.Color.White;
            this.btnUserAccounts.Location = new System.Drawing.Point(0, 260);
            this.btnUserAccounts.Name = "btnUserAccounts";
            this.btnUserAccounts.Size = new System.Drawing.Size(200, 40);
            this.btnUserAccounts.TabIndex = 4;
            this.btnUserAccounts.Text = "User Accounts";
            this.btnUserAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserAccounts.UseVisualStyleBackColor = false;
            this.btnUserAccounts.Click += new System.EventHandler(this.btnUserAccounts_Click);

            // btnAboutLicense
            this.btnAboutLicense.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAboutLicense.FlatAppearance.BorderSize = 0;
            this.btnAboutLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAboutLicense.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAboutLicense.ForeColor = System.Drawing.Color.White;
            this.btnAboutLicense.Location = new System.Drawing.Point(0, 300);
            this.btnAboutLicense.Name = "btnAboutLicense";
            this.btnAboutLicense.Size = new System.Drawing.Size(200, 40);
            this.btnAboutLicense.TabIndex = 5;
            this.btnAboutLicense.Text = "About && Licensure";
            this.btnAboutLicense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAboutLicense.UseVisualStyleBackColor = false;
            this.btnAboutLicense.Click += new System.EventHandler(this.btnAboutLicense_Click);

            // btnLogout
            this.btnLogout.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 650);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(200, 40);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlHeader.Controls.Add(this.lblClinicName);
            this.pnlHeader.Controls.Add(this.lblAddress1);
            this.pnlHeader.Controls.Add(this.lblAddress2);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(200, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 80);
            this.pnlHeader.TabIndex = 1;

            // lblClinicName
            this.lblClinicName.AutoSize = true;
            this.lblClinicName.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClinicName.ForeColor = System.Drawing.Color.White;
            this.lblClinicName.Location = new System.Drawing.Point(300, 10);
            this.lblClinicName.Name = "lblClinicName";
            this.lblClinicName.Size = new System.Drawing.Size(300, 29);
            this.lblClinicName.TabIndex = 0;
            this.lblClinicName.Text = "ROMAN MEDICAL CLINIC";

            // lblAddress1
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress1.ForeColor = System.Drawing.Color.White;
            this.lblAddress1.Location = new System.Drawing.Point(365, 40);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(170, 16);
            this.lblAddress1.TabIndex = 1;
            this.lblAddress1.Text = "Rizal, Imatong Pililla Rizal";

            // lblAddress2
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress2.ForeColor = System.Drawing.Color.White;
            this.lblAddress2.Location = new System.Drawing.Point(370, 56);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(160, 16);
            this.lblAddress2.TabIndex = 2;
            this.lblAddress2.Text = "Rizal, Philippines, 1910";

            // pnlMain
            this.pnlMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.Controls.Add(this.lblFormTitle);
            this.pnlMain.Controls.Add(this.pnlConsultationDetails);
            this.pnlMain.Controls.Add(this.tabConsultation);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(200, 80);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(900, 620);
            this.pnlMain.TabIndex = 2;

            // lblFormTitle
            this.lblFormTitle.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFormTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(10, 10);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(880, 30);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "ADULT CONSULTATION";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlConsultationDetails
            this.pnlConsultationDetails.BackColor = System.Drawing.Color.White;
            this.pnlConsultationDetails.Controls.Add(this.lblConsultationDetails);
            this.pnlConsultationDetails.Controls.Add(this.lblSurname);
            this.pnlConsultationDetails.Controls.Add(this.txtSurname);
            this.pnlConsultationDetails.Controls.Add(this.lblGivenName);
            this.pnlConsultationDetails.Controls.Add(this.txtGivenName);
            this.pnlConsultationDetails.Controls.Add(this.lblMiddleName);
            this.pnlConsultationDetails.Controls.Add(this.txtMiddleName);
            this.pnlConsultationDetails.Controls.Add(this.lblAge);
            this.pnlConsultationDetails.Controls.Add(this.txtAge);
            this.pnlConsultationDetails.Controls.Add(this.btnSave);
            this.pnlConsultationDetails.Controls.Add(this.btnCancel);
            this.pnlConsultationDetails.Location = new System.Drawing.Point(10, 45);
            this.pnlConsultationDetails.Name = "pnlConsultationDetails";
            this.pnlConsultationDetails.Size = new System.Drawing.Size(880, 70);
            this.pnlConsultationDetails.TabIndex = 1;

            // lblConsultationDetails
            this.lblConsultationDetails.AutoSize = true;
            this.lblConsultationDetails.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultationDetails.ForeColor = System.Drawing.Color.Gray;
            this.lblConsultationDetails.Location = new System.Drawing.Point(10, 10);
            this.lblConsultationDetails.Name = "lblConsultationDetails";
            this.lblConsultationDetails.Size = new System.Drawing.Size(150, 15);
            this.lblConsultationDetails.TabIndex = 0;
            this.lblConsultationDetails.Text = "CONSULTATION DETAILS";

            // lblSurname
            this.lblSurname.AutoSize = true;
            this.lblSurname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurname.Location = new System.Drawing.Point(10, 35);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(66, 15);
            this.lblSurname.TabIndex = 1;
            this.lblSurname.Text = "SURNAME";

            // txtSurname
            this.txtSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSurname.Enabled = false;
            this.txtSurname.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurname.Location = new System.Drawing.Point(120, 33);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(120, 22);
            this.txtSurname.TabIndex = 2;

            // lblGivenName
            this.lblGivenName.AutoSize = true;
            this.lblGivenName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGivenName.Location = new System.Drawing.Point(250, 35);
            this.lblGivenName.Name = "lblGivenName";
            this.lblGivenName.Size = new System.Drawing.Size(80, 15);
            this.lblGivenName.TabIndex = 3;
            this.lblGivenName.Text = "GIVEN NAME";

            // txtGivenName
            this.txtGivenName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGivenName.Enabled = false;
            this.txtGivenName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGivenName.Location = new System.Drawing.Point(330, 33);
            this.txtGivenName.Name = "txtGivenName";
            this.txtGivenName.Size = new System.Drawing.Size(120, 22);
            this.txtGivenName.TabIndex = 4;

            // lblMiddleName
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddleName.Location = new System.Drawing.Point(460, 35);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(90, 15);
            this.lblMiddleName.TabIndex = 5;
            this.lblMiddleName.Text = "MIDDLE NAME";

            // txtMiddleName
            this.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMiddleName.Enabled = false;
            this.txtMiddleName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiddleName.Location = new System.Drawing.Point(550, 33);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(60, 22);
            this.txtMiddleName.TabIndex = 6;

            // lblAge
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(620, 35);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(30, 15);
            this.lblAge.TabIndex = 7;
            this.lblAge.Text = "AGE";

            // txtAge
            this.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAge.Enabled = false;
            this.txtAge.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(650, 33);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(40, 22);
            this.txtAge.TabIndex = 8;

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(725, 30);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(800, 30);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // tabConsultation
            this.tabConsultation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabConsultation.Controls.Add(this.tabPage1);
            this.tabConsultation.Controls.Add(this.tabPage2);
            this.tabConsultation.Controls.Add(this.tabPage3);
            this.tabConsultation.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabConsultation.Location = new System.Drawing.Point(10, 120);
            this.tabConsultation.Name = "tabConsultation";
            this.tabConsultation.SelectedIndex = 0;
            this.tabConsultation.Size = new System.Drawing.Size(880, 450);
            this.tabConsultation.TabIndex = 3;

            // tabPage1
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.lblMedications);
            this.tabPage1.Controls.Add(this.txtMedications);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(872, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Page 1";

            // lblMedications
            this.lblMedications.AutoSize = true;
            this.lblMedications.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedications.Location = new System.Drawing.Point(10, 10);
            this.lblMedications.Name = "lblMedications";
            this.lblMedications.Size = new System.Drawing.Size(94, 16);
            this.lblMedications.TabIndex = 0;
            this.lblMedications.Text = "MEDICATIONS";

            // txtMedications
            this.txtMedications.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMedications.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMedications.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedications.Location = new System.Drawing.Point(10, 30);
            this.txtMedications.Multiline = true;
            this.txtMedications.Name = "txtMedications";
            this.txtMedications.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMedications.Size = new System.Drawing.Size(852, 382);
            this.txtMedications.TabIndex = 1;

            // tabPage2
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.lblPhysicalExamination);
            this.tabPage2.Controls.Add(this.txtPhysicalExamination);
            this.tabPage2.Controls.Add(this.lblDiagnosis);
            this.tabPage2.Controls.Add(this.txtDiagnosis);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(872, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Page 2";

            // lblPhysicalExamination
            this.lblPhysicalExamination.AutoSize = true;
            this.lblPhysicalExamination.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhysicalExamination.Location = new System.Drawing.Point(10, 10);
            this.lblPhysicalExamination.Name = "lblPhysicalExamination";
            this.lblPhysicalExamination.Size = new System.Drawing.Size(230, 16);
            this.lblPhysicalExamination.TabIndex = 0;
            this.lblPhysicalExamination.Text = "PERTINENT PHYSICAL EXAMINATION";

            // txtPhysicalExamination
            this.txtPhysicalExamination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhysicalExamination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhysicalExamination.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhysicalExamination.Location = new System.Drawing.Point(10, 30);
            this.txtPhysicalExamination.Multiline = true;
            this.txtPhysicalExamination.Name = "txtPhysicalExamination";
            this.txtPhysicalExamination.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPhysicalExamination.Size = new System.Drawing.Size(852, 180);
            this.txtPhysicalExamination.TabIndex = 1;

            // lblDiagnosis
            this.lblDiagnosis.AutoSize = true;
            this.lblDiagnosis.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiagnosis.Location = new System.Drawing.Point(10, 220);
            this.lblDiagnosis.Name = "lblDiagnosis";
            this.lblDiagnosis.Size = new System.Drawing.Size(80, 16);
            this.lblDiagnosis.TabIndex = 2;
            this.lblDiagnosis.Text = "DIAGNOSIS";

            // txtDiagnosis
            this.txtDiagnosis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiagnosis.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiagnosis.Location = new System.Drawing.Point(10, 240);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnosis.Size = new System.Drawing.Size(852, 172);
            this.txtDiagnosis.TabIndex = 3;

            // tabPage3
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.pnlVaccination);
            this.tabPage3.Controls.Add(this.pnlHistory);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(872, 422);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Page 3";

            // pnlVaccination
            this.pnlVaccination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlVaccination.Controls.Add(this.lblVaccination);
            this.pnlVaccination.Controls.Add(this.chkCovidVaccine);
            this.pnlVaccination.Controls.Add(this.chkHepatitisB);
            this.pnlVaccination.Controls.Add(this.chkRotavirus);
            this.pnlVaccination.Controls.Add(this.chkDiphtheria);
            this.pnlVaccination.Controls.Add(this.chkHaemophilus);
            this.pnlVaccination.Controls.Add(this.chkPneumococcal);
            this.pnlVaccination.Controls.Add(this.chkPoliovirus);
            this.pnlVaccination.Controls.Add(this.chkInfluenza);
            this.pnlVaccination.Controls.Add(this.chkMMR);
            this.pnlVaccination.Controls.Add(this.chkVaricella);
            this.pnlVaccination.Controls.Add(this.chkHepatitisA);
            this.pnlVaccination.Controls.Add(this.chkMeningococcal);
            this.pnlVaccination.Controls.Add(this.lblPastMedicalHistory);
            this.pnlVaccination.Controls.Add(this.txtPastMedicalHistory);
            this.pnlVaccination.Location = new System.Drawing.Point(10, 10);
            this.pnlVaccination.Name = "pnlVaccination";
            this.pnlVaccination.Size = new System.Drawing.Size(300, 402);
            this.pnlVaccination.TabIndex = 0;

            // lblVaccination
            this.lblVaccination.AutoSize = true;
            this.lblVaccination.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVaccination.Location = new System.Drawing.Point(10, 10);
            this.lblVaccination.Name = "lblVaccination";
            this.lblVaccination.Size = new System.Drawing.Size(95, 16);
            this.lblVaccination.TabIndex = 0;
            this.lblVaccination.Text = "VACCINATION";

            // chkCovidVaccine
            this.chkCovidVaccine.AutoSize = true;
            this.chkCovidVaccine.Location = new System.Drawing.Point(10, 40);
            this.chkCovidVaccine.Name = "chkCovidVaccine";
            this.chkCovidVaccine.Size = new System.Drawing.Size(110, 19);
            this.chkCovidVaccine.TabIndex = 1;
            this.chkCovidVaccine.Text = "COVID Vaccines";
            this.chkCovidVaccine.UseVisualStyleBackColor = true;

            // chkHepatitisB
            this.chkHepatitisB.AutoSize = true;
            this.chkHepatitisB.Location = new System.Drawing.Point(10, 65);
            this.chkHepatitisB.Name = "chkHepatitisB";
            this.chkHepatitisB.Size = new System.Drawing.Size(85, 19);
            this.chkHepatitisB.TabIndex = 2;
            this.chkHepatitisB.Text = "Hepatitis B";
            this.chkHepatitisB.UseVisualStyleBackColor = true;

            // chkRotavirus
            this.chkRotavirus.AutoSize = true;
            this.chkRotavirus.Location = new System.Drawing.Point(10, 90);
            this.chkRotavirus.Name = "chkRotavirus";
            this.chkRotavirus.Size = new System.Drawing.Size(77, 19);
            this.chkRotavirus.TabIndex = 3;
            this.chkRotavirus.Text = "Rotavirus";
            this.chkRotavirus.UseVisualStyleBackColor = true;

            // chkDiphtheria
            this.chkDiphtheria.AutoSize = true;
            this.chkDiphtheria.Location = new System.Drawing.Point(10, 115);
            this.chkDiphtheria.Name = "chkDiphtheria";
            this.chkDiphtheria.Size = new System.Drawing.Size(199, 19);
            this.chkDiphtheria.TabIndex = 4;
            this.chkDiphtheria.Text = "Diphtheria, Tetanus, Pertussis";
            this.chkDiphtheria.UseVisualStyleBackColor = true;

            // chkHaemophilus
            this.chkHaemophilus.AutoSize = true;
            this.chkHaemophilus.Location = new System.Drawing.Point(10, 140);
            this.chkHaemophilus.Name = "chkHaemophilus";
            this.chkHaemophilus.Size = new System.Drawing.Size(197, 19);
            this.chkHaemophilus.TabIndex = 5;
            this.chkHaemophilus.Text = "Haemophilus influenza B type";
            this.chkHaemophilus.UseVisualStyleBackColor = true;

            // chkPneumococcal
            this.chkPneumococcal.AutoSize = true;
            this.chkPneumococcal.Location = new System.Drawing.Point(10, 165);
            this.chkPneumococcal.Name = "chkPneumococcal";
            this.chkPneumococcal.Size = new System.Drawing.Size(111, 19);
            this.chkPneumococcal.TabIndex = 6;
            this.chkPneumococcal.Text = "Pneumococcal";
            this.chkPneumococcal.UseVisualStyleBackColor = true;

            // chkPoliovirus
            this.chkPoliovirus.AutoSize = true;
            this.chkPoliovirus.Location = new System.Drawing.Point(10, 190);
            this.chkPoliovirus.Name = "chkPoliovirus";
            this.chkPoliovirus.Size = new System.Drawing.Size(138, 19);
            this.chkPoliovirus.TabIndex = 7;
            this.chkPoliovirus.Text = "Inactivated Poliovirus";
            this.chkPoliovirus.UseVisualStyleBackColor = true;

            // chkInfluenza
            this.chkInfluenza.AutoSize = true;
            this.chkInfluenza.Location = new System.Drawing.Point(10, 215);
            this.chkInfluenza.Name = "chkInfluenza";
            this.chkInfluenza.Size = new System.Drawing.Size(78, 19);
            this.chkInfluenza.TabIndex = 8;
            this.chkInfluenza.Text = "Influenza";
            this.chkInfluenza.UseVisualStyleBackColor = true;

            // chkMMR
            this.chkMMR.AutoSize = true;
            this.chkMMR.Location = new System.Drawing.Point(10, 240);
            this.chkMMR.Name = "chkMMR";
            this.chkMMR.Size = new System.Drawing.Size(188, 19);
            this.chkMMR.TabIndex = 9;
            this.chkMMR.Text = "Measles, Mumps, Rubella";
            this.chkMMR.UseVisualStyleBackColor = true;

            // chkVaricella
            this.chkVaricella.AutoSize = true;
            this.chkVaricella.Location = new System.Drawing.Point(10, 265);
            this.chkVaricella.Name = "chkVaricella";
            this.chkVaricella.Size = new System.Drawing.Size(75, 19);
            this.chkVaricella.TabIndex = 10;
            this.chkVaricella.Text = "Varicella";
            this.chkVaricella.UseVisualStyleBackColor = true;

            // chkHepatitisA
            this.chkHepatitisA.AutoSize = true;
            this.chkHepatitisA.Location = new System.Drawing.Point(10, 290);
            this.chkHepatitisA.Name = "chkHepatitisA";
            this.chkHepatitisA.Size = new System.Drawing.Size(85, 19);
            this.chkHepatitisA.TabIndex = 11;
            this.chkHepatitisA.Text = "Hepatitis A";
            this.chkHepatitisA.UseVisualStyleBackColor = true;

            // chkMeningococcal
            this.chkMeningococcal.AutoSize = true;
            this.chkMeningococcal.Location = new System.Drawing.Point(10, 315);
            this.chkMeningococcal.Name = "chkMeningococcal";
            this.chkMeningococcal.Size = new System.Drawing.Size(116, 19);
            this.chkMeningococcal.TabIndex = 12;
            this.chkMeningococcal.Text = "Meningococcal";
            this.chkMeningococcal.UseVisualStyleBackColor = true;

            // lblPastMedicalHistory
            this.lblPastMedicalHistory.AutoSize = true;
            this.lblPastMedicalHistory.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPastMedicalHistory.Location = new System.Drawing.Point(10, 340);
            this.lblPastMedicalHistory.Name = "lblPastMedicalHistory";
            this.lblPastMedicalHistory.Size = new System.Drawing.Size(147, 16);
            this.lblPastMedicalHistory.TabIndex = 13;
            this.lblPastMedicalHistory.Text = "PAST MEDICAL HISTORY";

            // txtPastMedicalHistory
            this.txtPastMedicalHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPastMedicalHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPastMedicalHistory.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPastMedicalHistory.Location = new System.Drawing.Point(10, 360);
            this.txtPastMedicalHistory.Multiline = true;
            this.txtPastMedicalHistory.Name = "txtPastMedicalHistory";
            this.txtPastMedicalHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPastMedicalHistory.Size = new System.Drawing.Size(280, 32);
            this.txtPastMedicalHistory.TabIndex = 14;

            // pnlHistory
            this.pnlHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHistory.Controls.Add(this.lblChiefComplaint);
            this.pnlHistory.Controls.Add(this.txtChiefComplaint);
            this.pnlHistory.Controls.Add(this.lblHistory);
            this.pnlHistory.Controls.Add(this.txtHistory);
            this.pnlHistory.Location = new System.Drawing.Point(320, 10);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(542, 402);
            this.pnlHistory.TabIndex = 1;

            // lblChiefComplaint
            this.lblChiefComplaint.AutoSize = true;
            this.lblChiefComplaint.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChiefComplaint.Location = new System.Drawing.Point(10, 10);
            this.lblChiefComplaint.Name = "lblChiefComplaint";
            this.lblChiefComplaint.Size = new System.Drawing.Size(132, 16);
            this.lblChiefComplaint.TabIndex = 0;
            this.lblChiefComplaint.Text = "CHIEF COMPLAINT";

            // txtChiefComplaint
            this.txtChiefComplaint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChiefComplaint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChiefComplaint.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChiefComplaint.Location = new System.Drawing.Point(10, 30);
            this.txtChiefComplaint.Multiline = true;
            this.txtChiefComplaint.Name = "txtChiefComplaint";
            this.txtChiefComplaint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChiefComplaint.Size = new System.Drawing.Size(522, 150);
            this.txtChiefComplaint.TabIndex = 1;

            // lblHistory
            this.lblHistory.AutoSize = true;
            this.lblHistory.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistory.Location = new System.Drawing.Point(10, 190);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(67, 16);
            this.lblHistory.TabIndex = 2;
            this.lblHistory.Text = "HISTORY";

            // txtHistory
            this.txtHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHistory.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHistory.Location = new System.Drawing.Point(10, 210);
            this.txtHistory.Multiline = true;
            this.txtHistory.Name = "txtHistory";
            this.txtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHistory.Size = new System.Drawing.Size(522, 182);
            this.txtHistory.TabIndex = 3;

            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFooter.Controls.Add(this.lblLoginInfo);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(10, 580);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(880, 30);
            this.pnlFooter.TabIndex = 4;

            // lblLoginInfo
            this.lblLoginInfo.AutoSize = true;
            this.lblLoginInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblLoginInfo.Location = new System.Drawing.Point(10, 10);
            this.lblLoginInfo.Name = "lblLoginInfo";
            this.lblLoginInfo.Size = new System.Drawing.Size(542, 14);
            this.lblLoginInfo.TabIndex = 0;
            this.lblLoginInfo.Text = "Login As: Admin | Username: IAN | Fullname: Ian Phillip C Roman | Copyright 2023 | All Rights Reserved";

            // Form4
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roman Medical Clinic - Adult Consultation";
            this.Load += new System.EventHandler(this.Form4_Load);

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlConsultationDetails.ResumeLayout(false);
            this.pnlConsultationDetails.PerformLayout();
            this.tabConsultation.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.pnlVaccination.ResumeLayout(false);
            this.pnlVaccination.PerformLayout();
            this.pnlHistory.ResumeLayout(false);
            this.pnlHistory.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Button btnPediaMedRecords;
        private System.Windows.Forms.Button btnAdultMedRecords;
        private System.Windows.Forms.Button btnUserAccounts;
        private System.Windows.Forms.Button btnAboutLicense;
        private System.Windows.Forms.Button btnLogout;

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblClinicName;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.Label lblAddress2;

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Panel pnlConsultationDetails;
        private System.Windows.Forms.Label lblConsultationDetails;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label lblGivenName;
        private System.Windows.Forms.TextBox txtGivenName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        private System.Windows.Forms.TabControl tabConsultation;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblMedications;
        private System.Windows.Forms.TextBox txtMedications;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblPhysicalExamination;
        private System.Windows.Forms.TextBox txtPhysicalExamination;
        private System.Windows.Forms.Label lblDiagnosis;
        private System.Windows.Forms.TextBox txtDiagnosis;
        private System.Windows.Forms.TabPage tabPage3;

        private System.Windows.Forms.Panel pnlVaccination;
        private System.Windows.Forms.Label lblVaccination;
        private System.Windows.Forms.CheckBox chkCovidVaccine;
        private System.Windows.Forms.CheckBox chkHepatitisB;
        private System.Windows.Forms.CheckBox chkRotavirus;
        private System.Windows.Forms.CheckBox chkDiphtheria;
        private System.Windows.Forms.CheckBox chkHaemophilus;
        private System.Windows.Forms.CheckBox chkPneumococcal;
        private System.Windows.Forms.CheckBox chkPoliovirus;
        private System.Windows.Forms.CheckBox chkInfluenza;
        private System.Windows.Forms.CheckBox chkMMR;
        private System.Windows.Forms.CheckBox chkVaricella;
        private System.Windows.Forms.CheckBox chkHepatitisA;
        private System.Windows.Forms.CheckBox chkMeningococcal;
        private System.Windows.Forms.Label lblPastMedicalHistory;
        private System.Windows.Forms.TextBox txtPastMedicalHistory;

        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.Label lblChiefComplaint;
        private System.Windows.Forms.TextBox txtChiefComplaint;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.TextBox txtHistory;

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblLoginInfo;
    }
}