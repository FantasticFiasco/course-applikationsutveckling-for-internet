using System.Collections.ObjectModel;

namespace MyMovies.Dal
{
    public class Actor
    {
        private Collection<Movie> movies; 

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Collection<Movie> Movies
        {
            get { return movies ?? (movies = new Collection<Movie>()); }
            set { movies = value; }
        }
    }
}