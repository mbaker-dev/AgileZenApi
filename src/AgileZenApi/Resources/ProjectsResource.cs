using System.Threading.Tasks;
using AgileZenApi.Models;
using RestSharp;

namespace AgileZenApi.Resources
{
    public class ProjectsResource
    {
        private readonly RestClient _client;

        public ProjectsResource(RestClient client)
        {
            _client = client;
        }

        public ApiResponse<Project> List()
        {
            var request = new RestRequest("Projects", Method.GET);

            return _client.Execute<ApiResponse<Project>>(request).Data;
        }

        public async Task<ApiResponse<Project>> ListAsync()
        {
            var request = new RestRequest("Projects", Method.GET);
            var response = await _client.ExecuteTaskAsync<ApiResponse<Project>>(request);

            return response.Data;
        }
    }
}
