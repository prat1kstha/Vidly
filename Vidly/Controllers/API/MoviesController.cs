using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        //GET /api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST /api/create
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT /api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieFromDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            Mapper.Map<MovieDto, Movie>(movie, movieFromDb);

            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movieFromDb.Id), movieFromDb);

        }

        

        //DELETE /api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieFromDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieFromDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(movieFromDb);
            _context.SaveChanges();
        }
    }
}
