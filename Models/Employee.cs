using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeePayrollMVC.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int empid { get; set; }

        public string name { get; set; }

        public string gender { get; set; }

        public int deptid { get; set; }

        [ForeignKey("deptid")]
        public Department Department { get; set; }

        public int salaryid { get; set; }

        [ForeignKey("salaryid")]
        public Salary salary { get; set; }

        public DateTime startdate { get; set; }

        public string description { get; set; }
    }
}