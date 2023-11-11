using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizManagementSystem.Models;
using QuizManagementSystem.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuizManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private IStudentAccountRepository accountRepository;
        public HomeController(IStudentAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        

        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var studentobj = accountRepository.Login(student);
            if (studentobj == null)
            {
                ViewBag.Error = "Failure";
                return View();
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, studentobj.Username));
            identity.AddClaim(new Claim(ClaimTypes.Role, studentobj.Role));
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            HttpContext.Session.SetString("JWTToken", studentobj.Token);
            return RedirectToAction("Index", "GetQuestion");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            HttpContext.Session.SetString("JWTToken", "");
            HttpContext.Session.Remove("JWTToken");
            //return RedirectToAction("Login", "Home");
            return RedirectToAction("Login");
        }

    }
}
