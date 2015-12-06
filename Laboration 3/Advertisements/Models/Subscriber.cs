using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Advertisements.Models
{
    [Table("tbl_annonsorer")]
    public class Subscriber
    {
        private Collection<Advertisement> advertisements;

        [Column("an_id")]
        public int Id { get; set; }

        [Column("an_prenumerationsnummer")]
        [Required]
        public string SubscriptionNumber { get; set; }

        [Column("an_personnummer")]
        [Required]
        public string SocialSecurityNumber { get; set; }

        [Column("an_fornamn")]
        [Required]
        public string FirstName { get; set; }

        [Column("an_efternamn")]
        [Required]
        public string Surname { get; set; }

        [Column("an_telefonnummer")]
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

        [Column("an_gata")]
        [Required]
        public string Street { get; set; }

        [Column("an_postnummer")]
        public int PostalCode { get; set; }

        [Column("an_stad")]
        [Required]
        public string City { get; set; }

        #endregion
    }
}