using TravelDiary;
using TravelDiary.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace TravelDiary
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure the db context
            app.CreatePerOwinContext(() => new ApplicationDbContext());
        }
    }
}