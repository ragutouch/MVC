using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLesson1.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewData["Products"] = new List<string>()
            {
                "Mobile",
                "Watch",
                "Notebook",
                "T-shirt",
                "Sandels"
            };
            return View();
        }

        public string GetDetails(string name, string id)
        {
            return "Product Name: " + name + "<br />ID: " + id;
        }

    }
}
