using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Controllers_and_Actions.Controllers
{
    public class Ex1Controller : Controller
    {
        // GET: Ex1
        List<String> breakingNews = new List<String>()      //DO NOT change this declaration and values
        {
            "PM visit brings business","10% slash in GST","Top Player announced retirement","India wins series"
        };
        public ActionResult Index()
        {
            return View();
        }

        // Implement 'NewsByChoice' action  

        public string AllNews()
        {
            string s = "";
            foreach (var x in breakingNews)
            {
                s += x + "<br>";
            }
            return s;
        }


        // Implement 'AllNews' action

        public string NewsByChoice(int id)
        {
            string s = breakingNews[id];
            return "n = "+id;

        }
        
    }
}