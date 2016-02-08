using Blog;
using Blog.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace Blog
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