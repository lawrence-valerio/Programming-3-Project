using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Utility
{
    public class StateCourseFormat
    {
        public static string SCFormat(string a)
        {
            string result = "";

            try
            {
                string trimStateCourse = a.Substring(0, a.IndexOf('_'));
                string courseString = trimStateCourse.Substring(trimStateCourse.Length - 6, 6);
                if (courseString == "Course")
                {
                    result = trimStateCourse.Substring(0, trimStateCourse.Length - 6);
                }
            }
            catch
            {

                result = a.Substring(0, a.Length - 5);
            }

            return result;
        }
    }
}

