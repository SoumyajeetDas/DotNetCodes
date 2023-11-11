using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Razor_Syntax.Models;

namespace Razor_Syntax.Controllers
{
    public class SimpleController : Controller
    {
        // GET: Simple
        public ActionResult Index()
        {
            Employee e = new Employee();
            e.Emp_Name = "Soumyajeet";
            e.Emp_Id = 1;
            return View(e);
        }
    }
}