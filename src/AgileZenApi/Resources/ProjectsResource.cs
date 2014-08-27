using System.Threading.Tasks;
using AgileZenApi.Models;
using RestSharp;

namespace AgileZenApi.Resources
{
    public class ProjectsResource : AgileZenResource
    {
        public ProjectsResource(RestClient client)
            : base(client)
        {
        }

        protected override RestRequest CreateRequest(Method method, string uri = "")
        {
            var request = base.CreateRequest(method, "projects/" + uri);

            return request;
        }

        public PagedResponse<Project> List(int page = 1, int pageSize = 100)
        {
            var request = CreateRequest(Method.GET);
            request.AddParameter("page", page);
            request.AddParameter("pageSize", pageSize);

            var response = _client.Execute<PagedResponse<Project>>(request);

            if (response.Data == null)
            {
                return new PagedResponse<Project> { StatusCode = response.StatusCode };
            }

            response.Data.StatusCode = response.StatusCode;
            return response.Data;
        }

        public async Task<PagedResponse<Project>> ListAsync(int page = 1, int pageSize = 100)
        {
            var request = CreateRequest(Method.GET);
            request.AddParameter("page", page);
            request.AddParameter("pageSize", pageSize);

            var response = await _client.ExecuteTaskAsync<PagedResponse<Project>>(request);

            if (response.Data == null)
            {
                return new PagedResponse<Project> { StatusCode = response.StatusCode };
            }

            response.Data.StatusCode = response.StatusCode;
            return response.Data;
        }
    }
}
