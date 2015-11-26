namespace Subscribers.Dto
{
    public class SubscriberDto
    {
        public string SubscriptionNumber { get; set; }

        public string SocialSecurityNumber { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public AddressDto Address { get; set; }
    }
}