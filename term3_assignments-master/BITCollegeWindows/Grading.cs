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
    public partial class Grading : Form
    {
        BITCollege_LVContext db = new BITCollege_LVContext();

        ///given:  student and registration data will passed throughout 
        ///application. This object will be used to store the current
        ///student and selected registration
        ConstructorData constructorData;
        public Grading()
        {
            InitializeComponent();
        }

        /// <summary>
        /// given:  This constructor will be used when called from the
        /// Student form.  This constructor will receive 
        /// specific information about the student and registration
        /// further code required: Populates the constructor data with the given information of the student and registration.
        /// </summary>
        /// <param name="student">specific student instance</param>
        /// <param name="registration">specific registration instance</param>
        public Grading(ConstructorData currentConstructorData)
        {
            InitializeComponent();

            //further code to be added

            constructorData = currentConstructorData;

            studentBindingSource.DataSource = constructorData.student;
            registrationBindingSource.DataSource = constructorData.registration;
        }

        /// <summary>
        /// given: this code will navigate back to the Student form with
        /// the specific student and registration data that launched
        /// this form.
        /// </summary>
        private void lnkReturn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //return to student with the data selected for this form
            StudentData student = new StudentData(constructorData);
            student.MdiParent = this.MdiParent;
            student.Show();
            this.Close();
        }

        /// <summary>
        /// given:  open in top right of frame
        /// further code required: Enables the user to submit a grade if the course is not graded.
        /// Disables grade submission if the course is already graded.
        /// </summary>
        private void Grading_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            string courseNumberMask = BusinessRules.CourseFormat(lblCourseType.Text);
            mlblCourseNumber.Mask = courseNumberMask;

            if(constructorData.registration.Grade == null)
            {
                tbGrade.Enabled = true;
                lnkUpdate.Enabled = true;
                lblExisting.Visible = false;
            }
            else
            {
                tbGrade.Enabled = false;
                lnkUpdate.Enabled = false;
                lblExisting.Visible = true;
            }
        }

        /// <summary>
        /// Updates the students grade for that course.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string clearedFormat = Numeric.ClearFormatting(tbGrade.Text, "%");

            if (Numeric.IsNumeric(clearedFormat, System.Globalization.NumberStyles.Number))
            {
                double gradeFormatted = double.Parse(clearedFormat)/100;
                if(gradeFormatted >= 0 && gradeFormatted <= 1)
                {
                    CollegeRegistrationService.CollegeRegistrationClient service = new CollegeRegistrationService.CollegeRegistrationClient();

                    int registrationId = constructorData.registration.RegistrationId;
                    string notes = constructorData.registration.Notes;
                    
                    service.UpdateGrade(gradeFormatted, registrationId, notes);
                    lnkUpdate.Enabled = false;
                }
                else
                {
                    tbGrade.Text = "";
                    MessageBox.Show("Grade must be between the values of 0-1.", "Incorrect Values", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                tbGrade.Text = "";
                MessageBox.Show("Grade value is not a number.", "Grade is not a number", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
