using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using PersonRegistry.Models;
using PersonRegistry.ViewModels;

namespace PersonRegistry.Controllers
{
    public class EntityFrameworkTransactionController : Controller
    {
        private readonly PersonRegistryContext personRegistryContext;
        private readonly PetRegistryContext petRegistryContext;

        public EntityFrameworkTransactionController()
        {
            personRegistryContext = new PersonRegistryContext();
            petRegistryContext = new PetRegistryContext();
        }

        // GET: EntityFrameworkTransaction
        public ActionResult Index()
        {
            IEnumerable<PetViewModel> petViewModels = petRegistryContext.Pets.Select(CreatePetViewModel);

            return View(petViewModels);
        }

        // GET: EntityFrameworkTransaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntityFrameworkTransaction/Create
        [HttpPost]
        public ActionResult Create(PetViewModel petViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var scope = new TransactionScope())
                    {
                        Address address = CreateAddress(petViewModel);
                        personRegistryContext.Addresses.Add(address);
                        personRegistryContext.SaveChanges();

                        Pet pet = CreatePet(petViewModel, address.Id);
                        petRegistryContext.Pets.Add(pet);
                        petRegistryContext.SaveChanges();

                        scope.Complete();
                    }

                    return Redirect("Index");
                }
                catch (DbEntityValidationException)
                {
                    ModelState.AddModelError(string.Empty, "Please enter values to all fields");
                }
            }

            return View(petViewModel);
        }

        private PetViewModel CreatePetViewModel(Pet pet)
        {
            Address address = personRegistryContext.Addresses.Find(pet.AddressId);

            return new PetViewModel
            {
                Name = pet.Name,
                Street = address.Street,
                City = address.City
            };
        }

        private static Address CreateAddress(PetViewModel petViewModel)
        {
            return new Address
            {
                Id = Guid.NewGuid(),
                Street = petViewModel.Street,
                City = petViewModel.City
            };
        }

        private static Pet CreatePet(PetViewModel petViewModel, Guid addressId)
        {
            return new Pet
            {
                Id = Guid.NewGuid(),
                Name = petViewModel.Name,
                AddressId = addressId
            };
        }
    }
}