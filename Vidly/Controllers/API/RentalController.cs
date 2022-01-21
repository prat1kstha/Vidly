using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class RentalController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        // POST: Rental
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);
            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}