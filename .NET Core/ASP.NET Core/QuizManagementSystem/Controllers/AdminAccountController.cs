using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizManagementSystem.Models;
using QuizManagementSystem.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuizManagementSystem.Controllers
{
    public class AdminAccountController : Controller
    {
        private IAdminAccountRepository adminAccountRepository;

        public AdminAccountController(IAdminAccountRepository adminAccountRepository)
        {
            this.adminAccountRepository = adminAccountRepository;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var res = adminAccountRepository.AdminDuplicateCheck(admin.Username);

            if (res == true)
            {
                ViewBag.Failure = "Present";
                return View();
            }
            var result = await adminAccountRepository.Register(admin);


            if (result == null)
            {
                ViewBag.Failure = "Failure";
                return View();

            }
            else
            {
               
                return RedirectToAction("Login");
            }

        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var adminobj = adminAccountRepository.Login(admin);
            if (adminobj == null)
            {
                ViewBag.Failure = "Failure";
                return View();
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, adminobj.Username));
            identity.AddClaim(new Claim(ClaimTypes.Role, adminobj.Role));
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            HttpContext.Session.SetString("JWTToken", adminobj.Token);
            return RedirectToAction("UploadFile", "UploadFile");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            HttpContext.Session.SetString("JWTToken", "");
            //return RedirectToAction("Login", "Home");
            return RedirectToAction("Login");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPassword fp)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var res = adminAccountRepository.Find(fp);

            if(res!=null)
            {
                res.Password = fp.Password;

                var result = await adminAccountRepository.Update(res);
                if(result)
                {
                    ViewBag.Status = "Success";
                    return View();
                    

                }
                else
                {
                    ViewBag.Status = "Failure1";
                    return View();
                }
               
            }
            ViewBag.Status = "Failure2";
            return View();
        }

    }
}
