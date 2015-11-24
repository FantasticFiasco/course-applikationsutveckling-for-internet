using System.Data.Entity;
using System.Web;
using System.Web.Http;
using Subscribers.Models;

namespace Subscribers
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new SubscriberContextInitializer());

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}