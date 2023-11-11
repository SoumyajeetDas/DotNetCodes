using Authentication_With_Identity.Models;
using Authentication_With_Identity.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Authentication_With_Identity.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public IActionResult AdminSignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminSignUp(SignUpModel signUpModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var code = await accountRepository.AdminSignUpAsync(signUpModel);

            if(code== "User Exists" || code== "Not Succeded")
            {
                ViewBag.Status = code;
                return View();
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
        }

        public IActionResult UserSignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserSignUp(SignUpModel signUpModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var code = await accountRepository.UserSignUpAsync(signUpModel);

            if (code == "User Exists" || code == "Not Succeded")
            {
                ViewBag.Status = code;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Login(SignInModel signInModel)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var k = await accountRepository.LoginAsync(signInModel);

            if(k== "Failure" || k == "Wrong Password or Role")
            {
                ViewBag.Error = k;
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await accountRepository.Logout();
            return RedirectToAction("Login","Account");
        }
    }
}
