using System;
using System.Web.Mvc;
using Advertisements.ViewModels;

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

        // POST: Advertisements/GetSubscriber
        [HttpPost]
        public ActionResult GetSubscriber(CreateAdvertisementViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}