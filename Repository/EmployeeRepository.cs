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
        public Employee GetEmployee(int id)
        {
            try
            {
                Employee list = dbContext.Employees.Where(x => x.empid == id).SingleOrDefault();

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool RegisterEmployee(RegisterRequestModel employee)
        {

            try
            {
                Employee validEmployee = dbContext.Employees.Where(x => x.name == employee.name && x.gender == employee.gender).FirstOrDefault();
                if (validEmployee == null)
                {
                    int departmentId = dbContext.Departments.Where(x => x.deptname == employee.department).Select(x => x.deptid).FirstOrDefault();
                    Employee newEmployee = new Employee()
                    {
                        name = employee.name,
                        gender = employee.gender,
                        deptid = departmentId,
                        salaryid = Convert.ToInt32(employee.salaryid),
                        startdate = employee.startdate,
                        description = employee.description
                    };
                    Employee returnData = dbContext.Employees.Add(newEmployee);
                }
                int result = dbContext.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int Update(Employee model)
        {
            var data = dbContext.Employees.FirstOrDefault(x => x.empid == model.empid);  
            if (data != null)
            {
                data.empid = model.empid;
                data.name = model.name;
                data.gender = model.gender;
                data.deptid = model.deptid;
                data.Department = model.Department;
                data.salaryid = model.salaryid;
                data.salary = model.salary;
                data.startdate = model.startdate;
                data.description = model.description;
                return dbContext.SaveChanges();
            }
            else
                return 0;
        }
        public int DeleteEmployee(int id)
        {
            try
            {
                Employee data = dbContext.Employees.Where(x => x.empid == id).SingleOrDefault();

                if (data != null)
                {
                    dbContext.Employees.Remove(data);
                    return dbContext.SaveChanges();
                }
                else
                    return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}