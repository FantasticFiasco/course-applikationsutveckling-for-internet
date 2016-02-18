using System.Data.Entity;

namespace TravelDiary.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public virtual IDbSet<DiaryEntry> DiaryEntries { get; set; }

        public virtual IDbSet<Destination> Destinations { get; set; }
    }
}