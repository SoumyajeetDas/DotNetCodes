using HandleErrorCheck.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandleErrorCheck.Controllers
{
   
    public class Simple1Controller : Controller
    {
        // GET: Simple1
        [MyException]
        public ActionResult Index()
        {
            return View();
        }
    }
}