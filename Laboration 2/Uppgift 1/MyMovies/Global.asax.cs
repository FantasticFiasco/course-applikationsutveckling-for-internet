using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MyMovies.Dal;

namespace MyMovies
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ConfigureDatabase();
        }

        private static void ConfigureDatabase()
        {
            Database.SetInitializer(new MoviesContextInitializer());
        }
    }
}