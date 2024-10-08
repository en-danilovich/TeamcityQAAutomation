using RestAssured.Request.Builders;
using RestAssured.Response;
using TeamcityTestingFramework.Api.Enums;
using static RestAssured.Dsl;

namespace TeamcityTestingFramework.Api.Requests.Unchecked
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
