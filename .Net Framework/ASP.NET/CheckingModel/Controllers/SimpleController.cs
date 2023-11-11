using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CheckingModel.Models;

namespace CheckingModel.Controllers
{
    public class SimpleController : Controller
    {
        static List<Employee> lemp = new List<Employee>()
        {
            new Employee(){ Emp_Id = 1 , Emp_Name = "Soumyajeet"},
            new Employee(){ Emp_Id = 12 , Emp_Name = "Sounak"},
        };
        // GET: Simple
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult ShowDetail()
        {
            return View(lemp);
        }
    }
}