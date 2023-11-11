using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class MoviesController : Controller
    {
        private ApplicationDbContext context;
        public MoviesController()
        {
            context = new ApplicationDbContext();
        }
        //static List<Movie> movies = new List<Movie>()
        //{
        //    new Movie()
        //    {
        //        Id=1,
        //        Name="A Movie"
        //    },
        //    new Movie()
        //    {
        //        Id=2,
        //        Name="B Movie"
        //    },
        //    new Movie()
        //    {
        //        Id=3,
        //        Name="C Movie"
        //    },
        //};
        // GET: Movies
        public ActionResult Index()
        {
            var movies = context.Movies.ToList();
          
            return View(movies);
        }

        public ActionResult Create()
        {
            var genres = context.Genres.ToList();
            var viewModel = new NewMovieVewModel()
            {
                Genres = genres
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new NewMovieVewModel()
                {
                    Movie = movie,
                    Genres = context.Genres.ToList()
                };
                return View(viewModel);
            }
            context.Movies.Add(movie);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movies = context.Movies.SingleOrDefault(x => x.Id == id);
            var viewModel = new NewMovieVewModel()
            {
                Movie = movies,
                Genres = context.Genres.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieVewModel()
                {
                    Movie = movie,
                    Genres = context.Genres.ToList()
                };
                return View(viewModel);
            }
            context.Entry(movie).State = System.Data.Entity.EntityState.Modified;
            await context.SaveChangesAsync();
            return RedirectToAction("Index","Movies");
        }


        public ActionResult Details(int id)
        {
            var movie = context.Movies.Include(x=>x.Genre).SingleOrDefault(x=>x.Id==id);
            //var genre = context.Genres.SingleOrDefault(x => x.Id == movie.GenreId).GenreName;

            //var genre = context.Movies.G
            //ViewBag.Genre = genre;
            return View(movie);
        }
        
        public async Task<ActionResult> Delete(int id)
        {
            var movie = context.Movies.SingleOrDefault(x=>x.Id==id);
            context.Movies.Remove(movie);
            await context.SaveChangesAsync();
            return RedirectToAction("Index","Movies");
        }
    }
}