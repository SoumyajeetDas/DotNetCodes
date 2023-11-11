using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstMVCWebApplication1.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }
        //public string GetAllBooks()
        //{
        //    return "All Books";
        //}

        //public string GetCertainBook(int? id)
        //{
        //    return " Book with id " + id;
        //}

        //public string CertainBook(int id, string bookname)
        //{
        //    return $"Book name with {bookname} and id {id}";
        //}
    }
}
