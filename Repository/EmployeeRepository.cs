using EmployeePayrollMVC.Models;
using EmployeePayrollMVC.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePayrollMVC.Repository
{
    public class EmployeeRepository
    {
        EmployeeContext dbContext = new EmployeeContext();
        public List<EmployeeViewModel> GetEmployees()
        {
            try
            {
                List<EmployeeViewModel> list = (from e in dbContext.Employees
                                                join d in dbContext.Departments on e.deptid equals d.deptid
                                                join s in dbContext.Salaries on e.salaryid equals s.salaryid
                                                select new EmployeeViewModel
                                                {
                                                    empid = e.empid,
                                                    name = e.name,
                                                    gender = e.gender,
                                                    deptid = d.deptid,
                                                    department = d.deptname,
                                                    salaryid = s.salaryid,
                                                    amount = s.amount,
                                                    startdate = e.startdate,
                                                    description = e.description
                                                }).ToList<EmployeeViewModel>();

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}