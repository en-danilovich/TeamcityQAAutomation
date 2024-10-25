using TeamcityTestingFramework.src.Api.Models;

namespace TeamcityTestingFramework.src.Api.Enums
{
    public class Endpoint
    {
        public static readonly Endpoint BUILD_TYPES = new("/app/rest/buildTypes", typeof(BuildType));
        public static readonly Endpoint BUILD_QUEUE = new("/app/rest/buildQueue", typeof(BuildQueue));
        public static readonly Endpoint BUILDS = new("/app/rest/builds", typeof(Build));
        public static readonly Endpoint PROJECTS = new("/app/rest/projects", typeof(Project));
        public static readonly Endpoint USERS = new("/app/rest/users", typeof(User));
        public static readonly Endpoint AUTH_SETTINGS = new("/app/rest/server/authSettings", typeof(AuthSettings));

        public static readonly List<Endpoint> EndpointsList =
        [
            BUILD_TYPES,
            BUILD_QUEUE,
            PROJECTS,
            USERS,
            AUTH_SETTINGS,
            BUILDS
        ];

        public string Url { get; private set; }
        public Type ModelClass { get; private set; }

        private Endpoint(string url, Type modelClass)
        {
            Url = url;
            ModelClass = modelClass;
        }
    }
}
