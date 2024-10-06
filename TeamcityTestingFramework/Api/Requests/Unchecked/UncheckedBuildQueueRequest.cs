using RestAssured.Request.Builders;
using RestAssured.Response;
using TeamcityTestingFramework.Api.Enums;
using TeamcityTestingFramework.Api.Models;
using static RestAssured.Dsl;

namespace TeamcityTestingFramework.Api.Requests.Unchecked
{
    public class UncheckedBuildQueueRequest(RequestSpecification spec) : Request(spec, Endpoint.BUILD_QUEUE), IBuildQueueOperations<VerifiableResponse>
    {
        public VerifiableResponse StartBuild(BaseModel model)
        {
            return Given()
                .Spec(Spec)
                .Body(model)
                .Post(Endpoint.Url);
        }
    }
}
