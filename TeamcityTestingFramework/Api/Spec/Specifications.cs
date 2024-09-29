using RestAssured.Request.Builders;
using RestAssured.Request.Logging;
using TeamcityTestingFramework.Api.Models;

namespace TeamcityTestingFramework.Api.Spec
{
    public class Specifications
    {
        private readonly string _jsonContentType = "application/json";
        private static Specifications _spec;

        private Specifications() { }

        public static Specifications GetSpec()
        {
            _spec ??= new Specifications();
            return _spec;
        }

        private RequestSpecBuilder RequestBuilder()
        {
            var requestBuilder = new RequestSpecBuilder();
            requestBuilder
                .WithRequestLogLevel(RequestLogLevel.All)
                .WithContentType(_jsonContentType)
                .WithHeader("Accept", _jsonContentType);
            return requestBuilder;
        }

        public RequestSpecification UnauthSpec()
        {            
            var requestBuilder = RequestBuilder();
            //requestBuilder
            //    .WithContentType(_jsonContentType)
            //    .WithHeader("Accept", _jsonContentType);
            return requestBuilder.Build();
        }

        public RequestSpecification AuthSpec(User user)
        {
            var requestBuilder = RequestBuilder();
            //requestBuilder
            //    .WithContentType(contentType: _jsonContentType)
            //    .WithHeader("Accept", _jsonContentType);
            var host = Config.Config.GetProperty("host");
            requestBuilder
                .WithBasicAuth(user.Username, user.Password)
                .WithBaseUri($"http://{Config.Config.GetProperty("host")}");
            return requestBuilder.Build();
        }
    }
}
