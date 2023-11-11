using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TempDataCheck.Controllers
{
    public class SimpleController : Controller
    {
        // GET: Simple
        public ActionResult Index()
        {
            TempData["mykey"] = "Soumyajeet"; 
            TempData["mykey1"] = "Das";
            TempData.Keep("mykey"); // It will retain only the mykey value
            //TempData.Keep("mykey1"); It will retain only the mykey1 value and not the mykey value.
            //string name3 = TempData["mykey2"].ToString(); 
            return View();
        }

        public ActionResult Index1()
        {
            string name = TempData["mykey"].ToString(); 
            string name1 = TempData["mykey1"].ToString();
            //TempData.Keep("mykey1");
            TempData.Keep(); //It will retain both the mykey and mykey1 value.
            return View();
        }

        public ActionResult Index2()
        {
            string name = TempData["mykey"].ToString();
            string name2 = TempData["mykey1"].ToString();

            string name3 = TempData["mykey2"].ToString(); // It is used to access the data in the View in the Index1  --> view to Controller

            string name4 = TempData["mykey4"].ToString();  // Data passed from one controller to another --> Data is coming form Index13 of Simple1Controller

            //TempData["mykey3"] = "Khokha"; // Passing data from One Controller to another Controller --> This is going to Simple1Controller
            return View();
        }
    }
}