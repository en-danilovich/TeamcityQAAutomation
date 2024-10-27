using RestAssured.Request.Builders;
using RestAssured.Response;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Models;
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

        public VerifiableResponse Delete(string locator)
        {
            return Given()
                .Spec(Spec)
                .Delete($"{Endpoint.Url}/{locator}");
        }

        public VerifiableResponse Read(string locator)
        {
            return Given()
                .Spec(Spec)
                .Get($"{Endpoint.Url}/{locator}");
        }

        public VerifiableResponse Update(string locator, BaseModel model)
        {
            return Given()
                .Spec(Spec)
                .Body(model)
                .Put($"{Endpoint.Url}/{locator}");
        }
    }
}
