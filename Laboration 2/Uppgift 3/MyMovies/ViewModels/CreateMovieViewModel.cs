using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyMovies.ViewModels
{
    public class CreateMovieViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "Genre")]
        public int SelectedGenreId { get; set; }

        public SelectList Genre { get; set; }

        [Range(1900, 2020)]
        public int Year { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }

        [Required]
        public string Cast { get; set; }
    }
}