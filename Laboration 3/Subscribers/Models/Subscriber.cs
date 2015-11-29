using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Subscribers.Models
{
    [Table("tbl_prenumeranter")]
    public class Subscriber
    {
        [Column("pr_id")]
        public int Id { get; set; }

        [Column("pr_prenumerationsnummer")]
        [Required]
        public string SubscriptionNumber { get; set; }

        [Column("pr_personnummer")]
        [Required]
        public string SocialSecurityNumber { get; set; }

        [Column("pr_fornamn")]
        [Required]
        public string FirstName { get; set; }

        [Column("pr_efternamn")]
        [Required]
        public string Surname { get; set; }

        [Column("pr_telefonnummer")]
        [Required]
        public string PhoneNumber { get; set; }

        [Column("pr_gata")]
        [Required]
        public string Street { get; set; }

        [Column("pr_postnummer")]
        public int PostalCode { get; set; }

        [Column("pr_stad")]
        [Required]
        public string City { get; set; }
    }
}