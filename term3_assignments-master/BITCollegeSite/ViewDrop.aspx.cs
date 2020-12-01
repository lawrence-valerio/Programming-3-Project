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
    public partial class ViewDrop : System.Web.UI.Page
    {
        BITCollege_LVContext db = new BITCollege_LVContext();

        /// <summary>
        /// Populates the details view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Account/Login.aspx");
                }
                else
                {
                    try
                    {
                        string courseNumber = Session["CourseNumber"].ToString();
                        IQueryable<Registration> registrations = (IQueryable<Registration>)Session["Registration"];
                        int courseId = db.Courses.Where(x => x.CourseNumber == courseNumber).Select(x => x.CourseId).SingleOrDefault();

                        IQueryable<Registration> filteredRegistrations = registrations.Where(x => x.CourseId == courseId);
                        Session["FilteredRegistrations"] = filteredRegistrations;

                        dvCourse.DataSource = filteredRegistrations.ToList();
                        this.DataBind();

                        EnableDropCourse();
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
        /// Sets the page to the selected index of that registration record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dvCourse_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            //Obtaining the data from the session variable.
            IQueryable<Registration> filteredRegistrations = (IQueryable<Registration>)Session["FilteredRegistrations"];

            //Sets the page index to the selected page index.
            dvCourse.PageIndex = e.NewPageIndex;

            //Re-binds the data from the session variable.
            dvCourse.DataSource = filteredRegistrations.ToList();
            this.DataBind();

            //enables the drop course button.
            EnableDropCourse();
        }

        /// <summary>
        /// Enables the drop course button if the grade row is null.
        /// </summary>
        private void EnableDropCourse()
        {
            string gradeValue = dvCourse.Rows[4].Cells[1].Text;

            if (gradeValue == "&nbsp;")
            {
                btnDropCourse.Enabled = true;
            }
            else
            {
                btnDropCourse.Enabled = false;
            }
        }

        /// <summary>
        /// Handles the click event of the drop course button to drop course.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDropCourse_Click(object sender, EventArgs e)
        {
            //Instantiating service object.
            CollegeServiceReference.CollegeRegistrationClient service = new CollegeServiceReference.CollegeRegistrationClient();

            int registrationId = int.Parse(dvCourse.Rows[0].Cells[1].Text);

            bool dropCourse = service.DropCourse(registrationId);

            if (dropCourse == false)
            {
                lblError.Visible = true;
                lblError.Text = "Error: Unable to drop course.";
            }
            else
            {
                Response.Redirect("StudentRegistrations.aspx");
            }
        }

        /// <summary>
        /// Handles the click event for the return button to return to the student registrations page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentRegistrations.aspx");
        }
    }
}