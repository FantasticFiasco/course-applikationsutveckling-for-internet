using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web.Mvc;
using PersonRegistry.Models;
using PersonRegistry.ViewModels;

namespace PersonRegistry.Controllers
{
    public class SqlTransactionController : Controller
    {
        private readonly PersonRegistryContext context;

        public SqlTransactionController()
        {
            context = new PersonRegistryContext();
        }

        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<PersonViewModel> personViewModels = context.Persons.Select(CreatePersonViewModel);
            
            return View(personViewModels);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.AddPersonWithAddress(
                        Guid.NewGuid(),
                        personViewModel.FirstName,
                        personViewModel.Surname,
                        Guid.NewGuid(),
                        personViewModel.Street,
                        personViewModel.City);

                    return Redirect("Index");
                }
                catch (EntityCommandExecutionException)
                {
                    ModelState.AddModelError(string.Empty, "Please enter values to all fields");
                }
            }

            return View(personViewModel);
        }

        private PersonViewModel CreatePersonViewModel(Person person)
        {
            Address address = context.Addresses.Find(person.AddressId);

            return new PersonViewModel
            {
                FirstName = person.FirstName,
                Surname = person.Surname,
                Street = address.Street,
                City = address.City
            };
        }
    }
}