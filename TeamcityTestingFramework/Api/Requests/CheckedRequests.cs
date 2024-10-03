using RestAssured.Request.Builders;
using TeamcityTestingFramework.Api.Enums;
using TeamcityTestingFramework.Api.Models;
using TeamcityTestingFramework.Api.Requests.Checked;

namespace TeamcityTestingFramework.Api.Requests
{
    public class CheckedRequests
    {
        private readonly Dictionary<Endpoint, object> _requests;

        public CheckedRequests(RequestSpecification spec)
        {
            _requests = [];

            foreach (var endpoint in Endpoint.EndpointsList)
            {
                // Используем динамическое создание экземпляра CheckedBase с необходимым типом
                var checkedBaseInstance = CreateCheckedBaseInstance(spec, endpoint);
                _requests.Add(endpoint, checkedBaseInstance);
            }
        }

        private static object CreateCheckedBaseInstance(RequestSpecification spec, Endpoint endpoint)
        {
            // Используем рефлексию для создания объекта CheckedBase с типом, указанным в ModelClass
            var checkedBaseType = typeof(CheckedBase<>).MakeGenericType(endpoint.ModelClass);
            return Activator.CreateInstance(checkedBaseType, spec, endpoint);
        }

        // Метод для получения объекта CheckedBase по Endpoint
        public CheckedBase<T> GetRequest<T>(Endpoint endpoint) where T : BaseModel
        {
            if (_requests.TryGetValue(endpoint, out object? value))
            {
                return (CheckedBase<T>)value;
            }
            throw new KeyNotFoundException($"Endpoint '{endpoint.Url}' not found in the dictionary.");
        }
    }
}
