using System.Data.Entity.ModelConfiguration;

namespace MyMovies.Dal.EntityConfigurations
{
    public class ActorConfiguration : EntityTypeConfiguration<Actor>
    {
        public ActorConfiguration()
        {
            HasOptional(actor => actor.Movies);
        }
    }
}