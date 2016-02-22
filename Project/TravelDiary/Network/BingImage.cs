using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;

namespace TravelDiary.Network
{
    public sealed class BingImage : IDisposable
    {
        private static readonly string BaseUrl = "https://api.datamarket.azure.com/Bing/Search/v1/Image?Query=%27{0}%27&$format=json";
        private static readonly string Username = "PwFAolhgrvXKlu5D0F13w+uBTbspjFTUtWYPsWPEyAM=";
        private static readonly string Password = "PwFAolhgrvXKlu5D0F13w+uBTbspjFTUtWYPsWPEyAM=";

        private readonly HttpClient client;

        public BingImage()
        {
            client = CreateHttpClient();
        }

        public async Task<IEnumerable<string>> SearchFor(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException("text");

            string data = await SendRequestFor(text);
            return ParseData(data);
        }

        private Task<string> SendRequestFor(string text)
        {
            string requestUrl = string.Format(BaseUrl, HttpUtility.UrlEncode(text));
            return client.GetStringAsync(requestUrl);
        }

        private static IEnumerable<string> ParseData(string data)
        {
            dynamic document = JObject.Parse(data);

            List<string> photos = new List<string>();
            
            foreach (dynamic entry in document.d.results)
            {
                photos.Add(entry.Thumbnail.MediaUrl.Value);
            }

            return photos;
        }

        private static HttpClient CreateHttpClient()
        {
            var client = new HttpClient();

            // Configure basic authentication
            var authentication = Encoding.ASCII.GetBytes(Username + ":" + Password);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authentication));

            return client;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (client != null)
            {
                client.Dispose();    
            }
        }

        #endregion
    }
}