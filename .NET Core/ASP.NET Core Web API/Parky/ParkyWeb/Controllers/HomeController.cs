using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ParkyWeb.Models;
using ParkyWeb.Repository.IRepository;
using ParkyWeb.Static_Details;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ParkyWeb.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountRepository accountRepository;

        public HomeController(ILogger<HomeController> logger, IAccountRepository accountRepository)
        {
            _logger = logger;
            this.accountRepository = accountRepository;
        }

     
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var userobj = await accountRepository.LoginAsync(SD.AccountAPIPath + "authenticate", user);
            if(userobj.Token==null)
            {
                return View();  
            }

            //For cookie authentication we need to add all the claims given below
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, userobj.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, userobj.Role));
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            HttpContext.Session.SetString("JWTToken", userobj.Token);
            return RedirectToAction("Index", "HomePage");
        }
        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var result = await accountRepository.RegisterAsync(SD.AccountAPIPath + "Register", user);
            if (result==false)
            {
                return View();

            }
            
            return RedirectToAction("Login", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            HttpContext.Session.SetString("JWTToken", "");
            return RedirectToAction("Index", "HomePage");
        }

        
        public IActionResult DeniedPath()
        {
            return View();
        }
    }
}
