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

        public ApiResponse<Project> Get(Project project)
        {
            var request = CreateRequest(Method.GET, "{projectID}");
            request.AddUrlSegment("projectID", project.Id.ToString());

            var response = _client.Execute<Project>(request);

            return CreateApiResponse(response);
        }

        public async Task<ApiResponse<Project>> GetAsync(Project project)
        {
            var request = CreateRequest(Method.GET, "{projectID}");
            request.AddUrlSegment("projectID", project.Id.ToString());

            var response = await _client.ExecuteTaskAsync<Project>(request);

            return CreateApiResponse(response);
        }

        public PagedResponse<User> GetMembers(Project project, int page = 1, int pageSize = 100)
        {
            var request = CreateRequest(Method.GET, "{projectID}/members");
            request.AddUrlSegment("projectID", project.Id.ToString());
            request.AddParameter("page", page);
            request.AddParameter("pageSize", pageSize);

            var response = _client.Execute<PagedResponse<User>>(request);

            return CreatePagedResponse(response);
        }

        public async Task<PagedResponse<User>> GetMembersAsync(Project project, int page = 1, int pageSize = 100)
        {
            var request = CreateRequest(Method.GET, "{projectID}/members");
            request.AddUrlSegment("projectID", project.Id.ToString());
            request.AddParameter("page", page);
            request.AddParameter("pageSize", pageSize);

            var response = await _client.ExecuteTaskAsync<PagedResponse<User>>(request);

            return CreatePagedResponse(response);
        }

        public PagedResponse<Project> List(int page = 1, int pageSize = 100)
        {
            var request = CreateRequest(Method.GET);
            request.AddParameter("page", page);
            request.AddParameter("pageSize", pageSize);

            var response = _client.Execute<PagedResponse<Project>>(request);

            return CreatePagedResponse(response);
        }

        public async Task<PagedResponse<Project>> ListAsync(int page = 1, int pageSize = 100)
        {
            var request = CreateRequest(Method.GET);
            request.AddParameter("page", page);
            request.AddParameter("pageSize", pageSize);

            var response = await _client.ExecuteTaskAsync<PagedResponse<Project>>(request);

            return CreatePagedResponse(response);
        }
    }
}