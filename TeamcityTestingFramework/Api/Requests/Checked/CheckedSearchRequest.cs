using Newtonsoft.Json;
using RestAssured.Request.Builders;
using System.Net;
using TeamcityTestingFramework.Api.Enums;
using TeamcityTestingFramework.Api.Models;
using TeamcityTestingFramework.Api.Requests.Unchecked;

namespace TeamcityTestingFramework.Api.Requests.Checked
{
    public class CheckedSearchRequest<T>(RequestSpecification spec, Endpoint endpoint) : Request(spec, endpoint), IGetEntityDetailsByLocator<T> where T: BaseModel
    {
        private readonly UncheckedSearchRequest _uncheckedSearchRequest = new(spec, endpoint);

        public T GetDetails(string locator = "")
        {
            var body = _uncheckedSearchRequest.GetDetails(locator)
                .Then().AssertThat().StatusCode(HttpStatusCode.OK)
                .Extract().Body();
            return JsonConvert.DeserializeObject<T>(body);
        }
    }
}
