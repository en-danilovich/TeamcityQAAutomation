using RestAssured.Request.Builders;
using TeamcityTestingFramework.Api.Enums;

namespace TeamcityTestingFramework.Api.Requests
{
    public class Request(RequestSpecification spec, Endpoint endpoint)
    {
        /// <summary>
        /// Request - это класс, описывающий меняющиеся параметры запроса, такие как:
        /// спецификация, эндпоинт (relative URL, Model)
        /// </summary>
        private readonly RequestSpecification _spec = spec;
        private readonly Endpoint _endpoint = endpoint;
    }
}
