using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1_Manual_Binding.Models;

namespace WebApplication1_Manual_Binding.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult GetCustomer()
        {
            //Customer cus = new Customer();
            return View();
        }

        [HttpPost]
        public ViewResult SetCustomer([Bind(Include = "Cust_Code,Cust_Name")]Customer cus)
        {
            return View(cus);
        }

        [HttpPost]
        public ViewResult SetCustomer1(FormCollection form)
        {
            ViewBag.Message = "Hi I am Soumyajeet";
            ViewBag.ccode = form["Cust_Code"];
            ViewBag.cname = form["Cust_Name"];
            ViewBag.ccity = form["Cust_City"];
            return View();
        }

        [HttpPost]
        public ViewResult SetCustomer2()
        {
            ViewData["Message"]= "Hi I am Soumyajeet";

            ViewData["ccode"] = Request.Form["Cust_Code"];
            ViewData["cname"] = Request.Form["Cust_Name"];
            ViewData["ccity"] = Request.Form["Cust_City"];
            return View();
        }
        [HttpGet]
        public ViewResult SetCustomer3(Customer cus)
        {
            return View(cus);
        }
    }
}