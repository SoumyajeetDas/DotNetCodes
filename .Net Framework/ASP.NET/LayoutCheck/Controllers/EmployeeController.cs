using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayoutCheck.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Emoloyee
       
        
        public ActionResult AddEmployee()
        {
            return View();
        }

        public ActionResult DisplayEmployee()
        {
            return View("DisplayEmployee", "_Layout1");
        }
    }
}