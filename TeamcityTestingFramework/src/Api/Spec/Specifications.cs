﻿using RestAssured.Request.Builders;
using RestAssured.Request.Logging;
using TeamcityTestingFramework.src.Api.Models;

namespace TeamcityTestingFramework.src.Api.Spec
{
    public static class Specifications
    {
        private static readonly string _jsonContentType = "application/json";

        private static RequestSpecBuilder RequestBuilder()
        {
            var requestBuilder = new RequestSpecBuilder();
            requestBuilder
                .WithRequestLogLevel(RequestLogLevel.All)
                .WithContentType(_jsonContentType)
                .WithHeader("Accept", _jsonContentType);
            return requestBuilder;
        }

        public static RequestSpecification UnauthSpec()
        {
            var requestBuilder = RequestBuilder();
            return requestBuilder.Build();
        }

        public static RequestSpecification AuthSpec(User user)
        {
            var requestBuilder = RequestBuilder();
            requestBuilder
                .WithBasicAuth(user.username, user.password)
                .WithBaseUri($"http://{Config.Config.GetProperty<string>("host")}");
            return requestBuilder.Build();
        }

        public static RequestSpecification SuperUserAuthSpec()
        {
            var requestBuilder = RequestBuilder();
            requestBuilder
                .WithBasicAuth("", Config.Config.GetProperty<string>("superUserToken"))
                .WithBaseUri($"http://{Config.Config.GetProperty<string>("host")}");
            return requestBuilder.Build();
        }
    }
}
