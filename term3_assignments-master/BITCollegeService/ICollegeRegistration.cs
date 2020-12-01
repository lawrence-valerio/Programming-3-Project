using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BITCollegeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICollegeRegistration" in both code and config file together.
    [ServiceContract]
    public interface ICollegeRegistration
    {
        [OperationContract]
        void DoWork();

        /// <summary>
        /// Drops the course of the corresponding registration ID.
        /// </summary>
        /// <param name="registrationId">Represents argument Registration ID</param>
        /// <returns>True if an exception occurs, False if it successfully drops the course.</returns>
        [OperationContract]
        bool DropCourse(int registrationId);

        /// <summary>
        /// Registers a student to a course.
        /// </summary>
        /// <param name="studentId">Represents argument Student ID.</param>
        /// <param name="courseId">Represents argument Course ID.</param>
        /// <param name="notes">Represents argument notes.</param>
        /// <returns>An int value that indicates failure or success.</returns>
        [OperationContract]
        int RegisterCourse(int studentId, int courseId, string notes);

        /// <summary>
        /// Updates the grade of the corresponding Registration ID.
        /// </summary>
        /// <param name="grade">Represents argument Grade</param>
        /// <param name="registrationId">Represents argument Registration ID.</param>
        /// <param name="notes">Represents argument Notes.</param>
        [OperationContract]
        void UpdateGrade(double grade, int registrationId, string notes);
    }
}
