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
            IEnumerable<IndexPersonViewModel> personViewModels = context.Persons.Select(CreateIndexPersonViewModel);
            
            return View(personViewModels);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(CreatePersonViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    context.AddPersonWithAddress(
                        Guid.NewGuid(),
                        viewModel.FirstName,
                        viewModel.Surname,
                        Guid.NewGuid(),
                        viewModel.Street,
                        viewModel.City);

                    return Redirect("Index");
                }
                catch (EntityCommandExecutionException)
                {
                    ModelState.AddModelError(string.Empty, "Please enter values to all fields");
                }
            }

            return View(viewModel);
        }

        private IndexPersonViewModel CreateIndexPersonViewModel(Person person)
        {
            Address address = context.Addresses.Find(person.AddressId);

            return new IndexPersonViewModel
            {
                FirstName = person.FirstName,
                Surname = person.Surname,
                Street = address.Street,
                City = address.City
            };
        }
    }
}