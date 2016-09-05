using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;


namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
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

        //Get a Single Movie
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movie.Include(m => m.Genre).Single(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //Get a List of Movies
        public IHttpActionResult GetMovies()
        {
            var movies = _context.Movie
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movies);
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movie.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var CurrentMovie = _context.Movie.Single(m => m.Id == id);

            if (CurrentMovie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, CurrentMovie);
            _context.SaveChanges();

        }

        [HttpDelete]
        public void Delete(int id)
        {
            var movie = _context.Movie.SingleOrDefault(m => m.Id == id);

            if(movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movie.Remove(movie);
            _context.SaveChanges();
        }

    }
}
