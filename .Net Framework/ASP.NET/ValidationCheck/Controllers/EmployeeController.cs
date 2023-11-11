using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationCheck.Models;

namespace ValidationCheck.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult ShowData(Employee e)
        {
            if(ModelState.IsValid)
            {
                return View(e);
            }
            return View("Index");
        }
    }
}