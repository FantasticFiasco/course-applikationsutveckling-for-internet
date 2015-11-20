using System.Linq;
using System.Web.Mvc;
using PersonRegistry.ViewModels;

namespace PersonRegistry.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(Enumerable.Empty<IndexPersonViewModel>());
        }
    }
}