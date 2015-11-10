using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Dal
{
    public class Movie
    {
        private Collection<Actor> actors; 

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Range(1900, 2020)]
        public int Year { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }

        public virtual Collection<Actor> Actors
        {
            get { return actors ?? (actors = new Collection<Actor>()); }
            set { actors = value; }
        }
    }
}