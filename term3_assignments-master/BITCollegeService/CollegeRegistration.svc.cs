using BITCollege_LV.Data;
using BITCollege_LV.Models;
using Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Security;
using System.Data.Entity.Infrastructure;

namespace BITCollegeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CollegeRegistration" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CollegeRegistration.svc or CollegeRegistration.svc.cs at the Solution Explorer and start debugging.
    public class CollegeRegistration : ICollegeRegistration
    {
        BITCollege_LVContext db = new BITCollege_LVContext();

        public void DoWork()
        {
        }

        /// <summary>
        /// Drops the course of the corresponding registration ID.
        /// </summary>
        /// <param name="registrationId">Represents argument Registration ID</param>
        /// <returns>True if an exception occurs, False if it successfully drops the course.</returns>
        public bool DropCourse(int registrationId)
        {
            Registration retrievedRegistrationId = db.Registrations.Where(x => x.RegistrationId == registrationId).SingleOrDefault();

            try
            {
                db.Registrations.Remove(retrievedRegistrationId);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Registers a student to a course.
        /// </summary>
        /// <param name="studentId">Represents argument Student ID.</param>
        /// <param name="courseId">Represents argument Course ID.</param>
        /// <param name="notes">Represents argument notes.</param>
        /// <returns>An int value that indicates failure or success.</returns>
        public int RegisterCourse(int studentId, int courseId, string notes)
        {
            IQueryable<Registration> registrations = db.Registrations.Where(x => x.StudentId == studentId);
            Course course = db.Courses.Where(x => x.CourseId == courseId).SingleOrDefault();
            Student student = db.Students.Where(x => x.StudentId == studentId).SingleOrDefault();

            int validation = 0;
            try
            {
                foreach (Registration registration in registrations)
                {
                        if (registration.CourseId == courseId && registration.Grade == null)
                        {
                            validation = -100;
                        }

                        if (registration.CourseId == courseId && course.CourseType == "Mastery")
                        {
                            validation = -200;
                        }
                }

                if (validation == 0)
                {
                    Registration register = new Registration();

                    DateTime date = DateTime.Today;

                    register.StudentId = studentId;
                    register.CourseId = courseId;
                    register.RegistrationDate = date;
                    register.Notes = notes;
                    register.SetNextRegistrationNumber();
                    db.Registrations.Add(register);
                    db.SaveChanges();

                    student.OutstandingFees = student.OutstandingFees + (course.TuitionAmount * student.GradePointState.TuitionRateAdjustment(student));
                    db.SaveChanges();
                }
            }
            catch
            {
                validation = -300;
            }

            return validation;
        }

        /// <summary>
        /// Updates the grade of the corresponding Registration ID.
        /// </summary>
        /// <param name="grade">Represents argument Grade</param>
        /// <param name="registrationId">Represents argument Registration ID.</param>
        /// <param name="notes">Represents argument Notes.</param>
        public void UpdateGrade(double grade, int registrationId, string notes)
        {
            Registration retrievedRegistrationId = db.Registrations.Where(x => x.RegistrationId == registrationId).SingleOrDefault();

            if(retrievedRegistrationId != null)
            {
                retrievedRegistrationId.Grade = grade;
                retrievedRegistrationId.Notes = notes;
                db.SaveChanges();
                CalculateGradePoint(retrievedRegistrationId.StudentId);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the grade point average of the corresponding Student ID.
        /// </summary>
        /// <param name="studentId">Represents argument Student ID.</param>
        private void CalculateGradePoint(int studentId)
        {
            IQueryable<Registration> retrievedRegistration = db.Registrations.Where(x => x.StudentId == studentId && x.Grade != null);
            Student student = db.Students.Where(x => x.StudentId == studentId).SingleOrDefault();

            double totalGradePointValue = 0;
            double totalCreditHours = 0;

            foreach(Registration registration in retrievedRegistration.ToList())
            {
                Course courses = db.Courses.Where(x => x.CourseId == registration.CourseId).SingleOrDefault();

                CourseType courseType = BusinessRules.CourseTypeLookup(courses.CourseType);

                if(courseType != CourseType.AUDIT)
                {
                    double gradePointValue = BusinessRules.GradeLookup((double)registration.Grade, courseType);

                    totalGradePointValue = totalGradePointValue + (gradePointValue * courses.CreditHours);
                    totalCreditHours = totalCreditHours + courses.CreditHours;
                }
            }
            double calculatedGPA = totalGradePointValue / totalCreditHours;
            student.GradePointAverage = calculatedGPA;
            student.ChangeState();
            db.SaveChanges();
        }
    }
}
