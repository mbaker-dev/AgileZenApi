using AgileZenApi.Models;
using RestSharp;

namespace AgileZenApi.Resources
{
    public abstract class AgileZenResource
    {
        protected readonly RestClient _client;

        public Project Project { get; set; }

        protected AgileZenResource(RestClient client)
        {
            _client = client;
        }

        protected virtual RestRequest CreateRequest(Method method, string uri = "")
        {
            var request = new RestRequest(uri, method)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new JsonSerializer()
            };

            return request;
        }
    }
}
