using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoutingCheck.Models;

namespace RoutingCheck.Controllers
{
    [RoutePrefix("Stu")]
    public class SimpleController : Controller
    {
        List<Student> li = new List<Student>()
        {
            new Student(){Id=1,Name="Soumyajeet",Address = new Address(){HomeNumber=1, City="Chandannagore"}},
            new Student(){Id=2,Name="Sounak",Address = new Address(){HomeNumber=2, City="Bamkura"}},
            new Student(){Id=3,Name="Dippya",Address = new Address(){HomeNumber=3, City="Kolkata"}}
        };
        // GET: Simple
        [Route("Students")]
        public ActionResult GetAllStudents()
        {
            var stu = li;
            return View(stu);
        }

        [Route("StudentId/{id:int}")]
        public ActionResult GetStudent(int id)
        {
            Student stu = li.FirstOrDefault(obj => obj.Id == id);
            return View(stu);
        }

        [Route("StudentId/{id:regex([a-zA-Z]+)}")]
        public string MyString(string id)
        {
            return id;
        }

        [Route("StudentAddress/{ids}/Address")]
        [Route("StudentAddress/{ids}")]
        public ActionResult GetStudentAddress(int ids)
        {
            var address = li.Where(obj => obj.Id == ids).Select(x => x.Address).FirstOrDefault();
            return View(address);
        }
       
        [Route("~/about_us")]
        public string AboutUs()
        {
            return "This is About Us";
        }

    }
}