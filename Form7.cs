using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

            // Set margins in mm
            float leftMargin = 10;
            float topMargin = 10;
            float rightMargin = 10;
            float bottomMargin = 10;

            float yPos = topMargin;
            Font titleFont = new Font("Arial", 11, FontStyle.Bold);
            Font normalFont = new Font("Arial", 8);
            Font headerFont = new Font("Arial", 7);
            Font smallFont = new Font("Arial", 6);

            // Print clinic header
            g.DrawString("ROMAN MEDICAL CLINIC", titleFont, Brushes.DarkBlue, leftMargin, yPos);
            yPos += 8;

            g.DrawString("IAN PHILLIP C. ROMAN, RMT, MD, DPPS", headerFont, Brushes.DarkGray, leftMargin, yPos);
            yPos += 5;
            g.DrawString("Diplomate of the Philippine Pediatric Society", smallFont, Brushes.DarkGray, leftMargin, yPos);
            yPos += 4;
            g.DrawString("PEDIATRICIAN/GENERAL MEDICINE", smallFont, Brushes.DarkGray, leftMargin, yPos);
            yPos += 4;
            g.DrawString("Facebook page: @romanmedicalclinic", smallFont, Brushes.DarkGray, leftMargin, yPos);
            yPos += 6;

            // Clinic hours
            g.DrawString("Clinic Hours", smallFont, Brushes.DarkGray, leftMargin, yPos);
            yPos += 5;

            float leftCol = leftMargin;
            float rightCol = leftMargin + 65;

            g.DrawString("Roman Medical Clinic Pililla", smallFont, Brushes.DarkGray, leftCol, yPos);
            g.DrawString("Adramedix, Tanay", smallFont, Brushes.DarkGray, rightCol, yPos);
            yPos += 4;

            g.DrawString("MON      9am-12pm/4-5pm", smallFont, Brushes.DarkGray, leftCol, yPos);
            g.DrawString("MON      1pm-3pm", smallFont, Brushes.DarkGray, rightCol, yPos);
            yPos += 4;

            g.DrawString("TUE       9am-12pm/4-5pm", smallFont, Brushes.DarkGray, leftCol, yPos);
            g.DrawString("TUE       1pm-3pm", smallFont, Brushes.DarkGray, rightCol, yPos);
            yPos += 4;

            g.DrawString("WED      9am-5pm", smallFont, Brushes.DarkGray, leftCol, yPos);
            g.DrawString("THU       9am-11pm", smallFont, Brushes.DarkGray, rightCol, yPos);
            yPos += 4;

            g.DrawString("THU       1-5pm", smallFont, Brushes.DarkGray, leftCol, yPos);
            g.DrawString("FRI        1pm-3pm", smallFont, Brushes.DarkGray, rightCol, yPos);
            yPos += 4;

            g.DrawString("FRI        9am-12pm/4-5pm", smallFont, Brushes.DarkGray, leftCol, yPos);
            g.DrawString("SAT       1pm-3pm", smallFont, Brushes.DarkGray, rightCol, yPos);
            yPos += 4;

            g.DrawString("SAT       9am-12pm/4-5pm", smallFont, Brushes.DarkGray, leftCol, yPos);
            yPos += 6;

            g.DrawString("Hospital Affiliation: Tanay General Hospital", smallFont, Brushes.DarkGray, leftMargin, yPos);
            yPos += 6;

            // Patient information - reduced spacing for A5 paper
            g.DrawString($"FULLNAME: {patientFullName}", normalFont, Brushes.Black, leftCol, yPos);
            g.DrawString($"DATE: {prescriptionDate.ToString("M/d/yyyy")}", normalFont, Brushes.Black, rightCol + 20, yPos);
            yPos += 6;

            g.DrawString($"ADDRESS: {patientAddress}", normalFont, Brushes.Black, leftCol, yPos);
            yPos += 6;

            g.DrawString($"SEX/AGE: {patientSexAge}", normalFont, Brushes.Black, leftCol, yPos);
            yPos += 8;

            // Rx symbol
            Font rxFont = new Font("Arial", 12, FontStyle.Bold);
            g.DrawString("Rx", rxFont, Brushes.Black, leftMargin, yPos);
            yPos += 8;

            // Draw prescription text - calculate available space
            Font prescriptionFont = new Font("Arial", 8);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Near;
            format.Alignment = StringAlignment.Near;

            // Calculate remaining space for prescription text
            float prescriptionHeight = pageHeight - bottomMargin - yPos - 15; // 15mm reserved for signature

            RectangleF prescriptionRect = new RectangleF(
                leftMargin + 5,
                yPos,
                pageWidth - leftMargin - rightMargin - 10,
                prescriptionHeight);

            g.DrawString(txtPrescription.Text, prescriptionFont, Brushes.Black, prescriptionRect, format);

            // Draw signature line at bottom of page
            float signatureY = pageHeight - bottomMargin - 10;
            float signatureX = pageWidth - rightMargin - 50;
            float signatureWidth = 40;

            g.DrawLine(Pens.Black, signatureX, signatureY, signatureX + signatureWidth, signatureY);
            signatureY += 3;
            g.DrawString("Physician's Signature", smallFont, Brushes.Black, signatureX, signatureY);
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
                Form2 pediatricForm = new Form2();
                pediatricForm.Show();
            }

            this.Close();
        }
    }
}