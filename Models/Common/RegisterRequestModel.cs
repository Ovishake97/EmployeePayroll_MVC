using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeePayrollMVC.Models.Common
{
    public class RegisterRequestModel
    {
        public int empid { get; set; }

        [Required]
        [StringLength(20,ErrorMessage ="Name max length is 20 characters")]
        public string name { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]

        public string department { get; set; }

        [Required]
        public string salaryid { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime startdate { get; set; }

        public string description { get; set; }
    }
}