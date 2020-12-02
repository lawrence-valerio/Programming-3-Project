using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using BITCollege_LV.Data;
using BITCollege_LV.Models;
using Utility;

namespace BITCollegeWindows
{
    class BatchProcess
    {
        BITCollege_LVContext db = new BITCollege_LVContext();

        string inputFileName;
        string logFileName;
        string logData;

        /// <summary>
        /// This method will process all detail errors found within the current file being processed.
        /// </summary>
        /// <param name="beforeQuery">Represents the records that existed before the round of validation.</param>
        /// <param name="afterQuery">Represents the records that remained following the round of validation.</param>
        /// <param name="message">Represents the error message that is to be written to the log file based on the record failing the round of validation.</param>
        private void ProcessErrors(IEnumerable<XElement> beforeQuery, IEnumerable<XElement> afterQuery, string message)
        {
            IEnumerable<XElement> errors = beforeQuery.Except(afterQuery);

            foreach (XElement xerrors in errors)
            {
                logData += "\r\n-------ERROR-------";
                logData += "\r\nFile: " + inputFileName;
                logData += "\r\nProgram: " + xerrors.Element("program");
                logData += "\r\nStudent Number: " + xerrors.Element("student_no");
                logData += "\r\nCourse Number: " + xerrors.Element("course_no");
                logData += "\r\nRegistration Number: " + xerrors.Element("registration_no");
                logData += "\r\nType: " + xerrors.Element("type");
                logData += "\r\nGrade: " + xerrors.Element("grade");
                logData += "\r\nNotes: " + xerrors.Element("notes");
                logData += "\r\nNodes: " + xerrors.Elements().Nodes().Count();
                logData += "\r\n" + message;
                logData += "\r\n-------------------";
            }
        }

        /// <summary>
        /// Verify the attributes of the root element of the xml.
        /// </summary>
        private void ProcessHeader()
        {
            XDocument xDocument = XDocument.Load(inputFileName);

            XElement studentUpdate = xDocument.Element("student_update");

            XAttribute xProgram = studentUpdate.Attribute("program");
            string program = xProgram.Value;

            AcademicProgram academicProgram = db.AcademicPrograms.Where(x => x.ProgramAcronym == program).SingleOrDefault();

            int sumStudentNo = 0;
            IEnumerable<XElement> filteredStudentNo = xDocument.Descendants().Where(x => x.Name == "student_no");
            foreach (XElement xele in filteredStudentNo)
            {
                sumStudentNo = sumStudentNo + int.Parse(xele.Value);
            }

            if (studentUpdate.Attributes().Count() != 3)
            {
                throw new Exception(String.Format("Incorrect number of attributes" + " for file {0}\n", inputFileName));
            }

            if (studentUpdate.Attribute("date").Value != DateTime.Today.ToString("yyyy-MM-dd"))
            {
                throw new Exception(String.Format("Date does not match current date" + " for file {0}\n", inputFileName));
            }

            if (academicProgram == null)
            {
                throw new Exception(String.Format("Program does not exist" + " for file {0}\n", inputFileName));
            }

            if(int.Parse(studentUpdate.Attribute("checksum").Value) != sumStudentNo)
            {
                throw new Exception(String.Format("Checksum value is incorrect" + " for file {0}\n", inputFileName));
            }
        }

        /// <summary>
        /// Verify the contents of the inputfile until it passes all verification and passes that transaction to ProcessTransaction method.
        /// Inbetween checks it will pass the previous record and the current record with the corresponding message to ProcessErrors method.
        /// </summary>
        private void ProcessDetails()
        {
            XDocument xDocument = XDocument.Load(inputFileName);

            IEnumerable<XElement> transactionElements = xDocument.Descendants().Where(x => x.Name == "transaction");

            IEnumerable<XElement> transactionChildElements = transactionElements.Where(x => x.Elements().Nodes().Count() == 7);
            ProcessErrors(transactionElements, transactionChildElements, "Transaction element does not have 7 child elements.");

            IEnumerable<XElement> programMatch = transactionChildElements.Where(x => x.Element("program").Value == xDocument.Element("student_update").Attribute("program").Value);
            ProcessErrors(transactionChildElements, programMatch, "Program element value does not match the program attribute of the root element.");

            IEnumerable<XElement> numericType = programMatch.Where(x => Numeric.IsNumeric(x.Element("type").Value, System.Globalization.NumberStyles.Number));
            ProcessErrors(programMatch, numericType, "Type element value is not numeric.");

            IEnumerable<XElement> gradeCheck = numericType.Where(x => Numeric.IsNumeric(x.Element("grade").Value, System.Globalization.NumberStyles.Number) || x.Element("grade").Value == "*");
            ProcessErrors(numericType, gradeCheck, "Grade element value is incorrect.");

            IEnumerable<XElement> typeValueCheck = gradeCheck.Where(x => x.Element("type").Value == "1" || x.Element("type").Value == "2");
            ProcessErrors(gradeCheck, typeValueCheck, "Type element does not have the value of 1 or 2.");

            IEnumerable<XElement> gradeTypeCheck = typeValueCheck.Where(x => (x.Element("type").Value == "1" && x.Element("grade").Value == "*") || (x.Element("type").Value == "2" && (double.Parse(x.Element("grade").Value) >= 0 && double.Parse(x.Element("grade").Value) <= 100)));
            ProcessErrors(typeValueCheck, gradeTypeCheck, "Grade element does not have a value of * with a type element value of 1 or Grade element does not have a value between 0-100 with a Type element value of 2.");

            IEnumerable<long> listOfStudentsQuery = db.Students.Select(x => x.StudentNumber).ToList();
            IEnumerable<XElement> studentNoCheck = gradeTypeCheck.Where(x => listOfStudentsQuery.Contains(long.Parse(x.Element("student_no").Value)));
            ProcessErrors(gradeTypeCheck, studentNoCheck, "Student_no element value is not a registered student number.");

            IEnumerable<string> listOfCourseNumbers = db.Courses.Select(x => x.CourseNumber).ToList();
            IEnumerable<XElement> courseNoCheck = studentNoCheck.Where(x => (x.Element("type").Value == "2" && x.Element("course_no").Value == "*") || (x.Element("type").Value == "1" && listOfCourseNumbers.Contains(x.Element("course_no").Value)));
            ProcessErrors(studentNoCheck, courseNoCheck, "Course_no element value does not have a value of * with a type element value of 2 or Course_no element value is not a valid course number");

            IEnumerable<long> listOfRegistrationNumbers = db.Registrations.Select(x => x.RegistrationNumber).ToList();
            IEnumerable<XElement> registrationNoCheck = courseNoCheck.Where(x => (x.Element("type").Value == "1" && x.Element("registration_no").Value == "*") || (x.Element("type").Value == "2" && listOfRegistrationNumbers.Contains(long.Parse(x.Element("registration_no").Value))));
            ProcessErrors(courseNoCheck, registrationNoCheck, "Registration_no element value does not have a value of * with a type element value of 1 or Registration_no element value is not a valid registration number");

            ProcessTransaction(registrationNoCheck);
        }

