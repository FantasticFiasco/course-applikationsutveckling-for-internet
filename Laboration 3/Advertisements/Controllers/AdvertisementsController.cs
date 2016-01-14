using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            IEnumerable<AdvertisementViewModel> advertisements = context.Advertisements
                .Select(advertisement => new AdvertisementViewModel
                {
                    Id = advertisement.Id,
                    Title = advertisement.Title,
                    Content = advertisement.Content,
                    Price = advertisement.Price,
                    Reseller = advertisement.Reseller
                });
            
            return View(advertisements);
        }

        // GET: Advertisements/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Advertisements/Delete/5
        public ActionResult Delete(int id)
        {
            Advertisement advertisement = context.Advertisements.Find(id);
            if (advertisement == null)
                return HttpNotFound();

            context.Advertisements.Remove(advertisement);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Advertisements/Details/5
        public ActionResult Details(int id)
        {
            Advertisement advertisement = context.Advertisements.Find(id);
            if (advertisement == null)
                return HttpNotFound();

            return View(CreateAdvertisementViewModel(advertisement));
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
                return RedirectToAction("Index");
            }

            return View("Create", viewModel);
        }

        // POST: Advertisements/AddCompanyAdvertisement
        [HttpPost]
        public async Task<ActionResult> AddCompanyAdvertisement(CreateAdvertisementViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Company company = await context.Companies.SingleOrDefaultAsync(c => c.OrganisationNumber == viewModel.OrganisationNumber);
                if (company == null)
                {
                    company = CreateCompany(viewModel);
                    context.Companies.Add(company);
                }

                Advertisement advertisement = CreateAdvertisement(viewModel);
                company.Advertisements.Add(advertisement);

                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("Create", viewModel);
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

        private static Company CreateCompany(CreateAdvertisementViewModel viewModel)
        {
            return new Company
            {
                Name = viewModel.Name,
                OrganisationNumber = viewModel.OrganisationNumber,
                PhoneNumber = viewModel.PhoneNumber,
                Street = viewModel.Street,
                PostalCode = viewModel.PostalCode.Value,
                City = viewModel.City,
                InvoiceStreet = viewModel.InvoiceStreet,
                InvoicePostalCode = viewModel.InvoicePostalCode.Value,
                InvoiceCity = viewModel.InvoiceCity
            };
        }

        private static Advertisement CreateAdvertisement(CreateAdvertisementViewModel viewModel)
        {
            bool isSubscriber = viewModel.SubscriptionNumber != null;

            return new Advertisement
            {
                Title = viewModel.AdvertisementTitle,
                Content = viewModel.AdvertisementContent,
                Price = viewModel.AdvertisementPrice.Value,
                AdvertisementCost = isSubscriber ? 0 : 40,
                Reseller = isSubscriber ? string.Format("{0} {1}", viewModel.FirstName, viewModel.Surname) : string.Format("Company: {0}", viewModel.Name)
            };
        }

        private static AdvertisementViewModel CreateAdvertisementViewModel(Advertisement advertisement)
        {
            return new AdvertisementViewModel
            {
                Id = advertisement.Id,
                Title = advertisement.Title,
                Content = advertisement.Content,
                Price = advertisement.Price
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