using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Linq;
using System.Data.Entity;


namespace Vidly.Controllers
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

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanChangeMovies))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movie.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Authorize (Roles = RoleName.CanChangeMovies)]
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if(movie.Id == 0)
            {
                _context.Movie.Add(movie);
            }
            else
            {
                var currentMovie = _context.Movie.Single(m => m.Id == movie.Id);

                currentMovie.Name = movie.Name;
                currentMovie.ReleaseDate = movie.ReleaseDate;
                currentMovie.NumberInStock = currentMovie.NumberInStock;
                currentMovie.Genre = movie.Genre;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var currentMovie = _context.Movie.SingleOrDefault(m => m.Id == id);

            var viewModel = new MovieFormViewModel(currentMovie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var movie = _context.Movie.Single(m => m.Id == id);

            _context.Movie.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}