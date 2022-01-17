using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date"), Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Genres"), Required]
        public int GenreId { get; set; }

        [Required, Display(Name = "Number in Stock"), Range(1, 20)]
        public int Stock { get; set; }
    }
}