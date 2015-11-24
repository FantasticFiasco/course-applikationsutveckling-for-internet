using System.Data.Entity;

namespace Subscribers.Models
{
    public class SubscriberContext : DbContext
    {
        public virtual IDbSet<Subscriber> Subscribers { get; set; } 
    }
}