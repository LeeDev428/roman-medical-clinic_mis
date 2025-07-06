namespace roman_medical_clinic_mis
{
    partial class Form8
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblAboutUs = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblSystemRequirements = new System.Windows.Forms.Label();
            this.lblSysReqDetails = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.txtLicensure = new System.Windows.Forms.TextBox();
            this.lblLicensure = new System.Windows.Forms.Label();
            this.lblClinicInfo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlHeader.Controls.Add(this.lblAboutUs);
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblAboutUs
            // 
            this.lblAboutUs.AutoSize = true;
            this.lblAboutUs.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAboutUs.ForeColor = System.Drawing.Color.White;
            this.lblAboutUs.Location = new System.Drawing.Point(20, 15);
            this.lblAboutUs.Name = "lblAboutUs";
            this.lblAboutUs.Size = new System.Drawing.Size(157, 32);
            this.lblAboutUs.TabIndex = 0;
            this.lblAboutUs.Text = "ABOUT US";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(760, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(800, 360);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlRight
            // 
            this.pnlRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.lblSystemRequirements);
            this.pnlRight.Controls.Add(this.lblSysReqDetails);
            this.pnlRight.Location = new System.Drawing.Point(400, 20);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(380, 280);
            this.pnlRight.TabIndex = 2;
            // 
            // lblSystemRequirements
            // 
            this.lblSystemRequirements.AutoSize = true;
            this.lblSystemRequirements.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemRequirements.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSystemRequirements.Location = new System.Drawing.Point(10, 10);
            this.lblSystemRequirements.Name = "lblSystemRequirements";
            this.lblSystemRequirements.Size = new System.Drawing.Size(182, 19);
            this.lblSystemRequirements.TabIndex = 0;
            this.lblSystemRequirements.Text = "SYSTEM REQUIREMENTS";
            // 
            // lblSysReqDetails
            // 
            this.lblSysReqDetails.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSysReqDetails.ForeColor = System.Drawing.Color.Black;
            this.lblSysReqDetails.Location = new System.Drawing.Point(10, 40);
            this.lblSysReqDetails.Name = "lblSysReqDetails";
            this.lblSysReqDetails.Size = new System.Drawing.Size(360, 230);
            this.lblSysReqDetails.TabIndex = 1;
            this.lblSysReqDetails.Text = "Softwares needed:\r\n" +
                "Compatibility: Windows PC/OS(7/8/10/11)\r\n" +
                "Xampp 1.7.7 to 3.3.2\r\n" +
                ".Net Framwork 4.5 to 4.8\r\n\r\n" +
                "Hardwares Needed:\r\n" +
                "Processor: Intel Core i3 3rd gen to core i9 atleast\r\n   speed 3.0Ghz\r\n" +
                "RAM: 4GB to 16GB\r\n" +
                "Storage: atleast 500GB to 1TB HDD/SSD\r\n" +
                "Keyboard/Mouse: Any Brand\r\n" +
                "Monitor: atleast 20 inches (atleast 1920x1080\r\n   resolution)\r\n" +
                "Internet/Wifi: Any Network atleast 50mbps";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.txtLicensure);
            this.pnlLeft.Controls.Add(this.lblLicensure);
            this.pnlLeft.Controls.Add(this.lblClinicInfo);
            this.pnlLeft.Location = new System.Drawing.Point(20, 20);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(370, 280);
            this.pnlLeft.TabIndex = 1;
            // 
            // txtLicensure
            // 
            this.txtLicensure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLicensure.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicensure.Location = new System.Drawing.Point(13, 230);
            this.txtLicensure.Name = "txtLicensure";
            this.txtLicensure.Size = new System.Drawing.Size(347, 22);
            this.txtLicensure.TabIndex = 2;
            // 
            // lblLicensure
            // 
            this.lblLicensure.AutoSize = true;
            this.lblLicensure.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicensure.ForeColor = System.Drawing.Color.Black;
            this.lblLicensure.Location = new System.Drawing.Point(10, 210);
            this.lblLicensure.Name = "lblLicensure";
            this.lblLicensure.Size = new System.Drawing.Size(75, 16);
            this.lblLicensure.TabIndex = 1;
            this.lblLicensure.Text = "LICENSURE";
            // 
            // lblClinicInfo
            // 
            this.lblClinicInfo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClinicInfo.ForeColor = System.Drawing.Color.Black;
            this.lblClinicInfo.Location = new System.Drawing.Point(10, 10);
            this.lblClinicInfo.Name = "lblClinicInfo";
            this.lblClinicInfo.Size = new System.Drawing.Size(350, 190);
            this.lblClinicInfo.TabIndex = 0;
            this.lblClinicInfo.Text = "ROMAN MEDICAL CLINIC SYSTEM\r\n" +
                "Rizal, Imatong Pililla Rizal\r\n" +
                "Rizal, Philippines, 1910\r\n\r\n" +
                "Owner: IAN PHILLIP C. ROMAN, RMT, MD, DPPS\r\n" +
                "Diplomate of the Philippine Pediatric Society\r\n" +
                "PEDIATRICIAN/GENERAL MEDICINE\r\n\r\n" +
                "Facebook page: @romanmedicalclinic";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(700, 310);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 420);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 30);
            this.pnlFooter.TabIndex = 2;
            // 
            // lblFooter
            // 
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFooter.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.Color.White;
            this.lblFooter.Location = new System.Drawing.Point(0, 0);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(800, 30);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "Copyright 2023 | All Rights Reserved | Powered By: Ian Phillip C. Roman, RMT, MD, DPPS | Pediatrician | PRC: 123456";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About Us";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAboutUs;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblClinicInfo;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblSystemRequirements;
        private System.Windows.Forms.Label lblSysReqDetails;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblLicensure;
        private System.Windows.Forms.TextBox txtLicensure;
    }
}