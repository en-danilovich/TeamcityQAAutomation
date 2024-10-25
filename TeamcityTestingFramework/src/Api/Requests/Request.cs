using RestAssured.Request.Builders;
using TeamcityTestingFramework.src.Api.Enums;

namespace TeamcityTestingFramework.src.Api.Requests
{
    public class Request(RequestSpecification spec, Endpoint endpoint)
    {
        /// <summary>
        /// Request - это класс, описывающий меняющиеся параметры запроса, такие как:
        /// спецификация, эндпоинт (relative URL, Model)
        /// </summary>

        protected RequestSpecification Spec { get; set; } = spec;
        protected Endpoint Endpoint { get; set; } = endpoint;
    }
}
