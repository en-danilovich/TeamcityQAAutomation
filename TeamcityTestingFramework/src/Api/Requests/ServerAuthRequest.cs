using Newtonsoft.Json;
using RestAssured.Request.Builders;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Models;
using static RestAssured.Dsl;

namespace TeamcityTestingFramework.src.Api.Requests
{
    public class ServerAuthRequest : Request
    {
        public ServerAuthRequest(RequestSpecification specification) : base(specification, Endpoint.SERVER_AUTH_SETTINGS)
        {

        }

        public ServerAuthSettings Read()
        {
            var body = Given()
                .Spec(Spec)
                .Get(Endpoint.Url)
                .Then().AssertThat().StatusCode(System.Net.HttpStatusCode.OK)
                .Extract().Body();

            return JsonConvert.DeserializeObject<ServerAuthSettings>(body);
        }

        public ServerAuthSettings Update(ServerAuthSettings authSettings)
        {
            var body = Given()
                .Spec(Spec)
                .Body(authSettings)
                .Put(Endpoint.Url)
                .Then().AssertThat().StatusCode(System.Net.HttpStatusCode.OK)
                .Extract().Body();

            return JsonConvert.DeserializeObject<ServerAuthSettings>(body);
        }
    }
}
