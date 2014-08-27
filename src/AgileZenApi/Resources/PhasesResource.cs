
using AgileZenApi.Models;
using RestSharp;

namespace AgileZenApi.Resources
{
    public class PhasesResource : AgileZenResource
    {
        public PhasesResource(RestClient client)
            : base(client)
        {

        }

        protected override RestRequest CreateRequest(Method method, string uri = "")
        {
            var request = base.CreateRequest(method, "projects/{projectId}/phases/" + uri);
            request.AddUrlSegment("projectId", Project.Id.ToString());

            return request;
        }

        public PagedResponse<Phase> List(int page = 1, int pageSize = 100)
        {
            var request = CreateRequest(Method.GET);
            request.AddParameter("page", page);
            request.AddParameter("pageSize", pageSize);

            var response = _client.Execute<PagedResponse<Phase>>(request);

            if (response.Data == null)
            {
                return new PagedResponse<Phase> { StatusCode = response.StatusCode };
            }

            response.Data.StatusCode = response.StatusCode;
            return response.Data;
        }
    }
}
