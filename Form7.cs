using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace roman_medical_clinic_mis
{
    public partial class Form7 : Form
    {
        // Patient information
        private int patientId;
        private string patientFullName;
        private string patientAddress;
        private string patientSexAge;
        private DateTime prescriptionDate;

        private string currentUserType;
        private string currentUsername;
        private string currentFullName;

        public Form7()
        {
            InitializeComponent();

            // Set default image for picLogo if it's missing from resources
            try
            {
                // Check if the image from resources exists
                if (picLogo.Image == null)
                {
                    // Set a default blank image or load from file path
                    picLogo.Image = new Bitmap(100, 100);
                }
            }
            catch
            {
                // Silently handle resource errors
            }
        }

        // Constructor that accepts patient information
        public Form7(int patientId, string fullName, string address, string sexAge, DateTime prescDate)
        {
            InitializeComponent();

            this.patientId = patientId;
            this.patientFullName = fullName;
            this.patientAddress = address;
            this.patientSexAge = sexAge;
            this.prescriptionDate = prescDate;

            // Set default image for picLogo if it's missing from resources
            try
            {
                // Check if the image from resources exists
                if (picLogo.Image == null)
                {
                    // Set a default blank image or load from file path
                    picLogo.Image = new Bitmap(100, 100);
                }
            }
            catch
            {
                // Silently handle resource errors
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // Display patient information in the form
            lblPatientName.Text = patientFullName;
            lblPatientAddress.Text = patientAddress;
            lblPatientSexAge.Text = patientSexAge;
            lblPrescriptionDate.Text = prescriptionDate.ToString("M/d/yyyy");

            // Set focus to the prescription textbox
            txtPrescription.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrescription.Text))
            {
                MessageBox.Show("Please enter prescription details before printing.",
                    "Prescription Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PrintDocument printDocument = new PrintDocument();

                // Set paper size to A5
                PaperSize paperSize = new PaperSize("A5", 583, 827); // A5 size in hundredths of an inch
                printDocument.DefaultPageSettings.PaperSize = paperSize;

                // Set to portrait orientation
                printDocument.DefaultPageSettings.Landscape = false;

                // Set margins (optional)
                Margins margins = new Margins(50, 50, 50, 50); // Left, right, top, bottom
                printDocument.DefaultPageSettings.Margins = margins;

                printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);

                PrintPreviewDialog printPreview = new PrintPreviewDialog();
                printPreview.Document = printDocument;

                // Adjust preview dialog size
                printPreview.StartPosition = FormStartPosition.CenterScreen;

                DialogResult result = printPreview.ShowDialog();
                if (result == DialogResult.OK)
                {
                    printDocument.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error preparing print preview: {ex.Message}",
                    "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Adjust graphics for A5 paper size
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Millimeter; // Use millimeters for more precise measurements

            // A5 paper is 148mm x 210mm
            float pageWidth = 148;
            float pageHeight = 210;

            // Set margins
            float leftMargin = 15;
            float topMargin = 15;
            float rightMargin = 15;
            float bottomMargin = 15;

            // Fonts
            Font titleFont = new Font("Arial", 14, FontStyle.Bold);
            Font normalFont = new Font("Arial", 9);
            Font headerFont = new Font("Arial", 9, FontStyle.Regular);
            Font smallFont = new Font("Arial", 8);
            Font rxFont = new Font("Arial", 36, FontStyle.Bold);
            Font prescriptionFont = new Font("Arial", 10);
            Font signatureFont = new Font("Arial", 8);
            Font licenseFont = new Font("Arial", 7);

            float yPos = topMargin;

            // Logo and Clinic Name
            // If you have a logo image:
            // g.DrawImage(logoImage, leftMargin, yPos, 15, 15);
            g.DrawString("ROMAN", titleFont, Brushes.RoyalBlue, leftMargin, yPos);
            g.DrawString("MEDICAL", titleFont, Brushes.RoyalBlue, leftMargin, yPos + 7);
            g.DrawString("CLINIC", titleFont, Brushes.RoyalBlue, leftMargin, yPos + 14);

            // Doctor information (right aligned with clinic name)
            float doctorInfoX = leftMargin + 45;
            g.DrawString("IAN PHILLIP C. ROMAN, RMT, MD, DPPS", headerFont, Brushes.Gray, doctorInfoX, yPos);
            g.DrawString("Diplomate of the Philippine Pediatric Society", smallFont, Brushes.Gray, doctorInfoX, yPos + 5);
            g.DrawString("PEDIATRICIAN/GENERAL MEDICINE", smallFont, Brushes.Gray, doctorInfoX, yPos + 10);
            g.DrawString("Facebook page: @romanmedicalclinic", smallFont, Brushes.Gray, doctorInfoX, yPos + 15);

            yPos += 25;

            // Clinic Hours Header (centered)
            StringFormat centerFormat = new StringFormat();
            centerFormat.Alignment = StringAlignment.Center;
            g.DrawString("Clinic Hours", normalFont, Brushes.Black, pageWidth / 2, yPos, centerFormat);

            yPos += 6;

            // Two columns for clinic hours
            float leftColX = leftMargin;
            float rightColX = pageWidth / 2 + 5;

            // Left column header
            g.DrawString("Roman Medical Clinic Pililla", smallFont, Brushes.Black, leftColX, yPos);
            // Right column header
            g.DrawString("Adramedix, Tanay", smallFont, Brushes.Black, rightColX, yPos);
            yPos += 5;

            // Clinic hours - Left column
            g.DrawString("MON       9am-12pm/4-5pm", smallFont, Brushes.Black, leftColX, yPos);
            yPos += 4;
            g.DrawString("TUE        9am-12pm/4-5pm", smallFont, Brushes.Black, leftColX, yPos);
            yPos += 4;
            g.DrawString("WED       9am-5pm", smallFont, Brushes.Black, leftColX, yPos);
            yPos += 4;
            g.DrawString("THU        1-5pm", smallFont, Brushes.Black, leftColX, yPos);
            yPos += 4;
            g.DrawString("FRI        9am-12pm/4-5pm", smallFont, Brushes.Black, leftColX, yPos);
            yPos += 4;
            g.DrawString("SAT        9am-12pm/4-5pm", smallFont, Brushes.Black, leftColX, yPos);

            // Reset Y position for right column
            yPos -= 20;

            // Clinic hours - Right column
            g.DrawString("MON       1pm-3pm", smallFont, Brushes.Black, rightColX, yPos);
            yPos += 4;
            g.DrawString("TUE        1pm-3pm", smallFont, Brushes.Black, rightColX, yPos);
            yPos += 4;
            g.DrawString("THU        9am-11am", smallFont, Brushes.Black, rightColX, yPos);
            yPos += 4;
            g.DrawString("FRI        1pm-3pm", smallFont, Brushes.Black, rightColX, yPos);
            yPos += 4;
            g.DrawString("SAT        1pm-3pm", smallFont, Brushes.Black, rightColX, yPos);

            // Reset Y position and add hospital affiliation
            yPos += 8;
            g.DrawString("Hospital Affiliation: Tanay General Hospital", smallFont, Brushes.Black, leftMargin, yPos);

            yPos += 10;

            // Patient information - Name and Address (left side)
            Brush patientInfoColor = Brushes.DarkSlateGray;
            g.DrawString("FULLNAME: " + patientFullName, normalFont, patientInfoColor, leftMargin, yPos);

            // Sex/Age (right side)
            g.DrawString("SEX/AGE: " + patientSexAge, normalFont, patientInfoColor, rightColX, yPos);

            yPos += 6;

            // Address (left side)
            g.DrawString("ADDRESS: " + patientAddress, normalFont, patientInfoColor, leftMargin, yPos);

            // Date (right side)
            g.DrawString("DATE: " + prescriptionDate.ToString("M/d/yyyy"), normalFont, patientInfoColor, rightColX, yPos);

            yPos += 12;

            // Rx Symbol (large and light gray)
            g.DrawString("Rx", rxFont, Brushes.LightGray, leftMargin, yPos - 5);

            // Prescription content - allow enough space for the Rx symbol
            yPos += 8;

            // Calculate remaining space for prescription text
            float prescriptionHeight = 70; // Fixed height for prescription area

            RectangleF prescriptionRect = new RectangleF(
                leftMargin + 25,  // Indent to allow space for the Rx symbol
                yPos,
                pageWidth - leftMargin - rightMargin - 25,
                prescriptionHeight);

            g.DrawString(txtPrescription.Text, prescriptionFont, Brushes.Black, prescriptionRect);

            // Signature area at the bottom right
            float signatureY = pageHeight - bottomMargin - 25;
            float signatureX = pageWidth - rightMargin - 60;
            float signatureWidth = 50;

            g.DrawLine(Pens.Black, signatureX, signatureY, signatureX + signatureWidth, signatureY);

            // Doctor information below signature
            g.DrawString("Ian Phillip C. Roman, RMT, MD, DPPS", signatureFont, Brushes.Black, signatureX, signatureY + 3);
            g.DrawString("Pediatrician", signatureFont, Brushes.Black, signatureX + 20, signatureY + 9);
            g.DrawString("PRC: 123456", licenseFont, Brushes.Black, signatureX + 20, signatureY + 15);
            g.DrawString("S2: 030037RM23-013", licenseFont, Brushes.Black, signatureX + 10, signatureY + 21);

            // Add vertical text for doctor's credentials on right edge
            using (Font verticalFont = new Font("Arial", 8, FontStyle.Regular))
            {
                // Save graphics state
                GraphicsState state = g.Save();

                // Set up for vertical text
                g.TranslateTransform(pageWidth - 5, pageHeight - 30);
                g.RotateTransform(270);

                // Draw vertical text
                g.DrawString("Ian Phillip C. Roman, RMT, MD, DPPS", verticalFont, Brushes.LightGray, 0, 0);
                g.DrawString("S2: 030037RM23-013", verticalFont, Brushes.LightGray, 0, 15);

                // Restore graphics state
                g.Restore(state);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Determine which form to return to based on which form called this
            Form previousForm = null;

            // Check if we came from Form2 (Pediatric)
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form2)
                {
                    previousForm = f;
                    break;
                }
                else if (f is Form3) // Check if we came from Form3 (Adult)
                {
                    previousForm = f;
                    break;
                }
            }

            if (previousForm != null)
            {
                previousForm.Show();
            }
            else
            {
                // Default to Form2 if we can't find the previous form
                Form2 pediatricForm = new Form2(currentUserType, currentUsername, currentFullName);
                pediatricForm.Show();
            }

            this.Close();
        }
    }
}