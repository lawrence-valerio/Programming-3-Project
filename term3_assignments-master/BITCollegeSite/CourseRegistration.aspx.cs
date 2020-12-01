using BITCollege_LV.Data;
using BITCollege_LV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITCollegeSite
{
    public partial class CourseRegistration : System.Web.UI.Page
    {
        BITCollege_LVContext db = new BITCollege_LVContext();

        /// <summary>
        /// Populates the drop down list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Checks to see if user is authenticated.
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    //Redirect to login page.
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                    try
                    {
                        //Sets student name label to the student full name.
                        lblStudentName.Text = GetStudent().FullName;

                        //Gets the registered program of the student.
                        int? academicProgramId = GetStudent().AcademicProgramId;

                        //Retrieves a list of courses with the student's registered program.
                        IQueryable<Course> courses = db.Courses.Where(x => x.AcademicProgramId == academicProgramId);

                        //Binding courses data to drop down list.
                        ddlCourseSelector.DataSource = courses.ToList();
                        ddlCourseSelector.DataTextField = "Title";
                        ddlCourseSelector.DataValueField = "CourseId";
                        this.DataBind();
                    }
                    catch (Exception error)
                    {
                        lblError.Text = error.Message;
                        lblError.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the click event for the return button to return to StudentRegistrations page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentRegistrations.aspx");
        }

        /// <summary>
        /// Handles the register click event to register for a course.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //enables validator control.
            rfvNotes.Enabled = true;

            //Checks if page is validated
            Page.Validate();
            if (Page.IsValid)
            {
                //Retrieves the course id, student id and the notes.
                int courseId = int.Parse(ddlCourseSelector.SelectedValue);
                int studentId = GetStudent().StudentId;
                string notes = txtRegistrationNotes.Text;

                /*                CollegeServiceReference.CollegeRegistrationClient service = new CollegeServiceReference.CollegeRegistrationClient();*/

                CollegeServiceReference.CollegeRegistrationClient service = new CollegeServiceReference.CollegeRegistrationClient();

                int registerCourse = service.RegisterCourse(studentId, courseId, notes);

                if(registerCourse == 0)
                {
                    Response.Redirect("StudentRegistrations.aspx");
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = Utility.BusinessRules.RegisterError(registerCourse);
                }
            }
        }

        /// <summary>
        /// Gets the record of the student from the session variable.
        /// </summary>
        /// <returns>Record of student</returns>
        private Student GetStudent()
        {
            Student student = (Student)Session["Student"];
            return student;
        }
    }
}