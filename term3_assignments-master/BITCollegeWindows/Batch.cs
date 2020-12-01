using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BITCollege_LV.Data;
using BITCollege_LV.Models;
using Utility;

namespace BITCollegeWindows
{
    public partial class Batch : Form
    {
        BITCollege_LVContext db = new BITCollege_LVContext();

        public Batch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// given:  ensures key is entered
        /// further code to be added
        /// </summary>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //NOTE:  This may be commented out until needed
            /*if (txtKey.Text == "")
            {
                MessageBox.Show("A 64-bit Key must be entered", "Error");
            }*/

            BatchProcess batchProcess = new BatchProcess();

            if (radSelect.Checked)
            {
                batchProcess.ProcessTransmission(cbProgram.SelectedValue.ToString(), "sd");
                rtxtLog.Text += batchProcess.WriteLogData();
            }

            if (radAll.Checked)
            {
                for (int i = 0; i < cbProgram.Items.Count; i++)
                {
                    string description = cbProgram.GetItemText(cbProgram.Items[i]);
                    AcademicProgram academicProgram = db.AcademicPrograms.Where(x => x.Description == description).SingleOrDefault();
                    batchProcess.ProcessTransmission(academicProgram.ProgramAcronym, "sd");
                    rtxtLog.Text += batchProcess.WriteLogData();
                }
            }
        }

        /// <summary>
        /// given:  open in top right of frame
        /// further code required:
        /// </summary>
        private void Batch_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            academicProgramBindingSource.DataSource = db.AcademicPrograms.ToList();

            cbProgram.Enabled = false;
        }

        /// <summary>
        /// Checks whether a single transmission is selected and enables the combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (radSelect.Checked)
            {
                cbProgram.Enabled = true;
            }
            else
            {
                cbProgram.Enabled = false;
            }
        }
    }
}
