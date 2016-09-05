using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public int NumberInStock { get; set; }
        public int GenreId { get; set; }
        public GenreDto Genre { get; set; }
    }
}