using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewandRedirectActionCheck.Models;

namespace ViewandRedirectActionCheck.Controllers
{
    public class SimpleController : Controller
    {
        // GET: Simple
        public ActionResult Index()
        {
            Employee e = new Employee()
            {
                id = 1
            };
            return View("Index1",e);
        }
        public ViewResult Index1(Employee e)
        {
            return View();
        }

        public ActionResult Index2()
        {
            Employee e = new Employee()
            {
                id = 2
            };
            return RedirectToAction("Index", "Simple1",e);

        }
    }
}