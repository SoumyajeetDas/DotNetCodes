using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkyWeb.Repository.IRepository;
using ParkyWeb.Static_Details;
using ParkyWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyWeb.Controllers
{
    [AllowAnonymous]
    public class HomePageController : Controller
    {
        private readonly INationalParkRepository nRepo;
        private readonly ITrailRepository tRepo;
        public HomePageController(INationalParkRepository nRepo, ITrailRepository tRepo)
        {
            this.nRepo = nRepo;
            this.tRepo = tRepo;
        }
        public async Task<IActionResult> Index()
        {
            var obj1 = await nRepo.GetAllAsync(SD.NationalParkAPIPath + "getallnationalpark", HttpContext.Session.GetString("JWTToken"));
            var obj2 = await tRepo.GetAllAsync(SD.TrailAPIPath + "getallTrail", HttpContext.Session.GetString("JWTToken"));
            
            IndexViewModel ivm = new IndexViewModel()
            {
                NationalParks=obj1,
                Trails=obj2
            };

            return View(ivm);
        }
    }
}
