using System.Data.Entity;

namespace MyMovies.Dal
{
    public class MoviesContext : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Actor> Actors { get; set; }
    }
}