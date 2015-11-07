using System.Data.Entity;
using MyMovies.Dal.EntityConfigurations;

namespace MyMovies.Dal
{
    public class MoviesContext : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MovieConfiguration());
            modelBuilder.Configurations.Add(new ActorConfiguration());
        }
    }
}