using EnitityFrameworkWithASP.NETCore.Data;
using EnitityFrameworkWithASP.NETCore.Models;
using EnitityFrameworkWithASP.NETCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnitityFrameworkWithASP.NETCore.Controllers
{
    [Route("[controller]/[action]")]
    public class BookController : Controller
    { 
        
        private IBookRepository bookRepository = null;
        private readonly ILogger<BookController> logger;
        

        public BookController(IBookRepository bookRepository,ILogger<BookController> logger)
        {
            this.bookRepository = bookRepository;
            this.logger = logger;
        }

        [Route("~/")]
        [Route("~/addbook")] // Single ActionMethod can have more than 1 Route
        public IActionResult AddBook()
        {
            logger.LogInformation("Inserting into AddBook");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooks(BookModel model)
        {

            logger.LogInformation("Inserting into AddBook");
            if (ModelState.IsValid)
            {
                await bookRepository.AddNewBook(model);

                return RedirectToAction("GetAllBooks", "Book");
            }
            logger.LogInformation("Coming out of AddBook");
            return View("AddBook");
            
        }

        //[Route("getallbooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            logger.LogInformation("Inserting into GetAllBooks");
            var data = await bookRepository.GetAllBooks();
            return View(data);
        }


        [Route("~/getbookbyid/{id=4}")]
        public async Task<IActionResult> GetBook(int id)
        {
            logger.LogDebug("Entering into GetBook");
            var data = await bookRepository.GetBook(id);
            if (data == null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("EmployeeNotFound", "Error");
            }
            return View(data);
        }

        [Route("Edit/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            throw new Exception("");
            var data = await bookRepository.GetBook(id);
            if(data==null)
            {
                Response.StatusCode = 404;
                return RedirectToAction("EmployeeNotFound", "Error");
            }
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BookModel model)
        {
            if(ModelState.IsValid)
            {
                await bookRepository.Edit(model);
                return RedirectToAction("GetAllBooks", "Book");
            }
            else
            {
                return View();
            }
            
        }

        //[Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await bookRepository.GetBook(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]     
        public async Task<IActionResult> Delete(BookModel model)
        {         
            await bookRepository.Delete(model);
            return RedirectToAction("GetAllBooks", "Book");
        }
    }
}
