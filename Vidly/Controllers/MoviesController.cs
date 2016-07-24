using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        
        // GET: Movies/Random
        
        public ActionResult Random()
        {

            var movie = new Movie() { Name = "Interstellar" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }



        public ActionResult Display()
        {
            var movie = new List<Movie>
            {
                new Movie() { Id = 1, Name = "Interstellar" },
                new Movie() { Id = 2, Name = "The Last Samurai" }
            };

            var viewMovies = new DisplayMoviesViewModel()
            {
                Movies = movie
            };

            return View(viewMovies);
        }

        [Route("movies/details/{id}")]
        public ActionResult Details(int id, string name)
        {

            var movie = new Movie
            {
                Id = id,
                Name = name
            };

            return View(movie);
        }

    }
}