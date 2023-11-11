using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyWeb.Models;
using ParkyWeb.Repository.IRepository;
using ParkyWeb.Static_Details;
using ParkyWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWeb.Controllers
{

    public class TrailController : Controller
    {
        private readonly ITrailRepository tRepo;
        private readonly INationalParkRepository nrepo;

        public TrailController(ITrailRepository tRepo, INationalParkRepository nrepo)
        {
            this.tRepo = tRepo;
            this.nrepo = nrepo;
        }
        public async Task<IActionResult> Index()
        {
            var obj = await tRepo.GetAllAsync(SD.TrailAPIPath + "getallTrail", HttpContext.Session.GetString("JWTToken"));
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var obj = await tRepo.GetAsync(SD.TrailAPIPath + "getTrailbyid/", id, HttpContext.Session.GetString("JWTToken"));
            return View(obj);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            List<NationalPark> filternationalParks = new List<NationalPark>();
            int flag;
            var trails = await tRepo.GetAllAsync(SD.TrailAPIPath + "getallTrail", HttpContext.Session.GetString("JWTToken"));
            var nationalParks = await nrepo.GetAllAsync(SD.NationalParkAPIPath + "getallnationalpark", HttpContext.Session.GetString("JWTToken"));
            foreach (var z in nationalParks)
            {
                flag = 0;
                foreach(var x in trails)
                {
                    if(x.NationalParkId==z.Id)
                    {
                        flag = 1;
                        break;
                    }
                    
                }
                if(flag==0)
                {
                    filternationalParks.Add(z);
                }
            }

            TrailViewModel tvm = new TrailViewModel()
            {
                NationalParks = filternationalParks
            };
           
            return View(tvm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Trail trail)
        {
            var obj = await tRepo.CreateAsync(SD.TrailAPIPath + "createTrail", trail, HttpContext.Session.GetString("JWTToken"));

            if (obj)
                return RedirectToAction("Index");

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var obj = await tRepo.GetAsync(SD.TrailAPIPath + "getTrailbyid/", id, HttpContext.Session.GetString("JWTToken"));

            List<NationalPark> filternationalParks = new List<NationalPark>();
            int flag;
            var trails = await tRepo.GetAllAsync(SD.TrailAPIPath + "getallTrail", HttpContext.Session.GetString("JWTToken"));
            var nationalParks = await nrepo.GetAllAsync(SD.NationalParkAPIPath + "getallnationalpark", HttpContext.Session.GetString("JWTToken"));
            foreach (var z in nationalParks)
            {
                flag = 0;
                foreach (var x in trails)
                {
                    if (x.NationalParkId == z.Id)
                    {
                        flag = 1;
                        break;
                    }

                }
                if (flag == 0)
                {
                    filternationalParks.Add(z);
                }
            }

            TrailViewModel tvm = new TrailViewModel()
            {
                Trail = obj,
                NationalParks = filternationalParks
            };

            return View(tvm);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Trail Trail)
        {
            if(Trail.NationalParkId==0)
            {
                var obj1 = await tRepo.GetAsync(SD.TrailAPIPath + "getTrailbyid/", Trail.Id, HttpContext.Session.GetString("JWTToken"));
                Trail.NationalParkId = obj1.NationalParkId;
            }
            var obj = await tRepo.UpdateAsync(SD.TrailAPIPath + "updateTrail/" + Trail.Id, Trail, HttpContext.Session.GetString("JWTToken"));
            if (obj == true)
                return RedirectToAction("Index");
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = await tRepo.DeleteAsync(SD.TrailAPIPath + "deleteTrail/", id, HttpContext.Session.GetString("JWTToken"));


            return RedirectToAction("Index");
        }
    }
}
