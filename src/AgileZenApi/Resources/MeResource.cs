using System.Linq;
using System.Threading.Tasks;
using AgileZenApi.Models;
using RestSharp;

namespace AgileZenApi.Resources
{
    public class MeResource : AgileZenResource
    {
        public MeResource(RestClient client) : base(client) { }

        protected override RestRequest CreateRequest(Method method, string uri = "")
        {
            var request = base.CreateRequest(method, "me" + uri);
            return request;
        }

        public ApiResponse<User> Get()
        {
            var request = CreateRequest(Method.GET);
            return CreateApiResponse(_client.Execute<User>(request));
        }

        public async Task<ApiResponse<User>> GetAsync()
        {
            var request = CreateRequest(Method.GET);
            var response = await _client.ExecuteTaskAsync<User>(request);

            return CreateApiResponse(response);
        }

        public PagedResponse<Story> GetStories(int page = 1, int pageSize = 100, bool active = false)
        {
            var request = CreateRequest(Method.GET, "/stories");
            request.AddParameter("page", page);
            request.AddParameter("pageSize", pageSize);

            var response = CreatePagedResponse(_client.Execute<PagedResponse<Story>>(request));

            if (active)
            {
                response.Items = response.Items.Where(StoryIsActive).ToList();
            }

            return response;
        }

        public PagedResponse<Story> GetStories(bool active)
        {
            return GetStories(1, 100, active);
        }

        public async Task<PagedResponse<Story>> GetStoriesAsync(int page = 1, int pageSize = 100, bool active = false)
        {
            var request = CreateRequest(Method.GET, "/stories");
            request.AddParameter("page", page);
            request.AddParameter("pageSize", pageSize);

            var response = CreatePagedResponse(await _client.ExecuteTaskAsync<PagedResponse<Story>>(request));

            if (active)
            {
                response.Items = response.Items.Where(StoryIsActive).ToList();
            }

            return response;
        }

        public async Task<PagedResponse<Story>> GetStoriesAsync(bool active)
        {
            return await GetStoriesAsync(1, 100, active);
        }

        private bool StoryIsActive(Story story)
        {
            return story.Phase.Name != "Archive" && story.Phase.Name != "Backlog";
        }
    }
}