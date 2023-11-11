using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attacker_Profile.Controllers
{
    public class AttackController : Controller
    {
        // GET: Attack
        public ActionResult Create()
        {
            return View();
        }
    }
}