using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Partial_View_on_different_folders_other_than_Shared.Models;

namespace Partial_View_on_different_folders_other_than_Shared.Controllers
{
    public class SimpleController : Controller
    {
        // GET: Simple
        List<Employee> li = new List<Employee>()
        {
            new Employee(){Emp_Id=1,Emp_name="Soumyajeet"},
            new Employee(){Emp_Id=2,Emp_name="Dippya"}
        };

        public ActionResult Index()
        {
            return View(li);
        }


    }
}