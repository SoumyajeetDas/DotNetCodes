using Login_Logout_and_SignUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Login_Logout_and_SignUp.Controllers
{
    [AllowAnonymous] //Need not to be authenticated and authorized . This is written above controller. You can also place it above the action method
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include ="Username,Password")]User u)
        {
            using (EmployeeUserUserRoleContext context = new EmployeeUserUserRoleContext())
            {
                bool isValid = context.Users.Any(x => x.Username == u.Username && x.Password == u.Password);
                if(isValid)
                {
                    FormsAuthentication.SetAuthCookie(u.Username, true); // Without this Authorization will not work
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                    return View();
                }
            }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User u)
        {
            if(ModelState.IsValid)
            {
                using(EmployeeUserUserRoleContext context = new EmployeeUserUserRoleContext())
                {
                    context.Users.Add(u);
                    context.SaveChanges();
                    
                }
                return RedirectToAction("Login");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}