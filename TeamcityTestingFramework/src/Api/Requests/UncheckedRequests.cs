using RestAssured.Request.Builders;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Requests.Unchecked;

namespace TeamcityTestingFramework.src.Api.Requests
{
    public class UncheckedRequests
    {
        private Dictionary<Endpoint, UncheckedBase> _requests;

        public UncheckedRequests(RequestSpecification spec)
        {
            _requests = [];
            foreach (var endpoint in Endpoint.EndpointsList)
            {
                _requests.Add(endpoint, new UncheckedBase(spec, endpoint));
            }
        }

        public UncheckedBase GetRequest(Endpoint endpoint)
        {
            if (_requests.TryGetValue(endpoint, out UncheckedBase? value))
            {
                return value;
            }
            throw new KeyNotFoundException($"Endpoint '{endpoint.Url}' not found in the dictionary.");
        }
    }
}
