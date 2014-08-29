using AgileZenApi.Models;
using RestSharp;

namespace AgileZenApi.Resources
{
    public class StoriesResource : AgileZenResource
    {
        public StoriesResource(RestClient client)
            : base(client)
        {
        }

        protected override RestRequest CreateRequest(Method method, string uri = "")
        {
            var request = base.CreateRequest(method, "projects/{projectId}/stories/" + uri);
            request.AddUrlSegment("projectId", Project.Id.ToString());

            return request;
        }

        public ApiResponse<Story> Create(Story story)
        {
            var request = CreateRequest(Method.POST);
            request.AddBody(story);

            var response = _client.Execute<Story>(request);

            return new ApiResponse<Story> { Item = response.Data, StatusCode = response.StatusCode };
        }

        public ApiResponse<Story> Delete(Story story)
        {
            var request = CreateRequest(Method.DELETE, "{storyId}");
            request.AddUrlSegment("storyId", story.Id.ToString());

            var response = _client.Execute<Story>(request);

            return new ApiResponse<Story> { StatusCode = response.StatusCode };
        }

        public ApiResponse<Story> DeleteMultiple(string filter)
        {
            var request = CreateRequest(Method.DELETE, "?where={filter}");

            request.AddUrlSegment("filter", filter);

            var response = _client.Execute<PagedResponse<Story>>(request);

            return new ApiResponse<Story> { StatusCode = response.StatusCode };
        }

        public ApiResponse<Story> Get(Story story)
        {
            var request = CreateRequest(Method.GET, "{storyId}");
            request.AddUrlSegment("storyId", story.Id.ToString());

            var response = _client.Execute<Story>(request);

            return new ApiResponse<Story> { Item = response.Data, StatusCode = response.StatusCode };
        }

        public PagedResponse<Story> List(string projectId, int page = 1, int pageSize = 100, string filter = null)
        {
            var request = CreateRequest(Method.GET);
            request.AddParameter("page", page);
            request.AddParameter("pageSize", pageSize);

            if (filter != null)
            {
                request.AddParameter("where", filter);
            }

            var response = _client.Execute<PagedResponse<Story>>(request);

            if (response.Data == null)
            {
                return new PagedResponse<Story> { StatusCode = response.StatusCode };
            }

            response.Data.StatusCode = response.StatusCode;
            return response.Data;
        }

        public ApiResponse<Story> Update(Story story)
        {
            var request = CreateRequest(Method.PUT, "{storyId}");
            request.AddUrlSegment("storyId", story.Id.ToString());
            request.AddBody(story);

            var response = _client.Execute<Story>(request);

            return new ApiResponse<Story> { Item = response.Data, StatusCode = response.StatusCode };
        }

        public PagedResponse<Story> UpdateMultiple(Story story, string filter)
        {
            var request = CreateRequest(Method.PUT, "?where={filter}");

            request.AddUrlSegment("filter", filter);
            request.AddBody(story);

            var response = _client.Execute<PagedResponse<Story>>(request);

            if (response.Data == null)
            {
                return new PagedResponse<Story> { StatusCode = response.StatusCode };
            }

            response.Data.StatusCode = response.StatusCode;
            return response.Data;
        }
    }
}
