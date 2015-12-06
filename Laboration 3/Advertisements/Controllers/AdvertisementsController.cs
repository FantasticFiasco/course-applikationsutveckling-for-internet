using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertisements.ViewModels;
using Advertisements.WebServices;
using Advertisements.WebServices.Requests;
using Subscribers.Dto;

namespace Advertisements.Controllers
{
    public class AdvertisementsController : AsyncController
    {
        private readonly SubscriberService subscriberService;

        public AdvertisementsController()
        {
            subscriberService = new SubscriberService();
        }

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
        public async Task<ActionResult> GetSubscriber(CreateAdvertisementViewModel viewModel)
        {
            if (string.IsNullOrWhiteSpace(viewModel.SubscriptionNumber))
            {
                ModelState.AddModelError("SubscriptionNumber", "Enter a subscription number");
                return View("Create", viewModel);
            }

            try
            {
                SubscriberDto subscriber = await subscriberService.GetSubscriber(viewModel.SubscriptionNumber);
                return View("Create", FromDto(subscriber));
            }
            catch (RequestException e)
            {
                ModelState.AddModelError(string.Empty, GetModelErrorMessage(e));
                return View("Create", viewModel);
            }
        }

        private static CreateAdvertisementViewModel FromDto(SubscriberDto subscriber)
        {
            return new CreateAdvertisementViewModel
            {
                SubscriptionNumber = subscriber.SubscriptionNumber,
                SocialSecurityNumber = subscriber.SocialSecurityNumber,
                Name = string.Format("{0} {1}", subscriber.FirstName, subscriber.Surname),
                Street = subscriber.Address.Street,
                PostalCode = subscriber.Address.PostalCode,
                City = subscriber.Address.City
            };
        }

        private static string GetModelErrorMessage(RequestException exception)
        {
            switch (exception.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return "The specified subscription number does not exist";

                default:
                    return "Unknown error when communicating with subscription service";
            }
        }
    }
}