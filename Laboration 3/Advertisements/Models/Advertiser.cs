using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Advertisements.Models
{
    [Table("tbl_annonsorer")]
    public class Advertiser
    {
        private Collection<Advertisement> advertisements;

        [Column("an_id")]
        public int Id { get; set; }

        [Column("an_namn")]
        [Required]
        public string Name { get; set; }

        [Column("an_telefonnummer")]
        // - May start with country code, i.e. '+'
        // - May contain numbers, hyphen and space
        [RegularExpression(@"^(\+)?[\d- ]+$")]
        public string PhoneNumber { get; set; }

        [Column("an_gata")]
        [Required]
        public string Street { get; set; }

        [Column("an_postnummer")]
        public int PostalCode { get; set; }

        [Column("an_stad")]
        [Required]
        public string City { get; set; }

        public virtual Collection<Advertisement> Advertisements
        {
            get { return advertisements ?? (advertisements = new Collection<Advertisement>()); }
            set { advertisements = value; }
        }

        #region Subscriber Members

        [Column("an_prenumerationsnummer")]
        public string SubscriptionNumber { get; set; }

        #endregion

        #region Company  Members

        [Column("an_organisationsnummer")]
        public string OrganisationNumber { get; set; }

        [Column("an_fakturagata")]
        public string InvoiceStreet { get; set; }

        [Column("an_fakturapostnummer")]
        public int InvoicePostalCode { get; set; }

        [Column("an_fakturastad")]
        public string InvoiceCity { get; set; }

        #endregion
    }
}