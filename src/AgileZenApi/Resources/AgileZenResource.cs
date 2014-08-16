using RestSharp;

namespace AgileZenApi.Resources
{
    public abstract class AgileZenResource
    {
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
