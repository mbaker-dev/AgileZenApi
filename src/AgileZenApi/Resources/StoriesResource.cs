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

        private RestRequest CreateRequestForTags(Method method, Story story)
        {
            const string uriSegment = "{storyId}/tags";
            var request = CreateRequest(method, uriSegment);

            request.AddUrlSegment("storyId", story.Id.ToString());

            return request;
        }

        public ApiResponse<Story> Create(Story story)
        {
            var request = CreateRequest(Method.POST);
            request.AddBody(story);

            return CreateApiResponse(_client.Execute<Story>(request));
        }

        public ApiResponse<Story> Delete(Story story)
        {
            var request = CreateRequest(Method.DELETE, "{storyId}");
            request.AddUrlSegment("storyId", story.Id.ToString());

            return CreateApiResponse(_client.Execute<Story>(request));
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

            return CreateApiResponse(_client.Execute<Story>(request));
        }

        public PagedResponse<Tag> GetTags(Story story)
        {
            var request = CreateRequestForTags(Method.GET, story);
            return CreatePagedResponse(_client.Execute<PagedResponse<Tag>>(request));
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

            return CreatePagedResponse(_client.Execute<PagedResponse<Story>>(request));
        }

        public ApiResponse<Story> Update(Story story)
        {
            var request = CreateRequest(Method.PUT, "{storyId}");
            request.AddUrlSegment("storyId", story.Id.ToString());
            request.AddBody(story);

            return CreateApiResponse(_client.Execute<Story>(request));
        }

        public PagedResponse<Story> UpdateMultiple(Story story, string filter)
        {
            var request = CreateRequest(Method.PUT, "?where={filter}");

            request.AddUrlSegment("filter", filter);
            request.AddBody(story);

            return CreatePagedResponse(_client.Execute<PagedResponse<Story>>(request));
        }
    }
}