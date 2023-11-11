using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Working_With_HTTP_POST.Models;

namespace Working_With_HTTP_POST.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Course()
        {
            Course c = new Course();
            return View(c);
        }

        [HttpPost]
        public ActionResult Course(Course c)
        {
            return View("ShowDetails",c);
        }
    }
}