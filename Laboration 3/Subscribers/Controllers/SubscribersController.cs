using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Subscribers.Dto;
using Subscribers.Models;

namespace Subscribers.Controllers
{
    public class SubscribersController : ApiController
    {
        private readonly SubscriberContext context;

        public SubscribersController()
        {
            context = new SubscriberContext();
        }

        // GET: api/Subscribers
        public IQueryable<SubscriberDto> GetSubscribers()
        {
            return context.Subscribers.Select(ToDto).AsQueryable();
        }

        // GET: api/Subscribers/5
        [ResponseType(typeof(SubscriberDto))]
        public IHttpActionResult GetSubscriber(string subscriptionNumber)
        {
            Subscriber subscriber = context.Subscribers.SingleOrDefault(s => s.SubscriptionNumber == subscriptionNumber);
            if (subscriber == null)
            {
                return NotFound();
            }

            return Ok(ToDto(subscriber));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        private static SubscriberDto ToDto(Subscriber subscriber)
        {
            return new SubscriberDto
            {
                SubscriptionNumber = subscriber.SubscriptionNumber,
                SocialSecurityNumber = subscriber.SocialSecurityNumber,
                FirstName = subscriber.FirstName,
                Surname = subscriber.Surname,
                PhoneNumber = subscriber.PhoneNumber,
                Address = new AddressDto
                {
                    Street = subscriber.Street,
                    PostalCode = subscriber.PostalCode,
                    City = subscriber.City
                }
            };
        }
    }
}