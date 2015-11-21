using System.ComponentModel.DataAnnotations;

namespace PersonRegistry.ViewModels
{
    public class PersonViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Street { get; set; }

        public string City { get; set; }
    }
}