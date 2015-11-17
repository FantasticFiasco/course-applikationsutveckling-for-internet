using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyMovies.Models;

namespace MyMovies.ViewModels
{
    public static class GenreSelectListFactory
    {
        public static SelectList Create()
        {
            IEnumerable<SelectListItem> empty = new[]
            {
                new SelectListItem()
            };

            var context = new MoviesContext();

            IEnumerable<SelectListItem> genre = context.Genre.Select(
                g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name
                });

            return new SelectList(empty.Concat(genre), "Value", "Text");
        }
    }
}