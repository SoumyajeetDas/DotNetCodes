using Authentication_With_Identity.Models;
using Authentication_With_Identity.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication_With_Identity.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IEmployeeRepository employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        
        public async Task<IActionResult> Index()
        {
            
            if(User.Identity.IsAuthenticated)
            {
                if(User.IsInRole(UserRoles.Admin))
                {
                    var emps = await employeeRepository.GetAllEmployees();
                    return View(emps);
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            
        }

       
    }
}
