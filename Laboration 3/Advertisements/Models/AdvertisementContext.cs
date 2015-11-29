using System.Data.Entity;

namespace Advertisements.Models
{
    public class AdvertisementContext : DbContext
    {
        public virtual IDbSet<Advertiser> Advertisers { get; set; } 

        public virtual IDbSet<Advertisement> Advertisements { get; set; }
    }
}