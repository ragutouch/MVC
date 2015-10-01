using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLesson1.Models;

namespace MvcLesson1.Controllers
{
    public class DepartmentController : Controller
    {
        public ActionResult Index()
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Department> departments = employeeContext.Departments.ToList();

            return View(departments);
        }

    }
}
