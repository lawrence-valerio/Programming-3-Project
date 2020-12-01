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
    public partial class SudentRegistrations : System.Web.UI.Page
    {
        BITCollege_LVContext db = new BITCollege_LVContext();

        /// <summary>
        /// Populates the grid view.
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
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                    try
                    {
                        //Substrings the logged in user and converts to int.
                        string studentID = Page.User.Identity.Name.Substring(0, Page.User.Identity.Name.Length - 8);
                        int parsedStudentID = int.Parse(studentID);

                        //Retrieve Student record and collection of Registration records.
                        Student student = db.Students.Where(x => x.StudentNumber == parsedStudentID).SingleOrDefault();

                        //Checks if student is registered.
                        if(student != null)
                        {
                            IQueryable<Registration> registration = db.Registrations.Where(x => x.StudentId == student.StudentId);

                            //Save records in a session variable.
                            Session["Student"] = student;
                            Session["Registration"] = registration;

                            //Sets label to student full name.
                            lblStudentName.Text = student.FullName;

                            //binds registration datasource to Courses grid view.
                            gvCourses.DataSource = registration.ToList();
                            gvCourses.DataBind();
                        }
                        else
                        {
                            lblStudentName.Text = "Not registered";
                            btnRegister.Visible = false;
                            lblInfo.Text = null;
                            lblStudentError.Text = "Error: Student is not registered in the system.";
                            lblStudentError.Visible = true;
                        }
                    }
                    catch(Exception error)
                    {
                        lblStudentError.Text = error.Message;
                        lblStudentError.Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the selected index event to redirect to the ViewDrop page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["CourseNumber"] = gvCourses.Rows[gvCourses.SelectedIndex].Cells[1].Text;
            Response.Redirect("ViewDrop.aspx");
        }

        /// <summary>
        /// Redirects user to the course registration page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseRegistration.aspx");
        }
    }
}