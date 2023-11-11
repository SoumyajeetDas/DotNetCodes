using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _modelcheck.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> logger = null;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            this.logger = logger;
        }
        Repository r = new Repository();
        public IActionResult GetAllEmployees()
        {
            logger.LogInformation("Entering into GetEmployess");
            return View(r.GetAllEmployees());
        }

        public IActionResult GetById(int id)
        {
            return View(r.GetById(id));
        }

        public ViewResult SearchEmployee(string name)
        {
            return View(r.SearchEmployee(name));
        }
    }
}
