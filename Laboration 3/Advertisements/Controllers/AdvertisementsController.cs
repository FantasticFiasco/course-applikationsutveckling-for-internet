using System.Web.Mvc;

namespace Advertisements.Controllers
{
    public class AdvertisementsController : Controller
    {
        // GET: Advertisements
        public ActionResult Index()
        {
            return View();
        }

        // GET: Advertisements/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}