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
        public ActionResult Index(int deptID)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.Employees.Where(emp => emp.departmentId == deptID).ToList();
            return View(employees);
        }

        public ActionResult Details(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.Employees.Single(emp => emp.EmployeeId == id);
            return View(employee);
        }
    }
}
