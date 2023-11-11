using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Partial_View.Models;

namespace Partial_View.Controllers
{
    public class SimpleController : Controller
    {

        static List<Employee> li = new List<Employee>()
        {
            new Employee(){Emp_Id=1,Emp_Name="Soumyajeet",Description="sdgergerwebeybw"},
            new Employee(){Emp_Id=2,Emp_Name="Sounak",Description="sdgergerwebeybw"},
            new Employee(){Emp_Id=3,Emp_Name="Dippya",Description="sdgergerwebeybw"},
            new Employee(){Emp_Id=4,Emp_Name="Sheroz",Description="sdgergerwebeybw"},
            new Employee(){Emp_Id=5,Emp_Name="Rohan",Description="sdgergerwebeybw"},
            new Employee(){Emp_Id=6,Emp_Name="Sourav",Description="sdgergerwebeybw"},
        };

        // GET: Simple
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult GetResult()
        {
            return View(li);
        }
    }
}