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
    public partial class History : Form
    {
        BITCollege_LVContext db = new BITCollege_LVContext();

        ///given:  student and registration data will passed throughout 
        ///application. This object will be used to store the current
        ///student and selected registration
        ConstructorData constructorData;


        public History()
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
        public History(ConstructorData currentConstructorData)
        {   
            InitializeComponent();

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
        /// further code required: Sets the data source of the data grid view to the registration records of that particular student.
        /// </summary>
        private void History_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            int studentId = constructorData.student.StudentId;

            try
            {
                var query = (from x in db.Registrations
                             join y in db.Courses
                             on x.CourseId equals y.CourseId
                             where x.StudentId == studentId
                             select new { x.RegistrationNumber, x.RegistrationDate, y.Title, x.Grade, x.Notes });

                registrationDataGridView.DataSource = query.ToList();
            }
            catch (Exception message)
            {
                MessageBox.Show("Error: " + message, "Exception Occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
