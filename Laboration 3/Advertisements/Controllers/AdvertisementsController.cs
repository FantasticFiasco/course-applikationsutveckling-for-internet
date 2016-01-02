using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertisements.Models;
using Advertisements.ViewModels;
using Advertisements.WebServices;
using Advertisements.WebServices.Requests;
using Subscribers.Dto;

namespace Advertisements.Controllers
{
    public class AdvertisementsController : AsyncController
    {
        private readonly AdvertisementContext context;
        private readonly SubscriberService subscriberService;

        public AdvertisementsController()
        {
            context = new AdvertisementContext();
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

        // POST: Advertisements/AddSubscriberAdvertisement
        [HttpPost]
        public async Task<ActionResult> AddSubscriberAdvertisement(CreateAdvertisementViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Subscriber subscriber = await context.Subscribers.SingleOrDefaultAsync(s => s.SubscriptionNumber == viewModel.SubscriptionNumber);
                if (subscriber == null)
                {
                    subscriber = CreateSubscriber(viewModel);
                    context.Subscribers.Add(subscriber);
                }

                Advertisement advertisement = CreateAdvertisement(viewModel);
                subscriber.Advertisements.Add(advertisement);

                await context.SaveChangesAsync();
            }

            return View("Create", viewModel);
        }

        // POST: Advertisements/AddCompanyAdvertisement
        [HttpPost]
        public async Task<ActionResult> AddCompanyAdvertisement(CreateAdvertisementViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        private static CreateAdvertisementViewModel FromDto(SubscriberDto subscriber)
        {
            return new CreateAdvertisementViewModel
            {
                SubscriptionNumber = subscriber.SubscriptionNumber,
                FirstName = subscriber.FirstName,
                Surname = subscriber.Surname,
                PhoneNumber = subscriber.PhoneNumber,
                Street = subscriber.Address.Street,
                PostalCode = subscriber.Address.PostalCode,
                City = subscriber.Address.City
            };
        }

        private static Subscriber CreateSubscriber(CreateAdvertisementViewModel viewModel)
        {
            return new Subscriber
            {
                SubscriptionNumber = viewModel.SubscriptionNumber,
                FirstName = viewModel.FirstName,
                Surname = viewModel.Surname,
                PhoneNumber = viewModel.PhoneNumber,
                Street = viewModel.Street,
                PostalCode = viewModel.PostalCode.Value,
                City = viewModel.City
            };
        }

        private static Advertisement CreateAdvertisement(CreateAdvertisementViewModel viewModel)
        {
            return new Advertisement
            {
                Title = viewModel.AdvertisementTitle,
                Content = viewModel.AdvertisementContent,
                Price = viewModel.AdvertisementPrice.Value,
                AdvertisementCost = viewModel.SubscriptionNumber != null ? 0 : 40
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