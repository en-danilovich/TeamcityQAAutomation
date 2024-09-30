using TeamcityTestingFramework.Api.Models;

namespace TeamcityTestingFramework.Api.Enums
{
    public class Endpoint
    {
        public static readonly Endpoint BUILD_TYPES = new ("/app/rest/buildTypes", typeof(BuildType));
        public static readonly Endpoint PROJECTS = new ("/app/rest/projects", typeof(Project));
        public static readonly Endpoint USERS = new ("/app/rest/users", typeof(User));
        
        public string Url { get; private set; }
        public Type ModelClass { get; private set; }
        
        private Endpoint(string url, Type modelClass)
        {
            Url = url;
            ModelClass = modelClass;
        }
    }
}