        /// <summary>
        /// Processes all valid transaction records to register a course for a student  
        /// or update the grade of a student. 
        /// </summary>
        /// <param name="transactionRecords">Represents argument transaction records.</param>
        private void ProcessTransaction(IEnumerable<XElement> transactionRecords)
        {
            foreach (XElement xele in transactionRecords)
            {
                int studentNo = int.Parse(xele.Element("student_no").Value);
                int type = int.Parse(xele.Element("type").Value);
                string notes = xele.Element("notes").Value;

                CollegeRegistrationService.CollegeRegistrationClient service = new CollegeRegistrationService.CollegeRegistrationClient();

                if (type == 1)
                {
                    string course_no = xele.Element("course_no").Value;
                    long student_no = long.Parse(xele.Element("student_no").Value);
                    Course course = db.Courses.Where(x => x.CourseNumber == course_no).SingleOrDefault();
                    Student student = db.Students.Where(x => x.StudentNumber == student_no).SingleOrDefault();
                    int courseId = course.CourseId;
                    int studentId = student.StudentId;

                    int registerCourseCheck = service.RegisterCourse(studentId, courseId, notes);
                    
                    if(registerCourseCheck != 0)
                    {
                        logData += "\r\nError: " + BusinessRules.RegisterError(registerCourseCheck);
                    }
                    else
                    {
                        logData += "\r\nSuccessful Registration student " + studentNo + " course " + course_no;
                    }
                }
                else if(type == 2)
                {
                    int registrationNo = int.Parse(xele.Element("registration_no").Value);
                    Registration registration = db.Registrations.Where(x => x.RegistrationNumber == registrationNo).SingleOrDefault();
                    int registrationId = registration.RegistrationId;

                    double grade = double.Parse(xele.Element("grade").Value);
                    double formattedGrade = double.Parse(xele.Element("grade").Value)/100;
                    
                    if (formattedGrade >= 0 && formattedGrade <= 1)
                    {
                        try
                        {
                            service.UpdateGrade(formattedGrade, registrationId, notes);
                            logData += "\r\ngrade " + grade + " applied to student " + studentNo + " for registration " + registrationNo;
                        }
                        catch (Exception errMessage)
                        {
                            logData += "\r\nError: " + errMessage;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Deletes the COMPLETE xml of the corresponding input file and concatenates
        /// the corresponding input file with 'COMPLETE-'.
        /// Writes all the data from the logData variable to the log file.
        /// </summary>
        /// <returns>String of all the data from the logData.</returns>
        public string WriteLogData()
        {
            StreamWriter writer = new StreamWriter(logFileName, true);

            if (File.Exists("COMPLETE-" + inputFileName))
            {
                File.Delete("COMPLETE-" + inputFileName);
            }

            if (File.Exists(inputFileName))
            {
                File.Move(inputFileName, "COMPLETE-" + inputFileName);
            }

            writer.Write(logData);
            writer.Close();

            string capturedLogData = logData;

            logData = "";
            logFileName = "";

            return capturedLogData;
        }

        /// <summary>
        /// Creates the filename for the xml and the log file. Once the filename is created it then proceeds
        /// with the detail and header processing.
        /// </summary>
        /// <param name="programAcronym">Represents argument program acronym</param>
        /// <param name="key">Represents argument key</param>
        public void ProcessTransmission(string programAcronym, string key)
        {
            int todayYear = DateTime.Today.Year;
            int dayOfYear = DateTime.Today.DayOfYear;
            string formattedFileName = string.Format("{0}-{1}-{2}", todayYear, dayOfYear, programAcronym);

            inputFileName = formattedFileName + ".xml";

            logFileName = "LOG " + inputFileName + ".txt";

            if (File.Exists(inputFileName))
            {
                try
                {
                    ProcessHeader();
                    ProcessDetails();
                }
                catch (Exception error)
                {
                    logData += "\r\n" + error.Message;
                }
            }
            else
            {
                logData += "\r\nXML file named " + inputFileName + " does not exists.";
            }
        }
    }
}
