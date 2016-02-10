using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using TravelDiary.Models;

namespace TravelDiary.Controllers.Api
{
    public class DiaryEntriesController : ApiController
    {
        private readonly ApplicationDbContext context;

        public DiaryEntriesController()
        {
            context = new ApplicationDbContext();
        }

        // GET api/diaryentries
        public IQueryable<DiaryEntry> Get()
        {
            return context.DiaryEntries;
        }

        // GET api/diaryentries/5
        public IHttpActionResult Get(int id)
        {
            DiaryEntry diaryEntry = context.DiaryEntries.Find(id);
            if (diaryEntry == null)
            {
                return NotFound();
            }

            return Ok(diaryEntry);
        }

        // POST api/diaryentries
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/diaryentries/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/diaryentries/5
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