using RestAssured.Request.Builders;
using RestAssured.Response;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Models;
using TeamcityTestingFramework.src.Api.Requests;
using static RestAssured.Dsl;

namespace TeamcityTestingFramework.src.Api.Requests.Unchecked
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
