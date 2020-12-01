using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BITCollege_LV.Data;
using BITCollege_LV.Models;
using Utility;

namespace BITCollegeWindows
{
    /// <summary>
    /// given:TO BE MODIFIED
    /// this class is used to capture data to be passed
    /// among the windows forms
    /// </summary>
    public class ConstructorData
    {
        public Student student { get; set; }

        public Registration registration { get; set; }
    }
}
