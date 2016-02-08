using System.Data.Entity;

namespace Blog.Models
{
    public class ApplicationDbContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
    }
}