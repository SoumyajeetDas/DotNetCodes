using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Working_with_Model_Binding.Models;

namespace Working_with_Model_Binding.Controllers
{
    public class Ex3Controller : Controller
    {
        // GET: Ex3
        public ActionResult Index()
        {
            Course c = new Course();
            c.CourseId = "C101";
            c.CourseName = "Java";
            c.Duration = 40;
            c.Level = "Beginner";
            return View("CourseDescription", c);
            
        }

        public ActionResult IndexChoice(int id)
        {
            if (id == 1)
            {
                Course c = new Course();
                c.CourseId = "C101";
                c.CourseName = "Java";
                c.Duration = 40;
                c.Level = "Beginner";
                return View("CourseDescription", c);
            }
            else
            {
                Department dept = new Department();
                dept.CourseList = new List<string>() { "Java", "DotNet", "Python", "Ruby" };
                return View("CourseList", dept);
            }

        }
        // Implement 'CourseDescription' action

        public ActionResult CourseDescription(Course course)
        {
            return View(course);
        }


        // Implement 'CourseList' action
        public ActionResult CourseList(Department dept)
        {
            return View(dept);
        }
    }
}