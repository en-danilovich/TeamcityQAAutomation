using RestAssured.Request.Builders;
using RestAssured.Response;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Models;
using TeamcityTestingFramework.src.Api.Requests;
using static RestAssured.Dsl;

namespace TeamcityTestingFramework.src.Api.Requests.Unchecked
{
    public class UncheckedBase(RequestSpecification spec, Endpoint endpoint) : Request(spec, endpoint), ICrudOperations<VerifiableResponse, VerifiableResponse>
    {
        public VerifiableResponse Create(BaseModel model)
        {
            return Given()
                .Spec(Spec)
                .Body(model)
                .Post(Endpoint.Url);
        }

        public VerifiableResponse Delete(string id)
        {
            return Given()
                .Spec(Spec)
                .Delete($"{Endpoint.Url}/id:{id}");
        }

        public VerifiableResponse Read(string id)
        {
            return Given()
                .Spec(Spec)
                .Get($"{Endpoint.Url}/id:{id}");
        }

        public VerifiableResponse Update(string id, BaseModel model)
        {
            return Given()
                .Spec(Spec)
                .Body(model)
                .Put($"{Endpoint.Url}/id:{id}");
        }
    }
}
