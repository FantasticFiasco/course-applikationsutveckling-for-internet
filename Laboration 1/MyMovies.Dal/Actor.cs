using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Dal
{
    public class Actor
    {
        private Collection<Movie> movies; 

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Collection<Movie> Movies
        {
            get { return movies ?? (movies = new Collection<Movie>()); }
            set { movies = value; }
        }
    }
}