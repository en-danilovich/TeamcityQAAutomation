using Newtonsoft.Json;
using RestAssured.Request.Builders;
using System.Net;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Models;
using TeamcityTestingFramework.src.Api.Requests;
using TeamcityTestingFramework.src.Api.Requests.Unchecked;

namespace TeamcityTestingFramework.src.Api.Requests.Checked
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
