using Newtonsoft.Json;
using RestAssured.Request.Builders;
using System.Net;
using TeamcityTestingFramework.Api.Enums;
using TeamcityTestingFramework.Api.Models;
using TeamcityTestingFramework.Api.Requests.Unchecked;

namespace TeamcityTestingFramework.Api.Requests.Checked
{
    public sealed class CheckedBuildQueueRequest(RequestSpecification spec) : Request(spec, Endpoint.BUILD_QUEUE), IBuildQueueOperations<BuildQueue>
    {
        private readonly UncheckedBuildQueueRequest _uncheckedBuildQueueRequest = new(spec);

        public BuildQueue StartBuild(BaseModel model)
        {
            var body = _uncheckedBuildQueueRequest.StartBuild(model)
                .Then().AssertThat().StatusCode(HttpStatusCode.OK)
                .Extract().Body();
            return JsonConvert.DeserializeObject<BuildQueue>(body);
        }
    }
}
