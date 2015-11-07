using System.Collections.ObjectModel;

namespace MyMovies.Dal
{
    public class Movie
    {
        private Collection<Actor> actors; 

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public double Rating { get; set; }

        public virtual Collection<Actor> Actors
        {
            get { return actors ?? (actors = new Collection<Actor>()); }
            set { actors = value; }
        }
    }
}