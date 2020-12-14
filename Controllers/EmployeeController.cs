using EmployeePayrollMVC.Models.Common;
using EmployeePayrollMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();
        public ActionResult Index()
        {
            List<EmployeeViewModel> list = employeeRepository.GetEmployees();
            return View(list);
        }
    }
}