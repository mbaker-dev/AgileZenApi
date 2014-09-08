using System.Collections.Generic;
using AgileZenApi.Models;
using RestSharp;

namespace AgileZenApi.Resources
{
    /// <summary>
    /// Exposes methods related to the Agile Zen tags resource
    /// http://dev.agilezen.com/resources/tags.html
    /// </summary>
    public class TagsResource : AgileZenResource
    {
        public TagsResource(RestClient client)
            : base(client)
        {
        }

        protected override RestRequest CreateRequest(Method method, string uri = "")
        {
            var request = base.CreateRequest(method, "projects/{projectId}/tags/" + uri);
            request.AddUrlSegment("projectId", Project.Id.ToString());

            return request;
        }

        /// <summary>
        /// Adds an EXISTING tag to a story.
        /// </summary>
        /// <param name="tag">The tag to add to the story. The tag must already exist.</param>
        /// <param name="story">The story to add the tag to.</param>
        /// <returns>
        ///     Funny story: we return a single story, which happens to be the first story with the passed in tag.
        ///     Basically the Agile Zen API accepts a single tag/story but returns a list of stories with the tag.
        /// </returns>
        public ApiResponse<Story> AddToStory(Tag tag, Story story)
        {
            var request = CreateRequest(Method.POST, "{tag}/stories");
            request.AddUrlSegment("tag", tag.Name);
            request.AddBody(story);

            var response = _client.Execute<ApiResponse<Story>>(request);

            if (response.Data == null)
            {
                return new ApiResponse<Story> { StatusCode = response.StatusCode };
            }

            response.Data.StatusCode = response.StatusCode;
            return response.Data;
        }

        public ApiResponse<Tag> Create(Tag tag)
        {
            var request = CreateRequest(Method.POST);
            request.AddBody(tag);

            return CreateApiResponse(_client.Execute<Tag>(request));
        }

        public ApiResponse<Tag> Delete(Tag tag)
        {
            var request = CreateRequest(Method.DELETE, "{tag}");
            request.AddUrlSegment("tag", tag.Name);

            var response = _client.Execute(request);

            return new ApiResponse<Tag> { StatusCode = response.StatusCode };
        }

        public ApiResponse<Tag> Get(Tag tag)
        {
            var request = CreateRequest(Method.GET, "{tag}");
            request.AddUrlSegment("tag", tag.Name);

            return CreateApiResponse(_client.Execute<Tag>(request));
        }

        public PagedResponse<Tag> List(int page = 1, int pageSize = 100)
        {
            var request = CreateRequest(Method.GET);
            request.AddParameter("page", page);
            request.AddParameter("pageSize", pageSize);

            return CreatePagedResponse(_client.Execute<PagedResponse<Tag>>(request));
        }

        public PagedResponse<Story> ListStories(Tag tag, int page = 1, int pageSize = 100)
        {
            var request = CreateRequest(Method.GET, "{tag}/stories");
            request.AddUrlSegment("tag", tag.Name);
            request.AddParameter("page", page);
            request.AddParameter("pageSize", pageSize);

            return CreatePagedResponse(_client.Execute<PagedResponse<Story>>(request));
        }

        public ApiResponse<Tag> RemoveFromStory(Tag tag, Story story)
        {
            var request = CreateRequest(Method.DELETE, "{tag}/stories/{storyId}");
            request.AddUrlSegment("tag", tag.Name);
            request.AddUrlSegment("storyId", story.Id.ToString());

            var response = _client.Execute(request);

            return new ApiResponse<Tag> { StatusCode = response.StatusCode };
        }

        public ApiResponse<Story> SetStories(Tag tag, IList<Story> stories)
        {
            var request = CreateRequest(Method.PUT, "{tag}/stories");
            request.AddUrlSegment("tag", tag.Name);
            request.AddBody(stories);

            var response = _client.Execute<ApiResponse<Story>>(request);

            if (response.Data == null)
            {
                return new ApiResponse<Story> { StatusCode = response.StatusCode };
            }

            response.Data.StatusCode = response.StatusCode;
            return response.Data;
        }

        public ApiResponse<Tag> Update(Tag tag)
        {
            var request = CreateRequest(Method.PUT, "{tag}");
            request.AddUrlSegment("tag", tag.Id.ToString());
            request.AddBody(tag);

            return CreateApiResponse(_client.Execute<Tag>(request));
        }
    }
}