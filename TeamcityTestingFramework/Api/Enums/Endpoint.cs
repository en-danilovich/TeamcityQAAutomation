using TeamcityTestingFramework.Api.Models;

namespace TeamcityTestingFramework.Api.Enums
{
    public class Endpoint
    {
        public static readonly Endpoint BUILD_TYPES = new ("/app/rest/buildTypes", typeof(BuildType));
        
        public string Url { get; }
        public Type ModelClass { get; }
        
        private Endpoint(string url, Type modelClass)
        {
            Url = url;
            ModelClass = modelClass;
        }
    }
}
