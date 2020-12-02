using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utility;
using System.Web.Services.Description;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Management;
using System.Web.UI.WebControls;
using BITCollege_LV.Data;
using Microsoft.Ajax.Utilities;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Data;

namespace BITCollege_LV.Models
{
    /// <summary>
    /// Student Model - to represent the Students table.
    /// </summary>
    public class Student
    {
        BITCollege_LVContext context = new BITCollege_LVContext();

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        [ForeignKey("GradePointState")]
        public int GradePointStateId { get; set; }

        [ForeignKey("AcademicProgram")]
        public int? AcademicProgramId { get; set; }

        [Display(Name = "Student\nNumber")]
        public long StudentNumber { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        [Display(Name = "First\nName")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        [Display(Name = "Last\nName")]
        public string LastName { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string Address { get; set; }

        [Required]
        [StringLength(35, MinimumLength = 1)]
        public string City { get; set; }

        [Required]
        [RegularExpression("^(?:AB|BC|MB|N[BLTSU]|ON|PE|QC|SK|YT)*$", ErrorMessage = "Invalid Canadian Province Code.")]
        public string Province { get; set; }

        [Required]
        [Display(Name = "Postal\nCode")]
        [RegularExpression("^([ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ]) ([0-9][ABCEGHJKLMNPRSTVWXYZ][0-9])$", ErrorMessage = "Invalid Postal Code.")]
        public string PostalCode { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Grade\nPoint\nAverage")]
        [RegularExpression(@"^([0-3](\.\d+)?|[4](?:\.[0-9]+)?)$")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double? GradePointAverage { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double OutstandingFees { get; set; }

        public string Notes { get; set; }

        // Sets the student number to the next available number.
        public void SetNextStudentNumber()
        {
            StudentNumber = (long)StoredProcedure.NextNumber("NextStudent");
        }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        [Display(Name = "Address")]
        public string FullAddress
        {
            get
            {
                return String.Format("{0} {1}, {2} {3}", Address, City, Province, PostalCode);
            }
        }

        public void ChangeState()
        {
            GradePointState grade = context.GradePointStates.Find(GradePointStateId);

            int future = 0;

            while (future != grade.GradePointStateId)
            {
                future = grade.GradePointStateId;

                grade.StateChangeCheck(this);

                grade = context.GradePointStates.Find(GradePointStateId);
            }
        }

        public virtual GradePointState GradePointState { get; set; }
        public virtual AcademicProgram AcademicProgram { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }

        public virtual ICollection<StudentCard> StudentCard { get; set; }
    }

    /// <summary>
    /// StudentCard model - Represents the Student Card table.
    /// </summary>
    public class StudentCard
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StudentCardId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public long CardNumber { get; set; }

        public virtual Student Student { get; set; }
    }

    /// <summary>
    /// AcademicProgram Model - to represent the Academic Program table.
    /// </summary>
    public class AcademicProgram
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AcademicProgramId { get; set; }

        [Required]
        [Display(Name = "Program")]
        public string ProgramAcronym { get; set; }

        [Required]
        [Display(Name = "Program\nName")]
        public string Description { get; set; }

        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }

    /// <summary>
    /// GradePointState Model - to represent Grade Point State table.
    /// </summary>
    public abstract class GradePointState
    {
        protected static BITCollege_LVContext dataContext = new BITCollege_LVContext();

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int GradePointStateId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double LowerLimit { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double UpperLimit { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double TuitionRateFactor { get; set; }

        [Display(Name = "Grade\nPoint\nState")]
        public string Description
        {
            get
            {
                return StateCourseFormat.SCFormat(GetType().Name);
            }
        }

        public virtual double TuitionRateAdjustment(Student student)
        {
            return TuitionRateFactor;
        }

        public virtual void StateChangeCheck(Student student)
        {
            return;
        }

        public virtual ICollection<Student> Student { get; set; }
    }

    /// <summary>
    /// Registration Model - to represent Registration table.
    /// </summary>
    public class Registration
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RegistrationId { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [Display(Name = "Registration\nNumber")]
        public long RegistrationNumber { get; set; }

        [Required]
        [Display(Name = "Registration\nDate")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime RegistrationDate { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "Ungraded")]
        [RegularExpression(@"((0(\.[0-9]*)?)|(1(\.0)?))")]
        public double? Grade { get; set; }

        public string Notes { get; set; }

        // Sets the registration number to the next available number.
        public void SetNextRegistrationNumber()
        {
            RegistrationNumber = (long)StoredProcedure.NextNumber("NextRegistration");
        }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }

    /// <summary>
    /// SuspendedState Model - to represent Suspended State table.
    /// </summary>
    public class SuspendedState : GradePointState
    {
        protected static SuspendedState suspendedState;

        private SuspendedState()
        {
            LowerLimit = 0.00;
            UpperLimit = 1.00;
            TuitionRateFactor = 1.1;
        }

        public static SuspendedState GetInstance()
        {

            if (suspendedState == null)
            {
                suspendedState = dataContext.SuspendedStates.SingleOrDefault();

                if (suspendedState == null)
                {
                    suspendedState = new SuspendedState();
                    dataContext.SuspendedStates.Add(suspendedState);
                    dataContext.SaveChanges();
                }
            }
            return suspendedState;
        }

        public override double TuitionRateAdjustment(Student student)
        {
            if (student.GradePointAverage < 0.75 && student.GradePointAverage > 0.50)
            {
                TuitionRateFactor += 0.02;
            }
            else if (student.GradePointAverage < 0.50)
            {
                TuitionRateFactor += 0.05;
            }

            return TuitionRateFactor;
        }

        public override void StateChangeCheck(Student student)
        {
            if (student.GradePointAverage > UpperLimit)
            {
                student.GradePointStateId = ProbationState.GetInstance().GradePointStateId;
            }
        }
    }

    /// <summary>
    /// ProbabtionState Model - to represent Probabtion State table.
    /// </summary>
    public class ProbationState : GradePointState
    {
        private static ProbationState probationState;

        private ProbationState()
        {
            LowerLimit = 1.00;
            UpperLimit = 2.00;
            TuitionRateFactor = 1.075;
        }

        public static ProbationState GetInstance()
        {
            if (probationState == null)
            {
                probationState = dataContext.ProbationStates.SingleOrDefault();

                if (probationState == null)
                {
                    probationState = new ProbationState();
                    dataContext.ProbationStates.Add(probationState);
                    dataContext.SaveChanges();
                }
            }
            return probationState;
        }

        public override double TuitionRateAdjustment(Student student)
        {
            var listOfRegistrations = dataContext.Registrations.Where(x => x.StudentId == student.StudentId && x.Grade != null);

            int numberOfRegistrations = listOfRegistrations.ToList().Count;

            if(numberOfRegistrations >= 5)
            {
                TuitionRateFactor += 0.035;
            }
            
            return TuitionRateFactor;
        }

        public override void StateChangeCheck(Student student)
        {
            if (student.GradePointAverage > UpperLimit)
            {
                student.GradePointStateId = RegularState.GetInstance().GradePointStateId;
            }
            if (student.GradePointAverage < LowerLimit)
            {
                student.GradePointStateId = SuspendedState.GetInstance().GradePointStateId;
            }
        }
    }



    /// <summary>
    /// RegularState Model - to represeent Regular State table.
    /// </summary>
    public class RegularState : GradePointState
    {
        private static RegularState regularState;

        private RegularState()
        {
            LowerLimit = 2;
            UpperLimit = 3.70;
            TuitionRateFactor = 1;
        }

        public static RegularState GetInstance()
        {
            if (regularState == null)
            {
                regularState = dataContext.RegularStates.SingleOrDefault();
                if (regularState == null)
                {
                    regularState = new RegularState();
                    dataContext.RegularStates.Add(regularState);
                    dataContext.SaveChanges();
                }
            }
            return regularState;
        }

        public override double TuitionRateAdjustment(Student student)
        {
            return TuitionRateFactor;
        }

        public override void StateChangeCheck(Student student)
        {
            if (student.GradePointAverage > UpperLimit)
            {
                student.GradePointStateId = HonoursState.GetInstance().GradePointStateId;
            }
            if (student.GradePointAverage < LowerLimit)
            {
                student.GradePointStateId = ProbationState.GetInstance().GradePointStateId;
            }
        }
    }

    /// <summary>
    /// HonoursState Model - to represent Honour State table.
    /// </summary>
    public class HonoursState : GradePointState
    {
        BITCollege_LVContext context = new BITCollege_LVContext();

        private static HonoursState honoursState;

        private HonoursState()
        {
            LowerLimit = 3.7;
            UpperLimit = 4.5;
            TuitionRateFactor = 0.9;
        }

        public static HonoursState GetInstance()
        {
            if (honoursState == null)
            {
                honoursState = dataContext.HonoursStates.SingleOrDefault();

                if (honoursState == null)
                {
                    honoursState = new HonoursState();
                    dataContext.HonoursStates.Add(honoursState);
                    dataContext.SaveChanges();
                }
            }
            return honoursState;
        }

        public override double TuitionRateAdjustment(Student student)
        {
            var listOfRegistrations = dataContext.Registrations.Where(x => x.StudentId == student.StudentId && x.Grade != null);

            int numberOfRegistrations = listOfRegistrations.ToList().Count;

            if (numberOfRegistrations >= 5)
            {
                TuitionRateFactor -= 0.05;

            }
            if (student.GradePointAverage > 4.25)
            {
                TuitionRateFactor -= 0.02;
            }

            return TuitionRateFactor;
        }

        public override void StateChangeCheck(Student student)
        {
            if (student.GradePointAverage < LowerLimit)
            {
                student.GradePointStateId = RegularState.GetInstance().GradePointStateId;
            }
        }
    }

    /// <summary>
    /// Course Model - to represent course table.
    /// </summary>
    public abstract class Course
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CourseId { get; set; }

        [ForeignKey("AcademicProgram")]
        public int? AcademicProgramId { get; set; }

        public String CourseNumber { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Credit\nHours")]
        public double CreditHours { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Tuition\nAmount")]
        public double TuitionAmount { get; set; }

        [Display(Name = "Course\nType")]
        public string CourseType
        {
            get
            {
                return StateCourseFormat.SCFormat(GetType().Name);
            }
        }

        public string Notes { get; set; }

        // Abstract method for SetNextCourseNumber.
        public abstract void SetNextCourseNumber();

        public virtual AcademicProgram AcademicProgram { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
    }

    /// <summary>
    /// GradedCourse Model - to represent Graded Course table.
    /// </summary>
    public class GradedCourse : Course
    {
        [Required]
        [Display(Name = "Assignment\nWeight")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double AssignmentWeight { get; set; }

        [Required]
        [Display(Name = "Midterm\nWeight")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double MidtermWeight { get; set; }

        [Required]
        [Display(Name = "Final\nWeight")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public double FinalWeight { get; set; }

        // Overrides the inherited method with the new course number.
        public override void SetNextCourseNumber()
        {
            CourseNumber = "G-";
            long? storedProcedure = StoredProcedure.NextNumber("NextGradedCourse");

            CourseNumber = CourseNumber + (storedProcedure).ToString();
        }
    }

    /// <summary>
    /// AuditCourse Model - to represent Audit Course table.
    /// </summary>
    public class AuditCourse : Course
    {
        // Overrides the inherited method with the new course number.
        public override void SetNextCourseNumber()
        {
            CourseNumber = "A-";
            long? storedProcedure = StoredProcedure.NextNumber("NextAuditCourse");

            CourseNumber = CourseNumber + ((long)storedProcedure).ToString();
        }
    }

    /// <summary>
    /// MasteryCourse Model - to represent Mastery Course table.
    /// </summary>
    public class MasteryCourse : Course
    {
        [Required]
        [Display(Name = "Maximum\nAttempts")]
        public int MaximumAttempts { get; set; }

        // Overrides the inherited method with the new course number.
        public override void SetNextCourseNumber()
        {
            CourseNumber = "M-";
            long? storedProcedure = StoredProcedure.NextNumber("NextMasteryCourse");

            CourseNumber = CourseNumber + ((long)storedProcedure).ToString();
        }
    }

    /// <summary>
    /// NextUniqueNumber Model - to represent Next Unique Number table.
    /// Contains the next available numbers for the Discriminators.
    /// </summary>
    public abstract class NextUniqueNumber
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public int NextUniqueNumberId { get; set; }

        [Required]
        public long NextAvailableNumber { get; set; }

        protected static BITCollege_LVContext dataContext = new BITCollege_LVContext();
    }

    /// <summary>
    /// Implements the singleton pattern to create an instance of NextGradedCourse and sets the NextAvailableNumber.
    /// </summary>
    public class NextGradedCourse : NextUniqueNumber
    {
        private static NextGradedCourse nextGradedCourse;

        private NextGradedCourse()
        {
            NextAvailableNumber = 200000;
        }

        public static NextGradedCourse GetInstance()
        {
            if(nextGradedCourse == null)
            {
                nextGradedCourse = dataContext.NextGradedCourses.SingleOrDefault();
      
                if(nextGradedCourse == null)
                {
                    nextGradedCourse = new NextGradedCourse();
                    dataContext.NextGradedCourses.Add(nextGradedCourse);
                    dataContext.SaveChanges();
                }
            }
            return nextGradedCourse;
        }
    }

    /// <summary>
    /// Implements the singleton pattern to create an instance of NextStudent and sets the NextAvailableNumber.
    /// </summary>
    public class NextStudent : NextUniqueNumber
    {
        private static NextStudent nextStudent;

        private NextStudent()
        {
            NextAvailableNumber = 20000000;
        }

        public static NextStudent GetInstance()
        {
            if(nextStudent == null)
            {
                nextStudent = dataContext.NextStudents.SingleOrDefault();

                if(nextStudent == null)
                {
                    nextStudent = new NextStudent();
                    dataContext.NextStudents.Add(nextStudent);
                    dataContext.SaveChanges();
                }
            }
            return nextStudent;
        }
    }

    /// <summary>
    /// Implements the singleton pattern to create an instance of NextAuditCourse and sets the NextAvailableNumber.
    /// </summary>
    public class NextAuditCourse : NextUniqueNumber
    {
        private static NextAuditCourse nextAuditCourse;

        private NextAuditCourse()
        {
            NextAvailableNumber = 2000;
        }

        public static NextAuditCourse GetInstance()
        {
            if(nextAuditCourse == null)
            {
                nextAuditCourse = dataContext.NextAuditCourses.SingleOrDefault();

                if(nextAuditCourse == null)
                {
                    nextAuditCourse = new NextAuditCourse();
                    dataContext.NextAuditCourses.Add(nextAuditCourse);
                    dataContext.SaveChanges();
                }
            }
            return nextAuditCourse;
        }
    }

    /// <summary>
    /// Implements the singleton pattern to create an instance of NextRegistration and sets the NextAvailableNumber.
    /// </summary>
    public class NextRegistration : NextUniqueNumber
    {
        private static NextRegistration nextRegistration;

        private NextRegistration()
        {
            NextAvailableNumber = 700;
        }

        public static NextRegistration GetInstance()
        {
            if (nextRegistration == null)
            {
                nextRegistration = dataContext.NextRegistrations.SingleOrDefault();

                if (nextRegistration == null)
                {
                    nextRegistration = new NextRegistration();
                    dataContext.NextRegistrations.Add(nextRegistration);
                    dataContext.SaveChanges();
                }
            }
            return nextRegistration;
        }
    }

    /// <summary>
    /// Implements the singleton pattern to create an instance of NextMastertyCourse and sets the NextAvailableNumber.
    /// </summary>
    public class NextMasteryCourse : NextUniqueNumber
    {
        private static NextMasteryCourse nextMasteryCourse;

        private NextMasteryCourse()
        {
            NextAvailableNumber = 20000;
        }

        public static NextMasteryCourse GetInstance()
        {
            if(nextMasteryCourse == null)
            {
                nextMasteryCourse = dataContext.NextMasteryCourses.SingleOrDefault();

                if(nextMasteryCourse == null)
                {
                    nextMasteryCourse = new NextMasteryCourse();
                    dataContext.NextMasteryCourses.Add(nextMasteryCourse);
                    dataContext.SaveChanges();
                }
            }
            return nextMasteryCourse;
        }
    }

    /// <summary>
    /// Executes the stored precedure and return the new value.
    /// </summary>
    public static class StoredProcedure
    {
        public static long? NextNumber(string discriminator)
        {
            // Try catch block to handle exceptions.
            //  If it catches an exception it returns null.
            try
            {
                // Connects to the database.
                SqlConnection connection = new SqlConnection("Data Source=localhost; Initial Catalog=BITCollege_LVContext;Integrated Security=True");
                // Initializes a default value for the return value.
                long? returnValue = 0;
                // Instantiates a SqlCommand object with the next_number stored procedure and a reference to the connection object as parameters.
                SqlCommand storedProcedure = new SqlCommand("next_number", connection);
                // Sets the SqlCommand object to interpret stored procedures.
                storedProcedure.CommandType = CommandType.StoredProcedure;
                // Adds the discriminator to the SqlParameterCollection.
                storedProcedure.Parameters.AddWithValue("@Discriminator", discriminator);
                // Creates an SqlParameter with the parameters of @NewVal with a type of BigInt.
                SqlParameter outputParameter = new SqlParameter("@NewVal", SqlDbType.BigInt)
                {
                    // Sets the value of @NewVal to output only.
                    Direction = ParameterDirection.Output
                };
                // Adds the created SqlParameter to the SqlParameterCollection.
                storedProcedure.Parameters.Add(outputParameter);
                // Opens the connection.
                connection.Open();
                // Executes the storedProcedure command.
                storedProcedure.ExecuteNonQuery();
                // Closes the connection.
                connection.Close();
                // Gets the value of the parameter of @NewVal
                returnValue = (long?)outputParameter.Value;
                // Returns the new value from the stored procedure.
                return returnValue;
            }
            catch
            {
                return null;
            }
        }
    }
}