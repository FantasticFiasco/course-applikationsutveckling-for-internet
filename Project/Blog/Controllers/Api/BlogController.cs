using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Blog.Models;

namespace Blog.Controllers.Api
{
    public class BlogController : ApiController
    {
        private readonly ApplicationDbContext context;

        public BlogController()
        {
            context = new ApplicationDbContext();
        }

        // GET api/blog
        public IQueryable<BlogEntry> Get()
        {
            return context.BlogEntries;
        }

        // GET api/blog/5
        public IHttpActionResult Get(int id)
        {
            BlogEntry blogEntry = context.BlogEntries.Find(id);
            if (blogEntry == null)
            {
                return NotFound();
            }

            return Ok(blogEntry);
        }

        // POST api/blog
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/blog/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/blog/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            BlogEntry blogEntry = context.BlogEntries.Find(id);
            if (blogEntry == null)
            {
                return NotFound();
            }

            context.BlogEntries.Remove(blogEntry);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}