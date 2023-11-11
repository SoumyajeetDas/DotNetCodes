using Library_App.Models;
using Library_App.Models.DTO;
using Library_App.Repository;
using Library_App.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Library_App.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryRepository librepo;
        public LibraryController(ILibraryRepository librepo)
        {
            this.librepo = librepo;
        }
        public async Task<IActionResult> Index()
        {
            var res = await librepo.Books();
            return View(res);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LibraryDTO libraryDTO)
        {
            if(!ModelState.IsValid)
            {
                return View(libraryDTO);
            }

            byte[] p1 = null;
            //var files = HttpContext.Request.Form.Files;
            var files = libraryDTO.Picture.Files;

            if (files.Count > 0)
            {
                using (var fs1 = files[0].OpenReadStream())
                {
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                }
            }

            Library lib = new Library()
            {
                BookName = libraryDTO.BookName,
                AuthorName = libraryDTO.AuthorName,
                Details = libraryDTO.Details,
                Picture = p1,
                cost = libraryDTO.cost
            };

            var res = await librepo.Create(lib);
            
            if(res==false)
            {
                ViewBag.Error = "Books cannot be added";
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowDetails(int id)
        {
            var res = await librepo.Details(id);

            if(res==null)
            {
                ViewBag.Error = "Nothing to Show";
            }
            return View(res);
        }
    }
}
