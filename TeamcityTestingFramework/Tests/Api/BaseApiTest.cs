using Allure.NUnit.Attributes;
using RestAssured.Request.Logging;
using RestAssured.Response.Logging;
using System.Net;
using TeamcityTestingFramework.Api.Enums;
using TeamcityTestingFramework.Api.Models;
using TeamcityTestingFramework.Api.Spec;
using static RestAssured.Dsl;

namespace TeamcityTestingFramework.Tests.Api
{
    public class BaseApiTest: BaseTest
    {
        [OneTimeSetUp]
        public void SetRestAssuredNetConfiguration()
        {
            RestAssuredConfig.DisableSslCertificateValidation = true;
            RestAssuredConfig.RequestLogLevel = RequestLogLevel.All;
            RestAssuredConfig.ResponseLogLevel = ResponseLogLevel.All;
        }

        private void ActivateRoles()
        {
            // TODO: add activate roles functionality
            //var authSettings = new AuthSettings() { perProjectPermissions = true };

            //Given()
            //    .Spec(Specifications.SuperUserAuth())
            //    .Body(authSettings)
            //    .Put(Endpoint.AUTH_SETTINGS.Url)
            //    .Then().AssertThat().StatusCode(HttpStatusCode.OK);
        }
    }
}
