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
        public ActionResult RegisterEmployee()
        {
            return View();
        }
        public ActionResult Index()
        {
            List<EmployeeViewModel> list = employeeRepository.GetEmployees();
            return View(list);
        }
        [HttpPost]
        public ActionResult RegisterEmployee(RegisterRequestModel employee)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = employeeRepository.RegisterEmployee(employee);
            }
            ModelState.Clear();
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}