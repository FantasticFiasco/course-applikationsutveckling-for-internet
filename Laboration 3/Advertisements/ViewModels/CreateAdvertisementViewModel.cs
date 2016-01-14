using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Advertisements.ViewModels
{
    public class CreateAdvertisementViewModel : IValidatableObject
    {
        public string Street { get; set; }

        [Display(Name = "Postal Code")]
        public int? PostalCode { get; set; }

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

        [Display(Name = "Organization Number")]
        public string OrganizationNumber { get; set; }

        [Display(Name = "Invoice Street")]
        public string InvoiceStreet { get; set; }

        [Display(Name = "Invoice Postal Code")]
        public int? InvoicePostalCode { get; set; }

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
        public int? AdvertisementPrice { get; set; }

        #endregion

        #region IValidatableObject Members

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            IEnumerable<ValidationResult> validationResults = SubscriptionNumber != null ?
                ValidateSubscriberAdvertisement() :
                ValidateCompanyAdvertisement();

            return validationResults
                .Concat(ValidateAddress())
                .Concat(ValidateAdvertisment());
        }

        private IEnumerable<ValidationResult> ValidateAddress()
        {
            if (string.IsNullOrWhiteSpace(Street))
                yield return new ValidationResult("Enter a street", new[] { "Street" });

            if (PostalCode == null)
                yield return new ValidationResult("Enter a postal code", new[] { "PostalCode" });

            if (string.IsNullOrWhiteSpace(City))
                yield return new ValidationResult("Enter a city", new[] { "City" });
        }

        private IEnumerable<ValidationResult> ValidateAdvertisment()
        {
            if (string.IsNullOrWhiteSpace(AdvertisementTitle))
                yield return new ValidationResult("Enter a advertisement title", new[] { "AdvertisementTitle" });

            if (string.IsNullOrWhiteSpace(AdvertisementContent))
                yield return new ValidationResult("Enter a advertisement content", new[] { "AdvertisementContent" });

            if (AdvertisementPrice == null)
                yield return new ValidationResult("Enter a advertisement price", new[] { "AdvertisementPrice" });
        }

        private IEnumerable<ValidationResult> ValidateSubscriberAdvertisement()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                yield return new ValidationResult("Enter a first name", new[] { "FirstName" });

            if (string.IsNullOrWhiteSpace(Surname))
                yield return new ValidationResult("Enter a surname", new[] { "Surname" });

            if (string.IsNullOrWhiteSpace(PhoneNumber))
                yield return new ValidationResult("Enter a phone number", new[] { "PhoneNumber" });
        }

        private IEnumerable<ValidationResult> ValidateCompanyAdvertisement()
        {
            if (string.IsNullOrWhiteSpace(Name))
                yield return new ValidationResult("Enter a name", new[] { "Name" });

            if (string.IsNullOrWhiteSpace(OrganizationNumber))
                yield return new ValidationResult("Enter a organization number", new[] { "OrganizationNumber" });

            if (string.IsNullOrWhiteSpace(InvoiceStreet))
                yield return new ValidationResult("Enter a invoice street", new[] { "InvoiceStreet" });

            if (InvoicePostalCode == null)
                yield return new ValidationResult("Enter a invoice postal code", new[] { "InvoicePostalCode" });

            if (string.IsNullOrWhiteSpace(InvoiceCity))
                yield return new ValidationResult("Enter a invoice city", new[] { "InvoiceCity" });
        }

        #endregion
    }
}