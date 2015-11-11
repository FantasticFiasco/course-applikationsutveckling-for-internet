using System.Data.Entity;

namespace MyMovies.Dal
{
    public class MoviesContext : DbContext
    {
        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Movie>()
                .HasRequired(movie => movie.Genre);

            modelBuilder
                .Entity<Genre>()
                .HasMany(genre => genre.Movies);
        }
    }
}