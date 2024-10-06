using RestAssured.Request.Builders;
using RestAssured.Response;
using TeamcityTestingFramework.Api.Enums;
using static RestAssured.Dsl;

namespace TeamcityTestingFramework.Api.Requests.Unchecked
{
    public class UncheckedBuildRequest(RequestSpecification spec) : Request(spec, Endpoint.BUILDS), IGetEntityDetailsByLocator<VerifiableResponse>
    {
        public VerifiableResponse GetDetails(string locator = "")
        {
            return Given()
                .Spec(Spec)
                .Get($"{Endpoint.Url}/{locator}");
        }
    }
}
