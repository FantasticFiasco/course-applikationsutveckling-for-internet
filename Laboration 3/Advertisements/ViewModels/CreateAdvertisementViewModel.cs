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

        [Display(Name = "Organisation Number")]
        public string OrganisationNumber { get; set; }

        [Display(Name = "Invoice Street")]
        public string InvoiceStreet { get; set; }

        [Display(Name = "Invoice Postal Code")]
        public int InvoicePostalCode { get; set; }

        [Display(Name = "Invoice City")]
        public string InvoiceCity { get; set; }

        #endregion

        #region Advertisment

        [Display(Name = "Advertisement Title")]
        public string AdvertisementTitle { get; set; }

        [Display(Name = "Advertisement Content")]
        [DataType(DataType.MultilineText)]
        public string AdvertisementContent { get; set; }

        [Display(Name = "Advertisement Price")]
        public double AdvertisementPrice { get; set; }

        #endregion
    }
}