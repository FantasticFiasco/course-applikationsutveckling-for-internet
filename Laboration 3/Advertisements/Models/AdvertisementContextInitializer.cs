using System.Data.Entity;

namespace Advertisements.Models
{
    public class AdvertisementContextInitializer : DropCreateDatabaseIfModelChanges<AdvertisementContext>
    {
    }
}