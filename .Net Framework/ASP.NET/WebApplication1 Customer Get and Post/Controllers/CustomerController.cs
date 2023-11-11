using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1_Customer_Get_and_Post.Models;

namespace WebApplication1_Customer_Get_and_Post.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult GetCustomer()
        {
            return View();
        }

        //[HttpPost]
        //public ViewResult DisplayCustomer(Customer cu)
        //{
        //    return View(cu);
        //}

        [HttpPost]
        public ViewResult SetCustomer(Customer cu)
        {
           
            return View("DisplayCustomer",cu);
        }
    }
}