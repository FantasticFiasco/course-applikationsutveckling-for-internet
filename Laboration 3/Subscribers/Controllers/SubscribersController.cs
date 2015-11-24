using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
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
        public IQueryable<Subscriber> GetSubscribers()
        {
            return context.Subscribers;
        }

        // GET: api/Subscribers/5
        [ResponseType(typeof(Subscriber))]
        public IHttpActionResult GetSubscriber(int id)
        {
            Subscriber subscriber = context.Subscribers.Find(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return Ok(subscriber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}