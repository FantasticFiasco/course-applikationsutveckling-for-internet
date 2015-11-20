using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PersonRegistry.Models;
using PersonRegistry.ViewModels;

namespace PersonRegistry.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonRepositoryContext context;

        public HomeController()
        {
            context = new PersonRepositoryContext();
        }

        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<IndexPersonViewModel> personViewModels = context.Persons.Select(CreateIndexPersonViewModel);
            
            return View(personViewModels);
        }

        private IndexPersonViewModel CreateIndexPersonViewModel(Person person)
        {
            Address address = context.Addresses.Find(person.AddressId);

            return new IndexPersonViewModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                Surname = person.Surname,
                Street = address.Street,
                City = address.City
            };
        }
    }
}