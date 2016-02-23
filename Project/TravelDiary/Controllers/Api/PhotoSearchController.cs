using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using TravelDiary.Models;
using TravelDiary.Network;

namespace TravelDiary.Controllers.Api
{
    public class PhotoSearchController : ApiController
    {
        private readonly BingImage bingImage;

        public PhotoSearchController()
        {
            bingImage = new BingImage();
        }

        [Route("api/photosearch/{text}")]
        public async Task<IHttpActionResult> Get(string text)
        {
            IEnumerable<Image> images = await bingImage.SearchFor(text);
            return Ok(images);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && bingImage != null)
            {
                bingImage.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}