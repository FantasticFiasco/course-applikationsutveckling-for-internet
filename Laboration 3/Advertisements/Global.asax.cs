using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using Advertisements.Models;

namespace Advertisements
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new AdvertisementContextInitializer());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
