using RestAssured.Response.Logging;
using static RestAssured.Dsl;

namespace TeamcityTestingFramework.Tests.Api
{
    public class BaseApiTest: BaseTest
    {
        [OneTimeSetUp]
        public void SetRestAssuredNetConfiguration()
        {
            RestAssuredConfig.DisableSslCertificateValidation = true;
            //RestAssuredConfig.RequestLogLevel = RequestLogLevel.All;
            RestAssuredConfig.ResponseLogLevel = ResponseLogLevel.All;
        }
    }
}
