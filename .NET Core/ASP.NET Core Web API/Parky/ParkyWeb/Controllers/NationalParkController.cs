using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyWeb.Models;
using ParkyWeb.Models.DTO;
using ParkyWeb.Repository.IRepository;
using ParkyWeb.Static_Details;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWeb.Controllers
{
   
    public class NationalParkController : Controller
    {
        private readonly INationalParkRepository nrepo;

        public NationalParkController(INationalParkRepository nrepo)
        {
            this.nrepo = nrepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var obj = await nrepo.GetAllAsync(SD.NationalParkAPIPath + "getallnationalpark", HttpContext.Session.GetString("JWTToken"));
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var obj = await nrepo.GetAsync(SD.NationalParkAPIPath+ "getnationalparkbyid/", id, HttpContext.Session.GetString("JWTToken"));
            if(obj.Picture.Length==0)
            {
                obj.Picture = null;
            }
            return View(obj);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(NationalParkDTO nationalParkdto)
        {
            if(!ModelState.IsValid)
            {
                return View(nationalParkdto);
            }

            byte[] p1 = null;
            //var files = HttpContext.Request.Form.Files;
            var files = nationalParkdto.Picture.Files;
           
            if (files.Count>0)
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

            NationalPark np = new NationalPark()
            {
                Id = nationalParkdto.Id,
                Name = nationalParkdto.Name,
                State = nationalParkdto.State,
                Created = nationalParkdto.Created,
                Established = nationalParkdto.Established,
                Picture = p1

            };
            var obj = await nrepo.CreateAsync(SD.NationalParkAPIPath+ "createnationalPark", np, HttpContext.Session.GetString("JWTToken"));

            if (obj)
                return  RedirectToAction("Index");

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var obj = await nrepo.GetAsync(SD.NationalParkAPIPath + "getnationalparkbyid/", id, HttpContext.Session.GetString("JWTToken"));
            NationalParkDTO npdto = new NationalParkDTO()
            {
                Id = obj.Id,
                Name = obj.Name,
                State = obj.State,
                Created = obj.Created,
                Established = obj.Established,

            };
            return View(npdto);
            
        }
        [HttpPost]
        public async Task<IActionResult> Edit(NationalParkDTO nationalParkdto)
        {
            if(!ModelState.IsValid)
            {
                return View(nationalParkdto);
            }

            byte[] p1 = null;
            //var files = HttpContext.Request.Form.Files;
            var files = nationalParkdto.Picture.Files;
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
            NationalPark np = new NationalPark()
            {
                Id = nationalParkdto.Id,
                Name = nationalParkdto.Name,
                State = nationalParkdto.State,
                Created = nationalParkdto.Created,
                Established = nationalParkdto.Established,
                Picture = p1

            };

            var obj = await nrepo.UpdateAsync(SD.NationalParkAPIPath+ "updatenationalpark/"+np.Id, np, HttpContext.Session.GetString("JWTToken"));
            if (obj == true)
                return RedirectToAction("Index");
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = await nrepo.DeleteAsync(SD.NationalParkAPIPath+ "deletenationalpark/", id, HttpContext.Session.GetString("JWTToken"));

            
            return RedirectToAction("Index");
        }

        
    }
}
