namespace Advertisements.ViewModels
{
    public class CreateAdvertisementViewModel
    {
        public string Name { get; set; }

        public string Street { get; set; }

        public int PostalCode { get; set; }

        public string City { get; set; }

        #region Subscriber Members

        public string SubscriptionNumber { get; set; }

        public string SocialSecurityNumber { get; set; }

        #endregion

        #region Company  Members

        public string OrganisationNumber { get; set; }

        public string InvoiceStreet { get; set; }

        public int InvoicePostalCode { get; set; }

        public string InvoiceCity { get; set; }

        #endregion
    }
}