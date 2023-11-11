using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Partial_View.Controllers
{
    public class ChTrustController : Controller
    {
        // GET: ChTrust
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChTrust()
        {
            return View();
        }

        // Implement 'HeaderNavBar' action 

        public PartialViewResult _HeaderNavBar()
        {
            return PartialView();
        }

        // Implement 'FooterNavBar' action 

        public PartialViewResult _FooterNavBar()
        {
            return PartialView();
        }
    }
}