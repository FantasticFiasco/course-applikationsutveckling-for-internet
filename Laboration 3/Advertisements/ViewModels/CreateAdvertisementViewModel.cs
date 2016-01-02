using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertisements.ViewModels
{
    public class CreateAdvertisementViewModel : IValidatableObject
    {
        [Required]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public int? PostalCode { get; set; }

        [Required]
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
        public int? InvoicePostalCode { get; set; }

        [Display(Name = "Invoice City")]
        public string InvoiceCity { get; set; }

        #endregion

        #region Advertisment

        [Required]
        [Display(Name = "Advertisement Title")]
        public string AdvertisementTitle { get; set; }

        [Required]
        [Display(Name = "Advertisement Content")]
        [DataType(DataType.MultilineText)]
        public string AdvertisementContent { get; set; }

        [Required]
        [Display(Name = "Advertisement Price")]
        public int? AdvertisementPrice { get; set; }

        #endregion

        #region IValidatableObject Members

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return SubscriptionNumber != null ?
                ValidateSubscriberAdvertisement() :
                ValidateCompanyAdvertisement();
        }

        private IEnumerable<ValidationResult> ValidateSubscriberAdvertisement()
        {
            if (string.IsNullOrWhiteSpace(FirstName))
                yield return new ValidationResult("The First Name field is required.", new[] { "FirstName" });

            if (string.IsNullOrWhiteSpace(Surname))
                yield return new ValidationResult("The Surname field is required.", new[] { "Surname" });

            if (string.IsNullOrWhiteSpace(PhoneNumber))
                yield return new ValidationResult("The Phone Number field is required.", new[] { "PhoneNumber" });
        }

        private IEnumerable<ValidationResult> ValidateCompanyAdvertisement()
        {
            if (string.IsNullOrWhiteSpace(Name))
                yield return new ValidationResult("The Name field is required.", new[] { "Name" });

            if (string.IsNullOrWhiteSpace(OrganisationNumber))
                yield return new ValidationResult("The Organisation Number field is required.", new[] { "OrganisationNumber" });

            if (string.IsNullOrWhiteSpace(InvoiceStreet))
                yield return new ValidationResult("The Invoice Street field is required.", new[] { "InvoiceStreet" });

            if (InvoicePostalCode == null)
                yield return new ValidationResult("The Invoice Postal Code field is required.", new[] { "InvoicePostalCode" });

            if (string.IsNullOrWhiteSpace(InvoiceCity))
                yield return new ValidationResult("The Invoice City field is required.", new[] { "InvoiceCity" });
        }

        #endregion
    }
}