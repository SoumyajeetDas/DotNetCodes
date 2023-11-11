using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelperCheck.Models;

namespace HelperCheck.Controllers
{
    public class SimpleController : Controller
    {
        // GET: Simple
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult Index2(int? id=7) //@Html.ActionLink("Link Text","Target","Passing any parameter to the url")
        {
            ViewBag.num = id;
            return View();
        }

        public ActionResult Index3()
        {
            return View();
        }

        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult Indes5()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowDetails(Customer c)
        {
            return View(c);
        }

        [HttpPost]
        public ActionResult ShowDetails1(Customer cu)
        {
            return View(cu);
        }


    }
}