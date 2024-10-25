using Newtonsoft.Json;
using RestAssured.Request.Builders;
using System.Net;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Models;
using TeamcityTestingFramework.src.Api.Requests;
using TeamcityTestingFramework.src.Api.Requests.Unchecked;

namespace TeamcityTestingFramework.src.Api.Requests.Checked
{
    public class CheckedSearchRequest<T>(RequestSpecification spec, Endpoint endpoint) : Request(spec, endpoint), IGetEntityDetailsByLocator<T> where T : BaseModel
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
