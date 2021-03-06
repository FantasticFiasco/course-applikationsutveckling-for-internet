﻿using System.ComponentModel.DataAnnotations;

namespace MyMovies.Dal
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        [Range(1900, 2020)]
        public int Year { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }

        [Required]
        public string Cast { get; set; }
    }
}