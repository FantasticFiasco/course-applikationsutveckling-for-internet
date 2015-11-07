using System.Data.Entity.ModelConfiguration;

namespace MyMovies.Dal.EntityConfigurations
{
    public class ActorConfiguration : EntityTypeConfiguration<Actor>
    {
        public ActorConfiguration()
        {
            Property(actor => actor.Name)
                .IsRequired();

            HasMany(actor => actor.Movies)
                .WithMany(movie => movie.Actors);
        }
    }
}