using System;
using System.Threading.Tasks;
using Advertisements.WebServices.Requests;
using Subscribers.Dto;

namespace Advertisements.WebServices
{
    public class SubscriberService
    {
        private readonly string baseAddress = "http://localhost:6768/";

        public async Task<SubscriberDto> GetSubscriber(string subscriptionNumber)
        {
            if (string.IsNullOrEmpty(subscriptionNumber))
                throw new ArgumentNullException("subscriptionNumber");

            using (var request = new Request(baseAddress))
            {
                return await request.GetAsync<SubscriberDto>("api/Subscribers/" + subscriptionNumber);
            }
        }
    }
}