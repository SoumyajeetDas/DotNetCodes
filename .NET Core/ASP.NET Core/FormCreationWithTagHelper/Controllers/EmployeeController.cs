using FormCreationWithTagHelper.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCreationWithTagHelper.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult AddNewEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewEmployee(Employee e)
        {
           
            return View("ShowEmployee", e);
        }

        public IActionResult ShowEmployee(Employee e)
        {
            return View();
        }
    }
}
