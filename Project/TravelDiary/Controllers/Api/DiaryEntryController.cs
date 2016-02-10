using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TravelDiary.Models;

namespace TravelDiary.Controllers.Api
{
    public class DiaryEntryController : ApiController
    {
        private readonly ApplicationDbContext context;

        public DiaryEntryController()
        {
            context = new ApplicationDbContext();
        }

        // GET api/diaryentry
        public DiaryEntry Get()
        {
            return context.DiaryEntries.OrderByDescending(entry => entry.Date).First();
        }

        // GET api/diaryentry/5
        public IHttpActionResult Get(int id)
        {
            DiaryEntry diaryEntry = context.DiaryEntries.Find(id);
            if (diaryEntry == null)
            {
                return NotFound();
            }

            return Ok(diaryEntry);
        }

        // POST api/diaryentry
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/diaryentry/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/diaryentry/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            DiaryEntry diaryEntry = context.DiaryEntries.Find(id);
            if (diaryEntry == null)
            {
                return NotFound();
            }

            context.DiaryEntries.Remove(diaryEntry);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}