using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Dal
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Collection<Movie> Movies { get; set; }
    }
}