using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLesson1.Models;

namespace MvcLesson1.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index(int deptId)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employees.Where(emp => emp.departmentID == deptId).ToList();
            return View(employees);
        }

        public ActionResult Details(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(emp => emp.employeeId == id);
            return View(employee);
        }
    }
}
