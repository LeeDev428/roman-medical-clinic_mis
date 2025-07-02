namespace roman_medical_clinic_mis
{
    partial class Form5
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

            // Main area controls - Welcome section
            this.pnlWelcome = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();

            // Patient count boxes
            this.pnlPediaCount = new System.Windows.Forms.Panel();
            this.lblPediaPatients = new System.Windows.Forms.Label();
            this.lblPediaCount = new System.Windows.Forms.Label();

            this.pnlAdultCount = new System.Windows.Forms.Panel();
            this.lblAdultPatients = new System.Windows.Forms.Label();
            this.lblAdultCount = new System.Windows.Forms.Label();

            // Account statistics boxes
            this.pnlUserAccounts = new System.Windows.Forms.Panel();
            this.lblUserAccounts = new System.Windows.Forms.Label();
            this.lblUserAccountsCount = new System.Windows.Forms.Label();

            this.pnlApprovedAccounts = new System.Windows.Forms.Panel();
            this.lblApprovedAccounts = new System.Windows.Forms.Label();
            this.lblApprovedCount = new System.Windows.Forms.Label();

            this.pnlPendingAccounts = new System.Windows.Forms.Panel();
            this.lblPendingAccounts = new System.Windows.Forms.Label();
            this.lblPendingCount = new System.Windows.Forms.Label();

            // Today's patients section
            this.pnlTodayPatients = new System.Windows.Forms.Panel();
            this.lblTodayPatients = new System.Windows.Forms.Label();
            this.dgvTodayPatients = new System.Windows.Forms.DataGridView();
            this.lblTotalToday = new System.Windows.Forms.Label();

            // Footer with login info
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblLoginInfo = new System.Windows.Forms.Label();

            // Initialize containers
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayPatients)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlWelcome.SuspendLayout();
            this.pnlPediaCount.SuspendLayout();
            this.pnlAdultCount.SuspendLayout();
            this.pnlUserAccounts.SuspendLayout();
            this.pnlApprovedAccounts.SuspendLayout();
            this.pnlPendingAccounts.SuspendLayout();
            this.pnlTodayPatients.SuspendLayout();
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
            this.lblDashboard.Click += new System.EventHandler(this.lblDashboard_Click);

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
            this.btnAdultMedRecords.BackColor = System.Drawing.Color.MidnightBlue;
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
            this.pnlMain.Controls.Add(this.pnlWelcome);
            this.pnlMain.Controls.Add(this.pnlPediaCount);
            this.pnlMain.Controls.Add(this.pnlAdultCount);
            this.pnlMain.Controls.Add(this.pnlUserAccounts);
            this.pnlMain.Controls.Add(this.pnlApprovedAccounts);
            this.pnlMain.Controls.Add(this.pnlPendingAccounts);
            this.pnlMain.Controls.Add(this.pnlTodayPatients);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(200, 80);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 620);
            this.pnlMain.TabIndex = 2;

            // pnlWelcome
            this.pnlWelcome.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlWelcome.Controls.Add(this.lblWelcome);
            this.pnlWelcome.Location = new System.Drawing.Point(20, 20);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(860, 60);
            this.pnlWelcome.TabIndex = 0;

            // lblWelcome
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(860, 60);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "HI IAN";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // pnlPediaCount
            this.pnlPediaCount.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlPediaCount.Controls.Add(this.lblPediaPatients);
            this.pnlPediaCount.Controls.Add(this.lblPediaCount);
            this.pnlPediaCount.Location = new System.Drawing.Point(170, 100);
            this.pnlPediaCount.Name = "pnlPediaCount";
            this.pnlPediaCount.Size = new System.Drawing.Size(230, 90);
            this.pnlPediaCount.TabIndex = 1;

            // lblPediaPatients
            this.lblPediaPatients.AutoSize = true;
            this.lblPediaPatients.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPediaPatients.ForeColor = System.Drawing.Color.White;
            this.lblPediaPatients.Location = new System.Drawing.Point(60, 15);
            this.lblPediaPatients.Name = "lblPediaPatients";
            this.lblPediaPatients.Size = new System.Drawing.Size(110, 19);
            this.lblPediaPatients.TabIndex = 0;
            this.lblPediaPatients.Text = "PEDIA PATIENTS";

            // lblPediaCount
            this.lblPediaCount.AutoSize = true;
            this.lblPediaCount.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPediaCount.ForeColor = System.Drawing.Color.White;
            this.lblPediaCount.Location = new System.Drawing.Point(85, 45);
            this.lblPediaCount.Name = "lblPediaCount";
            this.lblPediaCount.Size = new System.Drawing.Size(65, 37);
            this.lblPediaCount.TabIndex = 1;
            this.lblPediaCount.Text = "6454";

            // pnlAdultCount
            this.pnlAdultCount.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlAdultCount.Controls.Add(this.lblAdultPatients);
            this.pnlAdultCount.Controls.Add(this.lblAdultCount);
            this.pnlAdultCount.Location = new System.Drawing.Point(500, 100);
            this.pnlAdultCount.Name = "pnlAdultCount";
            this.pnlAdultCount.Size = new System.Drawing.Size(230, 90);
            this.pnlAdultCount.TabIndex = 2;

            // lblAdultPatients
            this.lblAdultPatients.AutoSize = true;
            this.lblAdultPatients.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdultPatients.ForeColor = System.Drawing.Color.White;
            this.lblAdultPatients.Location = new System.Drawing.Point(60, 15);
            this.lblAdultPatients.Name = "lblAdultPatients";
            this.lblAdultPatients.Size = new System.Drawing.Size(110, 19);
            this.lblAdultPatients.TabIndex = 0;
            this.lblAdultPatients.Text = "ADULT PATIENTS";

            // lblAdultCount
            this.lblAdultCount.AutoSize = true;
            this.lblAdultCount.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdultCount.ForeColor = System.Drawing.Color.White;
            this.lblAdultCount.Location = new System.Drawing.Point(85, 45);
            this.lblAdultCount.Name = "lblAdultCount";
            this.lblAdultCount.Size = new System.Drawing.Size(65, 37);
            this.lblAdultCount.TabIndex = 1;
            this.lblAdultCount.Text = "5514";

            // pnlUserAccounts
            this.pnlUserAccounts.BackColor = System.Drawing.Color.RoyalBlue;
            this.pnlUserAccounts.Controls.Add(this.lblUserAccounts);
            this.pnlUserAccounts.Controls.Add(this.lblUserAccountsCount);
            this.pnlUserAccounts.Location = new System.Drawing.Point(170, 210);
            this.pnlUserAccounts.Name = "pnlUserAccounts";
            this.pnlUserAccounts.Size = new System.Drawing.Size(150, 90);
            this.pnlUserAccounts.TabIndex = 3;

            // lblUserAccounts
            this.lblUserAccounts.AutoSize = true;
            this.lblUserAccounts.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserAccounts.ForeColor = System.Drawing.Color.White;
            this.lblUserAccounts.Location = new System.Drawing.Point(20, 15);
            this.lblUserAccounts.Name = "lblUserAccounts";
            this.lblUserAccounts.Size = new System.Drawing.Size(110, 16);
            this.lblUserAccounts.TabIndex = 0;
            this.lblUserAccounts.Text = "USER ACCOUNTS";

            // lblUserAccountsCount
            this.lblUserAccountsCount.AutoSize = true;
            this.lblUserAccountsCount.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserAccountsCount.ForeColor = System.Drawing.Color.White;
            this.lblUserAccountsCount.Location = new System.Drawing.Point(65, 45);
            this.lblUserAccountsCount.Name = "lblUserAccountsCount";
            this.lblUserAccountsCount.Size = new System.Drawing.Size(30, 37);
            this.lblUserAccountsCount.TabIndex = 1;
            this.lblUserAccountsCount.Text = "3";

            // pnlApprovedAccounts
            this.pnlApprovedAccounts.BackColor = System.Drawing.Color.LimeGreen;
            this.pnlApprovedAccounts.Controls.Add(this.lblApprovedAccounts);
            this.pnlApprovedAccounts.Controls.Add(this.lblApprovedCount);
            this.pnlApprovedAccounts.Location = new System.Drawing.Point(375, 210);
            this.pnlApprovedAccounts.Name = "pnlApprovedAccounts";
            this.pnlApprovedAccounts.Size = new System.Drawing.Size(150, 90);
            this.pnlApprovedAccounts.TabIndex = 4;

            // lblApprovedAccounts
            this.lblApprovedAccounts.AutoSize = true;
            this.lblApprovedAccounts.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApprovedAccounts.ForeColor = System.Drawing.Color.White;
            this.lblApprovedAccounts.Location = new System.Drawing.Point(10, 15);
            this.lblApprovedAccounts.Name = "lblApprovedAccounts";
            this.lblApprovedAccounts.Size = new System.Drawing.Size(130, 16);
            this.lblApprovedAccounts.TabIndex = 0;
            this.lblApprovedAccounts.Text = "APPROVED ACCOUNTS";

            // lblApprovedCount
            this.lblApprovedCount.AutoSize = true;
            this.lblApprovedCount.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApprovedCount.ForeColor = System.Drawing.Color.White;
            this.lblApprovedCount.Location = new System.Drawing.Point(65, 45);
            this.lblApprovedCount.Name = "lblApprovedCount";
            this.lblApprovedCount.Size = new System.Drawing.Size(30, 37);
            this.lblApprovedCount.TabIndex = 1;
            this.lblApprovedCount.Text = "3";

            // pnlPendingAccounts
            this.pnlPendingAccounts.BackColor = System.Drawing.Color.Crimson;
            this.pnlPendingAccounts.Controls.Add(this.lblPendingAccounts);
            this.pnlPendingAccounts.Controls.Add(this.lblPendingCount);
            this.pnlPendingAccounts.Location = new System.Drawing.Point(580, 210);
            this.pnlPendingAccounts.Name = "pnlPendingAccounts";
            this.pnlPendingAccounts.Size = new System.Drawing.Size(150, 90);
            this.pnlPendingAccounts.TabIndex = 5;

            // lblPendingAccounts
            this.lblPendingAccounts.AutoSize = true;
            this.lblPendingAccounts.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingAccounts.ForeColor = System.Drawing.Color.White;
            this.lblPendingAccounts.Location = new System.Drawing.Point(15, 15);
            this.lblPendingAccounts.Name = "lblPendingAccounts";
            this.lblPendingAccounts.Size = new System.Drawing.Size(120, 16);
            this.lblPendingAccounts.TabIndex = 0;
            this.lblPendingAccounts.Text = "PENDING ACCOUNTS";

            // lblPendingCount
            this.lblPendingCount.AutoSize = true;
            this.lblPendingCount.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingCount.ForeColor = System.Drawing.Color.White;
            this.lblPendingCount.Location = new System.Drawing.Point(65, 45);
            this.lblPendingCount.Name = "lblPendingCount";
            this.lblPendingCount.Size = new System.Drawing.Size(30, 37);
            this.lblPendingCount.TabIndex = 1;
            this.lblPendingCount.Text = "0";

            // pnlTodayPatients
            this.pnlTodayPatients.BackColor = System.Drawing.Color.White;
            this.pnlTodayPatients.Controls.Add(this.lblTodayPatients);
            this.pnlTodayPatients.Controls.Add(this.dgvTodayPatients);
            this.pnlTodayPatients.Controls.Add(this.lblTotalToday);
            this.pnlTodayPatients.Location = new System.Drawing.Point(20, 320);
            this.pnlTodayPatients.Name = "pnlTodayPatients";
            this.pnlTodayPatients.Size = new System.Drawing.Size(860, 240);
            this.pnlTodayPatients.TabIndex = 6;

            // lblTodayPatients
            this.lblTodayPatients.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblTodayPatients.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTodayPatients.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayPatients.ForeColor = System.Drawing.Color.White;
            this.lblTodayPatients.Location = new System.Drawing.Point(0, 0);
            this.lblTodayPatients.Name = "lblTodayPatients";
            this.lblTodayPatients.Size = new System.Drawing.Size(860, 30);
            this.lblTodayPatients.TabIndex = 0;
            this.lblTodayPatients.Text = "PEDIA AND ADULT PATIENT FOR TODAY";
            this.lblTodayPatients.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // dgvTodayPatients
            this.dgvTodayPatients.AllowUserToAddRows = false;
            this.dgvTodayPatients.AllowUserToDeleteRows = false;
            this.dgvTodayPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvTodayPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTodayPatients.Location = new System.Drawing.Point(10, 40);
            this.dgvTodayPatients.Name = "dgvTodayPatients";
            this.dgvTodayPatients.ReadOnly = true;
            this.dgvTodayPatients.Size = new System.Drawing.Size(840, 170);
            this.dgvTodayPatients.TabIndex = 1;

            // lblTotalToday
            this.lblTotalToday.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblTotalToday.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotalToday.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalToday.ForeColor = System.Drawing.Color.White;
            this.lblTotalToday.Location = new System.Drawing.Point(0, 210);
            this.lblTotalToday.Name = "lblTotalToday";
            this.lblTotalToday.Size = new System.Drawing.Size(860, 30);
            this.lblTotalToday.TabIndex = 2;
            this.lblTotalToday.Text = "Total No. of PATIENTS TODAY: 3";
            this.lblTotalToday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlFooter
            this.pnlFooter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlFooter.Controls.Add(this.lblLoginInfo);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 590);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(900, 30);
            this.pnlFooter.TabIndex = 7;

            // lblLoginInfo
            this.lblLoginInfo.AutoSize = true;
            this.lblLoginInfo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblLoginInfo.Location = new System.Drawing.Point(10, 10);
            this.lblLoginInfo.Name = "lblLoginInfo";
            this.lblLoginInfo.Size = new System.Drawing.Size(542, 14);
            this.lblLoginInfo.TabIndex = 0;
            this.lblLoginInfo.Text = "Login As: Admin | Username: IAN | Fullname: Ian Phillip C Roman | Copyright 2023 | All Rights Reserved";

            // Form5
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roman Medical Clinic - Dashboard";
            this.Load += new System.EventHandler(this.Form5_Load);

            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTodayPatients)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlWelcome.ResumeLayout(false);
            this.pnlPediaCount.ResumeLayout(false);
            this.pnlPediaCount.PerformLayout();
            this.pnlAdultCount.ResumeLayout(false);
            this.pnlAdultCount.PerformLayout();
            this.pnlUserAccounts.ResumeLayout(false);
            this.pnlUserAccounts.PerformLayout();
            this.pnlApprovedAccounts.ResumeLayout(false);
            this.pnlApprovedAccounts.PerformLayout();
            this.pnlPendingAccounts.ResumeLayout(false);
            this.pnlPendingAccounts.PerformLayout();
            this.pnlTodayPatients.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlWelcome;
        private System.Windows.Forms.Label lblWelcome;

        private System.Windows.Forms.Panel pnlPediaCount;
        private System.Windows.Forms.Label lblPediaPatients;
        private System.Windows.Forms.Label lblPediaCount;

        private System.Windows.Forms.Panel pnlAdultCount;
        private System.Windows.Forms.Label lblAdultPatients;
        private System.Windows.Forms.Label lblAdultCount;

        private System.Windows.Forms.Panel pnlUserAccounts;
        private System.Windows.Forms.Label lblUserAccounts;
        private System.Windows.Forms.Label lblUserAccountsCount;

        private System.Windows.Forms.Panel pnlApprovedAccounts;
        private System.Windows.Forms.Label lblApprovedAccounts;
        private System.Windows.Forms.Label lblApprovedCount;

        private System.Windows.Forms.Panel pnlPendingAccounts;
        private System.Windows.Forms.Label lblPendingAccounts;
        private System.Windows.Forms.Label lblPendingCount;

        private System.Windows.Forms.Panel pnlTodayPatients;
        private System.Windows.Forms.Label lblTodayPatients;
        private System.Windows.Forms.DataGridView dgvTodayPatients;
        private System.Windows.Forms.Label lblTotalToday;

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblLoginInfo;
    }
}