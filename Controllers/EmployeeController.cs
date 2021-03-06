﻿using EmployeePayrollMVC.Models;
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
        public ActionResult Edit(Employee model)
        {
            Employee emp = employeeRepository.GetEmployee(model.empid);

            return View(emp);
        }
        public ActionResult Update(Employee model)
        {
            int data = employeeRepository.Update(model);
            if (data != 0)
                return RedirectToAction("Index");
            else
                return View("Edit");

        }
        public ActionResult Delete(Employee model)
        {
            Employee emp = employeeRepository.GetEmployee(model.empid);

            return View(emp);
        }
        [HttpPost]
        public ActionResult DeleteEmployee(Employee model)
        {
            int result = employeeRepository.DeleteEmployee(model.empid);
            if (result != 0)
                return RedirectToAction("Index");
            else
                return View("Delete", result);
        }
    }
}