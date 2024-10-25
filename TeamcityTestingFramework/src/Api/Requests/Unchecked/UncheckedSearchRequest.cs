using RestAssured.Request.Builders;
using RestAssured.Response;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Requests;
using static RestAssured.Dsl;

namespace TeamcityTestingFramework.src.Api.Requests.Unchecked
{
    public class UncheckedSearchRequest(RequestSpecification spec, Endpoint endpoint) : Request(spec, endpoint), IGetEntityDetailsByLocator<VerifiableResponse>
    {
        public VerifiableResponse GetDetails(string locator = "")
        {
            return Given()
                .Spec(Spec)
                .Get($"{Endpoint.Url}/{locator}");
        }
    }
}
