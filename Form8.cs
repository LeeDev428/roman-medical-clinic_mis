using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace roman_medical_clinic_mis
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt",
                    Title = "Save About Information",
                    FileName = "RomanMedicalClinic_About.txt"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        writer.WriteLine("ROMAN MEDICAL CLINIC SYSTEM - ABOUT US");
                        writer.WriteLine("=====================================");
                        writer.WriteLine();
                        writer.WriteLine(lblClinicInfo.Text);
                        writer.WriteLine();
                        writer.WriteLine("SYSTEM REQUIREMENTS");
                        writer.WriteLine("==================");
                        writer.WriteLine();
                        writer.WriteLine(lblSysReqDetails.Text);
                        writer.WriteLine();
                        writer.WriteLine("=====================================");
                        writer.WriteLine(lblFooter.Text);
                    }
                    
                    MessageBox.Show("Information saved successfully!", "Save", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving information: {ex.Message}", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
