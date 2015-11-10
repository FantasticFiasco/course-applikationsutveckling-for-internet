using System.Data.Entity.ModelConfiguration;

namespace MyMovies.Dal.EntityConfigurations
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            HasMany(movie => movie.Actors)
                .WithMany(actor => actor.Movies);
        }
    }
}