using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movies
        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole(Constants.CanManageMovies))
            {
                return View("Index");
            }

            return View("ReadOnlyIndex");
        }

        [Authorize(Roles = Constants.CanManageMovies)]
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm");
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieFromDb = _context.Movies.FirstOrDefault(m => m.Id == movie.Id);
                movieFromDb.Name = movie.Name;
                movieFromDb.ReleaseDate = (DateTime)movie.ReleaseDate;
                movieFromDb.DateAdded = DateTime.Now;
                movieFromDb.Stock = movie.Stock;
                movieFromDb.GenreId = movie.GenreId;
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            if (User.IsInRole(Constants.CanManageMovies))
            {
                return View("MovieForm", viewModel);
            }

            return View("Details", viewModel.Movie);
        }

    }
}