using System;
using System.Net;

namespace Advertisements.WebServices.Requests
{
    public class RequestException : Exception
    {
        private readonly HttpStatusCode statusCode;

        public RequestException(HttpStatusCode statusCode)
        {
            this.statusCode = statusCode;
        }

        public HttpStatusCode StatusCode
        {
            get { return statusCode; }
        }
    }
}