using System.Data.Entity;

namespace Advertisements.Models
{
    public class AdvertisementContext : DbContext
    {
        public virtual IDbSet<Subscriber> Subscribers { get; set; }

        public virtual IDbSet<Company> Companies { get; set; }

        public virtual IDbSet<Advertisement> Advertisements { get; set; }
    }
}