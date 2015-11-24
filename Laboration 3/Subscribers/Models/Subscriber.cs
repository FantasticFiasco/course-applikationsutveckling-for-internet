using System.ComponentModel.DataAnnotations;

namespace Subscribers.Models
{
    public class Subscriber
    {
        public int Id { get; set; }

        [Required]
        public string SubscriptionNumber { get; set; }

        [Required]
        public string SocialSecurityNumber { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Street { get; set; }

        public int PostalCode { get; set; }

        [Required]
        public string City { get; set; }
    }
}