using System.Threading.Tasks;
using AgileZenApi.Models;
using RestSharp;

namespace AgileZenApi.Resources
{
    public class StoriesResource
    {
        private readonly RestClient _client;

        public StoriesResource(RestClient client)
        {
            _client = client;
        }

        public Story Create(Story story)
        {
            var request = new RestRequest("Projects/{projectId}/Stories", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddUrlSegment("projectId", story.Project.Id.ToString());
            request.AddBody(story);

            return _client.Execute<Story>(request).Data;
        }

        public async Task<Story> CreateAsync(Story story)
        {
            var request = new RestRequest("Projects/{projectId}/Stories", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddUrlSegment("projectId", story.Project.Id.ToString());
            request.AddBody(story);

            var response = await _client.ExecuteTaskAsync<Story>(request);

            return response.Data;
        }

        public ApiResponse<Story> List(string projectId, int page = 1, int pageSize = 100, string filter = null)
        {
            var request = new RestRequest("Projects/{projectId}/Stories", Method.GET);
            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("page", page);
            request.AddParameter("pageSize", pageSize);

            if (filter != null)
            {
                request.AddParameter("where", filter);
            }

            return _client.Execute<ApiResponse<Story>>(request).Data;
        }

        public async Task<ApiResponse<Story>> ListAsync(string projectId, int page = 1, int pageSize = 100, string filter = null)
        {
            var request = new RestRequest("Projects/{projectId}/Stories", Method.GET);
            request.AddUrlSegment("projectId", projectId);
            request.AddParameter("page", page);
            request.AddParameter("pageSize", pageSize);

            if (filter != null)
            {
                request.AddParameter("where", filter);
            }

            var response = await _client.ExecuteTaskAsync<ApiResponse<Story>>(request);

            return response.Data;
        }
    }
}
