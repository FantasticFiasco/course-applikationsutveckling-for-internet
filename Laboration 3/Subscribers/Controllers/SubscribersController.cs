using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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

        // PUT: api/Subscribers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubscriber(int id, Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subscriber.Id)
            {
                return BadRequest();
            }

            context.Entry(subscriber).State = EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscriberExists(id))
                {
                    return NotFound();
                }
                
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Subscribers
        [ResponseType(typeof(Subscriber))]
        public IHttpActionResult PostSubscriber(Subscriber subscriber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Subscribers.Add(subscriber);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subscriber.Id }, subscriber);
        }

        // DELETE: api/Subscribers/5
        [ResponseType(typeof(Subscriber))]
        public IHttpActionResult DeleteSubscriber(int id)
        {
            Subscriber subscriber = context.Subscribers.Find(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            context.Subscribers.Remove(subscriber);
            context.SaveChanges();

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

        private bool SubscriberExists(int id)
        {
            return context.Subscribers.Any(subscriber => subscriber.Id == id);
        }
    }
}