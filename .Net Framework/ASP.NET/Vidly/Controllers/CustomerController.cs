using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext context;
        public static List<Customer> cus = new List<Customer>()
        {
            //new Customer()
            //{
            //    Id=1,
            //    Name="Sounak"
            //},
            //new Customer()
            //{
            //    Id=2,
            //    Name="Soumyajeet"
            //}
        };

        public CustomerController()
        {
            context = new ApplicationDbContext(); 
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = context.Customers.ToList();
            return View(customers);
        }

        public ActionResult CreateCustomer()
        {
            var membershiptype = context.MembershipTypes.ToList();
            var newCustomerViewModel = new NewCustomerViewModel()
            {
                MembershipTypes = membershiptype
            };
            return View(newCustomerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCustomer(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewmodel = new NewCustomerViewModel()
                {
                    Customer = customer,
                    MembershipTypes = context.MembershipTypes.ToList()

                };
                return View(viewmodel);
            }
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
;           return RedirectToAction("Index","Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer  = context.Customers.SingleOrDefault(x => x.Id == id);
            var viewmodel = new NewCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = context.MembershipTypes.ToList()
                
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewmodel = new NewCustomerViewModel()
                {
                    Customer = customer,
                    MembershipTypes = context.MembershipTypes.ToList()

                };
                return View(viewmodel);
            }
            context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult Details(int id)
        {
            var customer = context.Customers.Find(id);
            return View(customer);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var customer = context.Customers.Single(x => x.Id == id);
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Customer");
        }
    }
}