using AgileZenApi.Models;
using AgileZenApi.Resources;
using RestSharp;

namespace AgileZenApi
{
    public class AgileZenClient
    {
        public PhasesResource Phases { get; private set; }

        public Project Project
        {
            set
            {
                Phases.Project = value;
                Stories.Project = value;
                Tags.Project = value;
            }
        }

        public ProjectsResource Projects { get; private set; }

        public StoriesResource Stories { get; private set; }

        public TagsResource Tags { get; private set; }

        public AgileZenClient(string apiKey, string apiUrl = "https://agilezen.com/api/v1/")
        {
            var client = new RestClient(apiUrl);

            client.AddDefaultHeader("X-Zen-ApiKey", apiKey);
            client.AddDefaultHeader("Content-Type", "application/json");
            client.AddDefaultHeader("Accept", "application/json");

            Phases = new PhasesResource(client);
            Projects = new ProjectsResource(client);
            Stories = new StoriesResource(client);
            Tags = new TagsResource(client);
        }
    }
}
