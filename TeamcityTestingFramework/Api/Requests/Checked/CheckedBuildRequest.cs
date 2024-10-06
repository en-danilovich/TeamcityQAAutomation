using Newtonsoft.Json;
using RestAssured.Request.Builders;
using System.Net;
using TeamcityTestingFramework.Api.Enums;
using TeamcityTestingFramework.Api.Models;
using TeamcityTestingFramework.Api.Requests.Unchecked;

namespace TeamcityTestingFramework.Api.Requests.Checked
{
    public class CheckedBuildRequest(RequestSpecification spec) : Request(spec, Endpoint.BUILDS), IGetEntityDetailsByLocator<Build>
    {
        private readonly UncheckedBuildRequest _uncheckedBuildRequest = new(spec);

        public Build GetDetails(string locator = "")
        {
            var body = _uncheckedBuildRequest.GetDetails(locator)
                .Then().AssertThat().StatusCode(HttpStatusCode.OK)
                .Extract().Body();
            return JsonConvert.DeserializeObject<Build>(body);
        }
    }
}
