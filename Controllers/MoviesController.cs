using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using New_Vidly.Models;
using New_Vidly.ViewModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.MappingViews;

namespace New_Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies/Random

        public ViewResult Random()
        {
            //var movies = _context.Movies.Include(m => m.GenreTypes).ToList();
            //var viewModel = new RandomMovieViewModel()
            //{
            //    Movies = movies
            //};
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Random");
            return View("ReadOnlyList");
        }
        
        public ActionResult MovieDetails(int id) 
        {
            var movie = _context.Movies.Include(m => m.GenreTypes).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        //[Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        //public ContentResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult EditMovieDetails(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (id == 0)
            {
                var genretypes = _context.GenreTypes.ToList();
                var viewModel = new MovieFormViewModel
                {
                    genreTypes = genretypes,
                };
                return View(viewModel);
            }
            if (movie == null)
            {
                return HttpNotFound();
            }
            var genretype = _context.GenreTypes.ToList();
            var viewmodel = new MovieFormViewModel(movie)
            {
                genreTypes = genretype,
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    genreTypes = _context.GenreTypes.ToList()
                };
                return View("EditMovieDetails", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                if (movieInDb.Id == movie.Id)
                {
                    Console.Beep();
                }
                movieInDb.Name = movie.Name;
                movieInDb.GenreTypesId = movie.GenreTypesId;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Random", "Movies");
        }
    }
}