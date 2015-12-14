using System.ComponentModel.DataAnnotations;

namespace Advertisements.ViewModels
{
    public class CreateAdvertisementViewModel
    {
        public string Street { get; set; }

        [Display(Name = "Postal Code")]
        public int PostalCode { get; set; }

        public string City { get; set; }

        #region Subscriber Members

        public string SubscriptionNumber { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public string Surname { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        #endregion

        #region Company  Members

        public string Name { get; set; }

        public string OrganisationNumber { get; set; }

        public string InvoiceStreet { get; set; }

        public int InvoicePostalCode { get; set; }

        public string InvoiceCity { get; set; }

        #endregion
    }
}