using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date"), Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Genres"), Required]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        [Required, Display(Name = "Number in Stock"), Range(1,20)]
        public int Stock { get; set; }
    }
}