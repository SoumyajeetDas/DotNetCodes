using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1_Check.Controllers
{
    public class Simple1Controller : Controller
    {
        // GET: Simple1
        public ActionResult Index()
        {
            return View();
        }

        public string  Index1(int id  )
        {
            return "Id = "+id + " "  ;
        }
    }
}