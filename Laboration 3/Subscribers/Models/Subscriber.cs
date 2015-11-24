using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Subscribers.Models
{
    [Table("tbl_prenumeranter")]
    public class Subscriber
    {
        [Column("prenumerant_id")]
        public int Id { get; set; }

        [Column("prenumerant_prenumerationsnummer")]
        [Required]
        public string SubscriptionNumber { get; set; }

        [Column("prenumerant_personnummer")]
        [Required]
        public string SocialSecurityNumber { get; set; }

        [Column("prenumerant_fornamn")]
        [Required]
        public string FirstName { get; set; }

        [Column("prenumerant_efternamn")]
        [Required]
        public string Surname { get; set; }

        [Column("prenumerant_gata")]
        [Required]
        public string Street { get; set; }

        [Column("prenumerant_postnummer")]
        public int PostalCode { get; set; }

        [Column("prenumerant_stad")]
        [Required]
        public string City { get; set; }
    }
}