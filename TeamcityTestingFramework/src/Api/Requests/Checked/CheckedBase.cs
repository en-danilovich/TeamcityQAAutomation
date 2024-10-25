using Newtonsoft.Json;
using RestAssured.Request.Builders;
using System.Net;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Generators;
using TeamcityTestingFramework.src.Api.Models;
using TeamcityTestingFramework.src.Api.Requests;
using TeamcityTestingFramework.src.Api.Requests.Unchecked;

namespace TeamcityTestingFramework.src.Api.Requests.Checked
{
    public sealed class CheckedBase<T>(RequestSpecification spec, Endpoint endpoint) : Request(spec, endpoint), ICrudOperations<T, string> where T : BaseModel
    {
        private readonly UncheckedBase _uncheckedBase = new(spec, endpoint);

        public T Create(BaseModel model)
        {
            var body = _uncheckedBase.Create(model)
                .Then().AssertThat().StatusCode(HttpStatusCode.OK)
                .Extract().Body();
            var extractedObj = JsonConvert.DeserializeObject<T>(body);

            TestDataStorage.GetInstance().AddCreatedEntity(endpoint, extractedObj);
            return extractedObj;
        }

        public string Delete(string id)
        {
            return _uncheckedBase.Delete(id)
               .Then().AssertThat().StatusCode(HttpStatusCode.OK)
               .Extract().Body();
        }

        public T Read(string id)
        {
            var body = _uncheckedBase.Read(id)
                .Then().AssertThat().StatusCode(HttpStatusCode.OK)
                .Extract().Body();
            return JsonConvert.DeserializeObject<T>(body);
        }

        public T Update(string id, BaseModel model)
        {
            var body = _uncheckedBase.Update(id, model)
                .Then().AssertThat().StatusCode(HttpStatusCode.OK)
                .Extract().Body();
            return JsonConvert.DeserializeObject<T>(body);
        }
    }
}
