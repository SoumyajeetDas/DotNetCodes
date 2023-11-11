using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1_Model_Binding_CRUD.Models;

namespace WebApplication1_Model_Binding_CRUD.Controllers
{
    public class CustomerCRUDController : Controller
    {
        static List<Customer> customers = new List<Customer>()
        {
            new Customer{CustCode = 1, CustName ="Soumyajeet", CustCity="Kolkata"},
            new Customer{CustCode = 2, CustName ="Dippya", CustCity="Orissa"},
        };

        // GET: CustomerCRUD
        public ActionResult Index()
        {
            IEnumerable<Customer> customer = customers.ToList();
            return View(customer);
        }

        // GET: CustomerCRUD/Details/5
        public ActionResult Details(int id)
        {
            Customer cus = customers.FirstOrDefault(obj => obj.CustCode == id);
            return View(cus);
        }

        // GET: CustomerCRUD/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerCRUD/Create
        [HttpPost] // Whenever form to client data coming that need to be shown to the user then use HttpPost
        public ActionResult Create(Customer cus) // ActionResult tells what actio  will it perform. 
        {
            try
            {
                // TODO: Add insert logic here

                if(cus.CustCode !=0 && cus.CustCity != null && cus.CustName!=null)
                {
                    customers.Add(cus);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Some Fields are missing";
                    throw new Exception();
                }


                
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerCRUD/Edit/5
        public ActionResult Edit(int id)
        {
            Customer cus = customers.FirstOrDefault(obj => obj.CustCode == id);
            return View(cus);
        }

        // POST: CustomerCRUD/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                Customer cus = customers.FirstOrDefault(obj => obj.CustCode == id);
                cus.CustCode = customer.CustCode;
                cus.CustName = customer.CustName;
                cus.CustCity = customer.CustCity;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerCRUD/Delete/5
        public ActionResult Delete(int id)
        {
            Customer cus = customers.FirstOrDefault(obj => obj.CustCode == id);
            return View(cus);
        }

        // POST: CustomerCRUD/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here

                Customer cus = customers.FirstOrDefault(obj => obj.CustCode == id);
                customers.Remove(cus);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
