using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeePayrollMVC.Models.Common
{
    public class EmployeeViewModel
    {
        public int empid { get; set; }

        public string name { get; set; }

        public string gender { get; set; }

        public int deptid { get; set; }

        public string department { get; set; }

        public string amount { get; set; }

        public int salaryid { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime startdate { get; set; }

        public string description { get; set; }
    }
}