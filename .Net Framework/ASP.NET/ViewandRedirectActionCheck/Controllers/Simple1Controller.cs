using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewandRedirectActionCheck.Models;

namespace ViewandRedirectActionCheck.Controllers
{
    public class Simple1Controller : Controller
    {
        // GET: Simple1
        public ActionResult Index(Employee e)
        {
            
            return View(e);
        }
    }
}