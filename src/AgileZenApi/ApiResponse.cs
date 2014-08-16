using System.Collections.Generic;
using System.Net;

namespace AgileZenApi
{
    public class ApiResponse<T> where T : class
    {
        /// <summary>
        /// A single item returned by the API
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        /// List of items returned by the API
        /// </summary>
        public List<T> Items { get; set; }

        /// <summary>
        /// The HttpStatusCode of the request
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }
    }
}
