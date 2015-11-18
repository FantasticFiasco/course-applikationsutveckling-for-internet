using System.Collections.Generic;
using System.Web.Mvc;

namespace MyMovies.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<IndexMovieViewModel> Movies { get; set; }

        public SelectList Genre { get; set; }
    }
}