using FirstMVCPractise.Models;
using FirstMVCPractise.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FirstMVCPractise.Controllers
{
    public class UserController : Controller
    {
        private UserRespository userRespository;
        public UserController()
        {
            userRespository = new UserRespository();
        }
        // GET: User
        public async Task<ActionResult> Index()
        {
            var users = await userRespository.GetAllUsers();
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (!ModelState.IsValid)
                return View();
            else
            {
                var status = userRespository.Create(user);
                return RedirectToAction("Index", "User");
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            var user = await userRespository.GetById(id);
            return View(user);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var user = await userRespository.GetById(id);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var status = userRespository.Update(user, user.UserId);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var status = userRespository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}