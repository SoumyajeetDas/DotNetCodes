﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Login_Logout_and_SignUp.Models;

namespace Login_Logout_and_SignUp.Controllers
{
    public class UserRolesController : Controller
    {
        private EmployeeUserUserRoleContext db = new EmployeeUserUserRoleContext();

        // GET: UserRoles
        public ActionResult Index()
        {
            var userRoles = db.UserRoles.Include(u => u.User);
            return View(userRoles.ToList());
        }

        // GET: UserRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // GET: UserRoles/Create
        public ActionResult Create()
        {
            ViewBag.User_Id = new SelectList(db.Users, "Id", "Username");
            return View();
        }

        // POST: UserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserRole_Id,Role,User_Id")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                db.UserRoles.Add(userRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.User_Id = new SelectList(db.Users, "Id", "Username", userRole.User_Id);
            return View(userRole);
        }

        // GET: UserRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_Id = new SelectList(db.Users, "Id", "Username", userRole.User_Id);
            return View(userRole);
        }

        // POST: UserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserRole_Id,Role,User_Id")] UserRole userRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.User_Id = new SelectList(db.Users, "Id", "Username", userRole.User_Id);
            return View(userRole);
        }

        // GET: UserRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return View(userRole);
        }

        // POST: UserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRole userRole = db.UserRoles.Find(id);
            db.UserRoles.Remove(userRole);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
