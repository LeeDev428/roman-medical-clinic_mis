namespace roman_medical_clinic_mis
{
    partial class Form3
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

            // Main panels
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

            // Header controls
            this.lblClinicName = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();

            // Main content - Patient Info panel
            this.pnlPatientInfo = new System.Windows.Forms.Panel();
            this.lblAdultPatient = new System.Windows.Forms.Label();
            this.lblPersonalInfo = new System.Windows.Forms.Label();

            // Personal Info fields
            this.lblSurname = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.lblGivenName = new System.Windows.Forms.Label();
            this.txtGivenName = new System.Windows.Forms.TextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblConsultDate = new System.Windows.Forms.Label();
            this.dtpConsultDate = new System.Windows.Forms.DateTimePicker();

            // Action buttons
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReconsultation = new System.Windows.Forms.Button();
            this.btnPrescriptions = new System.Windows.Forms.Button();
   

            // Patient History panel
            this.pnlPatientHistory = new System.Windows.Forms.Panel();
            this.lblPatientHistory = new System.Windows.Forms.Label();
            this.lblSearchBy = new System.Windows.Forms.Label();

            // Search fields
            this.lblSearchName = new System.Windows.Forms.Label();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.lblSearchConsultDate = new System.Windows.Forms.Label();
            this.dtpSearchConsult = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();

            // DataGridView for patient records
            this.dgvPatients = new System.Windows.Forms.DataGridView();

            // Counts panel
            this.pnlCounts = new System.Windows.Forms.Panel();
            this.lblCounts = new System.Windows.Forms.Label();
            this.lblTotalPatients = new System.Windows.Forms.Label();

            // Initialize containers
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlPatientInfo.SuspendLayout();
            this.pnlPatientHistory.SuspendLayout();
            this.pnlCounts.SuspendLayout();
            this.SuspendLayout();

            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.MidnightBlue;
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

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlHeader.Controls.Add(this.lblClinicName);
            this.pnlHeader.Controls.Add(this.lblAddress1);
            this.pnlHeader.Controls.Add(this.lblAddress2);
            this.pnlHeader.Controls.Add(this.btnClose);
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

            // btnClose
            this.btnClose.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.FlatAppearance.BorderSize = 1;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(860, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // pnlMain
            this.pnlMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.Controls.Add(this.pnlPatientInfo);
            this.pnlMain.Controls.Add(this.pnlPatientHistory);
            this.pnlMain.Controls.Add(this.pnlCounts);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(200, 80);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(900, 620);
            this.pnlMain.TabIndex = 2;

            // pnlPatientInfo
            this.pnlPatientInfo.BackColor = System.Drawing.Color.White;
            this.pnlPatientInfo.Controls.Add(this.btnPrescriptions);
            this.pnlPatientInfo.Controls.Add(this.btnReconsultation);
            this.pnlPatientInfo.Controls.Add(this.btnDelete);
            this.pnlPatientInfo.Controls.Add(this.btnCancel);
            this.pnlPatientInfo.Controls.Add(this.btnUpdate);
            this.pnlPatientInfo.Controls.Add(this.btnSave);
          
          
            this.pnlPatientInfo.Controls.Add(this.lblAdultPatient);
            this.pnlPatientInfo.Controls.Add(this.lblPersonalInfo);
            this.pnlPatientInfo.Controls.Add(this.lblSurname);
            this.pnlPatientInfo.Controls.Add(this.txtSurname);
            this.pnlPatientInfo.Controls.Add(this.lblGivenName);
            this.pnlPatientInfo.Controls.Add(this.txtGivenName);
            this.pnlPatientInfo.Controls.Add(this.lblMiddleName);
            this.pnlPatientInfo.Controls.Add(this.txtMiddleName);
            this.pnlPatientInfo.Controls.Add(this.lblAddress);
            this.pnlPatientInfo.Controls.Add(this.txtAddress);
            this.pnlPatientInfo.Controls.Add(this.lblSex);
            this.pnlPatientInfo.Controls.Add(this.cmbSex);
            this.pnlPatientInfo.Controls.Add(this.lblBirthdate);
            this.pnlPatientInfo.Controls.Add(this.dtpBirthdate);
            this.pnlPatientInfo.Controls.Add(this.lblAge);
            this.pnlPatientInfo.Controls.Add(this.txtAge);
            this.pnlPatientInfo.Controls.Add(this.lblConsultDate);
            this.pnlPatientInfo.Controls.Add(this.dtpConsultDate);
            this.pnlPatientInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPatientInfo.Location = new System.Drawing.Point(10, 10);
            this.pnlPatientInfo.Name = "pnlPatientInfo";
            this.pnlPatientInfo.Size = new System.Drawing.Size(880, 180);
            this.pnlPatientInfo.TabIndex = 0;

            // lblAdultPatient
            this.lblAdultPatient.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblAdultPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAdultPatient.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblAdultPatient.ForeColor = System.Drawing.Color.White;
            this.lblAdultPatient.Location = new System.Drawing.Point(0, 0);
            this.lblAdultPatient.Name = "lblAdultPatient";
            this.lblAdultPatient.Size = new System.Drawing.Size(880, 30);
            this.lblAdultPatient.TabIndex = 0;
            this.lblAdultPatient.Text = "ADULT MEDICAL RECORDS";
            this.lblAdultPatient.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblPersonalInfo
            this.lblPersonalInfo.AutoSize = true;
            this.lblPersonalInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonalInfo.Location = new System.Drawing.Point(10, 40);
            this.lblPersonalInfo.Name = "lblPersonalInfo";
            this.lblPersonalInfo.Size = new System.Drawing.Size(150, 15);
            this.lblPersonalInfo.TabIndex = 1;
            this.lblPersonalInfo.Text = "PERSONAL INFORMATION";

            // lblSurname
            this.lblSurname.AutoSize = true;
            this.lblSurname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurname.Location = new System.Drawing.Point(10, 65);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(58, 15);
            this.lblSurname.TabIndex = 2;
            this.lblSurname.Text = "Surname";

            // txtSurname
            this.txtSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSurname.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSurname.Location = new System.Drawing.Point(10, 85);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(150, 22);
            this.txtSurname.TabIndex = 3;

            // lblGivenName
            this.lblGivenName.AutoSize = true;
            this.lblGivenName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGivenName.Location = new System.Drawing.Point(170, 65);
            this.lblGivenName.Name = "lblGivenName";
            this.lblGivenName.Size = new System.Drawing.Size(74, 15);
            this.lblGivenName.TabIndex = 4;
            this.lblGivenName.Text = "Given Name";

            // txtGivenName
            this.txtGivenName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGivenName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGivenName.Location = new System.Drawing.Point(170, 85);
            this.txtGivenName.Name = "txtGivenName";
            this.txtGivenName.Size = new System.Drawing.Size(150, 22);
            this.txtGivenName.TabIndex = 5;

            // lblMiddleName
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddleName.Location = new System.Drawing.Point(330, 65);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(80, 15);
            this.lblMiddleName.TabIndex = 6;
            this.lblMiddleName.Text = "Middle Name";

            // txtMiddleName
            this.txtMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMiddleName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiddleName.Location = new System.Drawing.Point(330, 85);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(150, 22);
            this.txtMiddleName.TabIndex = 7;

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(490, 65);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(54, 15);
            this.lblAddress.TabIndex = 8;
            this.lblAddress.Text = "Address";

            // txtAddress
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(490, 85);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 22);
            this.txtAddress.TabIndex = 9;

            // lblSex
            this.lblSex.AutoSize = true;
            this.lblSex.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSex.Location = new System.Drawing.Point(700, 65);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(28, 15);
            this.lblSex.TabIndex = 10;
            this.lblSex.Text = "Sex";

            // cmbSex
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Items.AddRange(new object[] { "SELECT", "Male", "Female" });
            this.cmbSex.Location = new System.Drawing.Point(700, 85);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(80, 24);
            this.cmbSex.TabIndex = 11;

            // lblBirthdate
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthdate.Location = new System.Drawing.Point(790, 65);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(56, 15);
            this.lblBirthdate.TabIndex = 12;
            this.lblBirthdate.Text = "Birthdate";

            // dtpBirthdate
            this.dtpBirthdate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpBirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthdate.Location = new System.Drawing.Point(790, 85);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(80, 22);
            this.dtpBirthdate.TabIndex = 13;
            this.dtpBirthdate.ValueChanged += new System.EventHandler(this.dtpBirthdate_ValueChanged);

            // lblAge
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(10, 115);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(28, 15);
            this.lblAge.TabIndex = 14;
            this.lblAge.Text = "Age";

            // txtAge
            this.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAge.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAge.Location = new System.Drawing.Point(10, 135);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(60, 22);
            this.txtAge.TabIndex = 15;

            // lblConsultDate
            this.lblConsultDate.AutoSize = true;
            this.lblConsultDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultDate.Location = new System.Drawing.Point(80, 115);
            this.lblConsultDate.Name = "lblConsultDate";
            this.lblConsultDate.Size = new System.Drawing.Size(110, 15);
            this.lblConsultDate.TabIndex = 16;
            this.lblConsultDate.Text = "Date of Consultation";

            // dtpConsultDate
            this.dtpConsultDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpConsultDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpConsultDate.Location = new System.Drawing.Point(80, 135);
            this.dtpConsultDate.Name = "dtpConsultDate";
            this.dtpConsultDate.Size = new System.Drawing.Size(110, 22);
            this.dtpConsultDate.TabIndex = 17;

            // btnSave
            this.btnSave.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(610, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);


            // btnCancel
            this.btnCancel.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(790, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // btnUpdate
            this.btnUpdate.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(510, 135);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(80, 30);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(410, 135);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnReconsultation
            this.btnReconsultation.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnReconsultation.FlatAppearance.BorderSize = 0;
            this.btnReconsultation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReconsultation.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReconsultation.ForeColor = System.Drawing.Color.White;
            this.btnReconsultation.Location = new System.Drawing.Point(310, 135);
            this.btnReconsultation.Name = "btnReconsultation";
            this.btnReconsultation.Size = new System.Drawing.Size(80, 30);
            this.btnReconsultation.TabIndex = 23;
            this.btnReconsultation.Text = "RECONSULT";
            this.btnReconsultation.UseVisualStyleBackColor = false;
            this.btnReconsultation.Click += new System.EventHandler(this.btnReconsultation_Click);

            // btnPrescriptions
            this.btnPrescriptions.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnPrescriptions.FlatAppearance.BorderSize = 0;
            this.btnPrescriptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrescriptions.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrescriptions.ForeColor = System.Drawing.Color.White;
            this.btnPrescriptions.Location = new System.Drawing.Point(210, 135);
            this.btnPrescriptions.Name = "btnPrescriptions";
            this.btnPrescriptions.Size = new System.Drawing.Size(80, 30);
            this.btnPrescriptions.TabIndex = 24;
            this.btnPrescriptions.Text = "PRESCRI";
            this.btnPrescriptions.UseVisualStyleBackColor = false;
            this.btnPrescriptions.Click += new System.EventHandler(this.btnPrescriptions_Click);

         


            // pnlPatientHistory
            this.pnlPatientHistory.BackColor = System.Drawing.Color.White;
            this.pnlPatientHistory.Controls.Add(this.lblPatientHistory);
            this.pnlPatientHistory.Controls.Add(this.lblSearchBy);
            this.pnlPatientHistory.Controls.Add(this.lblSearchName);
            this.pnlPatientHistory.Controls.Add(this.txtSearchName);
            this.pnlPatientHistory.Controls.Add(this.lblSearchConsultDate);
            this.pnlPatientHistory.Controls.Add(this.dtpSearchConsult);
            this.pnlPatientHistory.Controls.Add(this.lblFromDate);
            this.pnlPatientHistory.Controls.Add(this.dtpFromDate);
            this.pnlPatientHistory.Controls.Add(this.lblToDate);
            this.pnlPatientHistory.Controls.Add(this.dtpToDate);
            this.pnlPatientHistory.Controls.Add(this.dgvPatients);
            this.pnlPatientHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPatientHistory.Location = new System.Drawing.Point(10, 190);
            this.pnlPatientHistory.Name = "pnlPatientHistory";
            this.pnlPatientHistory.Size = new System.Drawing.Size(880, 370);
            this.pnlPatientHistory.TabIndex = 1;

            // lblPatientHistory
            this.lblPatientHistory.AutoSize = true;
            this.lblPatientHistory.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientHistory.Location = new System.Drawing.Point(10, 10);
            this.lblPatientHistory.Name = "lblPatientHistory";
            this.lblPatientHistory.Size = new System.Drawing.Size(127, 15);
            this.lblPatientHistory.TabIndex = 0;
            this.lblPatientHistory.Text = "ADULT PATIENT HISTORY";

            // lblSearchBy
            this.lblSearchBy.AutoSize = true;
            this.lblSearchBy.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchBy.Location = new System.Drawing.Point(10, 30);
            this.lblSearchBy.Name = "lblSearchBy";
            this.lblSearchBy.Size = new System.Drawing.Size(65, 15);
            this.lblSearchBy.TabIndex = 1;
            this.lblSearchBy.Text = "SEARCH BY";

            // lblSearchName
            this.lblSearchName.AutoSize = true;
            this.lblSearchName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchName.Location = new System.Drawing.Point(10, 50);
            this.lblSearchName.Name = "lblSearchName";
            this.lblSearchName.Size = new System.Drawing.Size(41, 15);
            this.lblSearchName.TabIndex = 2;
            this.lblSearchName.Text = "Name";

            // txtSearchName
            this.txtSearchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchName.Location = new System.Drawing.Point(10, 70);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(350, 22);
            this.txtSearchName.TabIndex = 3;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);

            // lblSearchConsultDate
            this.lblSearchConsultDate.AutoSize = true;
            this.lblSearchConsultDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchConsultDate.Location = new System.Drawing.Point(370, 50);
            this.lblSearchConsultDate.Name = "lblSearchConsultDate";
            this.lblSearchConsultDate.Size = new System.Drawing.Size(110, 15);
            this.lblSearchConsultDate.TabIndex = 4;
            this.lblSearchConsultDate.Text = "Date of Consultation";

            // dtpSearchConsult
            this.dtpSearchConsult.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSearchConsult.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSearchConsult.Location = new System.Drawing.Point(370, 70);
            this.dtpSearchConsult.Name = "dtpSearchConsult";
            this.dtpSearchConsult.Size = new System.Drawing.Size(110, 22);
            this.dtpSearchConsult.TabIndex = 5;
            this.dtpSearchConsult.ValueChanged += new System.EventHandler(this.dtpSearchConsult_ValueChanged);

            // lblFromDate
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Location = new System.Drawing.Point(490, 50);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(65, 15);
            this.lblFromDate.TabIndex = 6;
            this.lblFromDate.Text = "From Date";

            // dtpFromDate
            this.dtpFromDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(490, 70);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(110, 22);
            this.dtpFromDate.TabIndex = 7;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);

            // lblToDate
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.Location = new System.Drawing.Point(610, 50);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(48, 15);
            this.lblToDate.TabIndex = 8;
            this.lblToDate.Text = "To Date";

            // dtpToDate
            this.dtpToDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(610, 70);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(110, 22);
            this.dtpToDate.TabIndex = 9;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);

            // dgvPatients
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.Location = new System.Drawing.Point(10, 100);
            this.dgvPatients.MultiSelect = false;
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPatients.Size = new System.Drawing.Size(860, 260);
            this.dgvPatients.TabIndex = 10;
            this.dgvPatients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatients_CellDoubleClick);

            // pnlCounts
            this.pnlCounts.BackColor = System.Drawing.Color.White;
            this.pnlCounts.Controls.Add(this.lblCounts);
            this.pnlCounts.Controls.Add(this.lblTotalPatients);
            this.pnlCounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCounts.Location = new System.Drawing.Point(10, 560);
            this.pnlCounts.Name = "pnlCounts";
            this.pnlCounts.Size = new System.Drawing.Size(880, 50);
            this.pnlCounts.TabIndex = 2;

            // lblCounts
            this.lblCounts.AutoSize = true;
            this.lblCounts.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounts.Location = new System.Drawing.Point(10, 10);
            this.lblCounts.Name = "lblCounts";
            this.lblCounts.Size = new System.Drawing.Size(55, 15);
            this.lblCounts.TabIndex = 0;
            this.lblCounts.Text = "COUNTS";

            // lblTotalPatients
            this.lblTotalPatients.AutoSize = true;
            this.lblTotalPatients.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPatients.Location = new System.Drawing.Point(10, 30);
            this.lblTotalPatients.Name = "lblTotalPatients";
            this.lblTotalPatients.Size = new System.Drawing.Size(163, 15);
            this.lblTotalPatients.TabIndex = 1;
            this.lblTotalPatients.Text = "Total No. of Adult Patients: 0";

            // Form3
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roman Medical Clinic - Adult Medical Records";
            this.Load += new System.EventHandler(this.Form3_Load);

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlPatientInfo.ResumeLayout(false);
            this.pnlPatientInfo.PerformLayout();
            this.pnlPatientHistory.ResumeLayout(false);
            this.pnlPatientHistory.PerformLayout();
            this.pnlCounts.ResumeLayout(false);
            this.pnlCounts.PerformLayout();
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

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblClinicName;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Button btnClose;

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlPatientInfo;
        private System.Windows.Forms.Label lblAdultPatient;
        private System.Windows.Forms.Label lblPersonalInfo;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label lblGivenName;
        private System.Windows.Forms.TextBox txtGivenName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblConsultDate;
        private System.Windows.Forms.DateTimePicker dtpConsultDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReconsultation;
        private System.Windows.Forms.Button btnPrescriptions;
       
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;

        private System.Windows.Forms.Panel pnlPatientHistory;
        private System.Windows.Forms.Label lblPatientHistory;
        private System.Windows.Forms.Label lblSearchBy;
        private System.Windows.Forms.Label lblSearchName;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label lblSearchConsultDate;
        private System.Windows.Forms.DateTimePicker dtpSearchConsult;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DataGridView dgvPatients;

        private System.Windows.Forms.Panel pnlCounts;
        private System.Windows.Forms.Label lblCounts;
        private System.Windows.Forms.Label lblTotalPatients;
    }
}