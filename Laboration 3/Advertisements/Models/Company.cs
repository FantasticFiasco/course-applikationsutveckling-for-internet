using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Advertisements.Models
{
    [Table("tbl_foretag")]
    public class Company
    {
        private Collection<Advertisement> advertisements;

        [Column("fo_id")]
        public int Id { get; set; }

        [Column("fo_namn")]
        [Required]
        public string Name { get; set; }

        [Column("fo_organisationsnummer")]
        public string OrganisationNumber { get; set; }

        [Column("fo_telefonnummer")]
        // - May start with country code, i.e. '+'
        // - May contain numbers, hyphen and space
        [RegularExpression(@"^(\+)?[\d- ]+$")]
        public string PhoneNumber { get; set; }

        public virtual Collection<Advertisement> Advertisements
        {
            get { return advertisements ?? (advertisements = new Collection<Advertisement>()); }
            set { advertisements = value; }
        }

        #region Address 

        [Column("fo_gata")]
        [Required]
        public string Street { get; set; }

        [Column("fo_postnummer")]
        public int PostalCode { get; set; }

        [Column("fo_stad")]
        [Required]
        public string City { get; set; }

        #endregion

        #region Invoice

        [Column("fo_fakturagata")]
        [Required]
        public string InvoiceStreet { get; set; }

        [Column("fo_fakturapostnummer")]
        public int InvoicePostalCode { get; set; }

        [Column("fo_fakturastad")]
        [Required]
        public string InvoiceCity { get; set; }

        #endregion
    }
}