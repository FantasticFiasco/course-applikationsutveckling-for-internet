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
    }
}