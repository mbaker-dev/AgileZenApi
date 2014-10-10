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

        protected ApiResponse<T> CreateApiResponse<T>(IRestResponse<T> response) where T : class
        {
            if (response.Data == null)
            {
                return new ApiResponse<T> { StatusCode = response.StatusCode };
            }

            return new ApiResponse<T> { Item = response.Data, StatusCode = response.StatusCode };
        }

        protected PagedResponse<T> CreatePagedResponse<T>(IRestResponse<PagedResponse<T>> response) where T : class
        {
            if (response.Data == null)
            {
                return new PagedResponse<T> { StatusCode = response.StatusCode };
            }

            response.Data.StatusCode = response.StatusCode;

            return response.Data;
        }
    }
}
