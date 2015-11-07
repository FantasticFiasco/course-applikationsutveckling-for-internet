using System.Collections.ObjectModel;

namespace MyMovies.Dal
{
    public class Movie
    {
        private Collection<Actor> cast; 

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public double Rating { get; set; }

        public virtual Collection<Actor> Cast
        {
            get { return cast ?? (cast = new Collection<Actor>()); }
            set { cast = value; }
        }
    }
}