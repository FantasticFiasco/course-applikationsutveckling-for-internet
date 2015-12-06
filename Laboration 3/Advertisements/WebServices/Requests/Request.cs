using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Advertisements.WebServices.Requests
{
    public class Request : IDisposable
    {
        private readonly HttpClient client;

        public Request(string baseAddress)
        {
            if (string.IsNullOrEmpty(baseAddress))
                throw new ArgumentNullException("baseAddress");

            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync<T>(string requestUri)
        {
            HttpResponseMessage response = await client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }

            throw new RequestException(response.StatusCode);
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}