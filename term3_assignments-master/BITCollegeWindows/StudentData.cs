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

namespace BITCollegeWindows
{
    public partial class StudentData : Form
    {
        BITCollege_LVContext db = new BITCollege_LVContext();

        ///Given: Student and Registration data will be retrieved
        ///in this form and passed throughout application
        ///These variables will be used to store the current
        ///Student and selected Registration
        ConstructorData constructorData = new ConstructorData();
        public StudentData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// given:  This constructor will be used when returning to frmStudent
        /// from another form.  This constructor will pass back
        /// specific information about the student and registration
        /// based on activites taking place in another form
        /// </summary>
        /// <param name="constructorData">Student data passed among forms</param>
        public StudentData(ConstructorData passedConstructorData)
        {
            InitializeComponent();

            constructorData = passedConstructorData;
            long studentNumber = constructorData.student.StudentNumber;
            mtbStudentNumber.Text = studentNumber.ToString();
            mtbStudentNumber_Leave(null, null);
        }

        /// <summary>
        /// given: open grading form passing constructor data
        /// </summary>
        private void lnkUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            populateConstructorData();
            Grading grading = new Grading(constructorData);
            grading.MdiParent = this.MdiParent;
            grading.Show();
            this.Close();
        }

        /// <summary>
        /// given: open history form passing data
        /// </summary>
        private void lnkDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            populateConstructorData();
            History history = new History(constructorData);
            history.MdiParent = this.MdiParent;
            history.Show();
            this.Close();
        }
        /// <summary>
        /// given:  opens form in top right of frame
        /// </summary>
        private void StudentData_Load(object sender, EventArgs e)
        {
            //keeps location of form static when opened and closed
            this.Location = new Point(0, 0);
        }

        /// <summary>
        /// Once user leaves focus from the masked text box it binds the student binding source to the student associated with the student number.
        /// It also binds the registration records of that student to the registration binding source.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtbStudentNumber_Leave(object sender, EventArgs e)
        {
            if (mtbStudentNumber.MaskCompleted == true)
            {
                int studentNumber = int.Parse(mtbStudentNumber.Text);

                studentBindingSource.DataSource = db.Students.Where(x => x.StudentNumber == studentNumber).ToList();

                if (studentBindingSource.List.Count == 0)
                {
                    //Removing any previous data
                    lnkUpdate.Enabled = false;
                    lnkDetails.Enabled = false;

                    studentBindingSource.Clear();
                    registrationBindingSource.Clear();

                    MessageBox.Show("Student " + studentNumber + " does not exist.", "Invalid Student Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int studentId = 0;

                    foreach (Student student in studentBindingSource)
                    {
                        studentId = student.StudentId;
                    }

                    registrationBindingSource.DataSource = db.Registrations.Where(x => x.StudentId == studentId).ToList();

                    if (constructorData.registration != null)
                    {
                        cbRegistrationNumber.Text = constructorData.registration.RegistrationNumber.ToString();
                    }

                    if (registrationBindingSource.List.Count == 0)
                    {
                        registrationBindingSource.Clear();

                        lnkUpdate.Enabled = false;
                        lnkDetails.Enabled = false;
                    }
                    else
                    {
                        lnkUpdate.Enabled = true;
                        lnkDetails.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Populates the constructorData object with the current student and the current registration record.
        /// </summary>
        private void populateConstructorData()
        {
            int studentNumber = int.Parse(mtbStudentNumber.Text);
            int currentRegistration = int.Parse(cbRegistrationNumber.Text);
            Student student = db.Students.Where(x => x.StudentNumber == studentNumber).SingleOrDefault();
            Registration registration = db.Registrations.Where(x => x.RegistrationNumber == currentRegistration).FirstOrDefault();

            constructorData.student = student;
            constructorData.registration = registration;
        }
    }
}
