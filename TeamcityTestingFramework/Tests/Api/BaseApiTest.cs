using RestAssured.Request.Logging;
using RestAssured.Response.Logging;
using TeamcityTestingFramework.src.Api.Generators;
using TeamcityTestingFramework.src.Api.Models;
using TeamcityTestingFramework.src.Api.Requests;
using TeamcityTestingFramework.src.Api.Spec;
using static RestAssured.Dsl;

namespace TeamcityTestingFramework.Tests.Api
{
    public class BaseApiTest: BaseTest
    {
        private ServerAuthRequest _serverAuthRequest = new(Specifications.SuperUserAuthSpec());
        private AuthModules _authModules;
        private bool _perProjectPermissions;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            RestAssuredConfig.DisableSslCertificateValidation = true;
            RestAssuredConfig.RequestLogLevel = RequestLogLevel.All;
            RestAssuredConfig.ResponseLogLevel = ResponseLogLevel.All;

            SetupServerAuthSettings();
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // set perProjectPermissions to default (before test run)
            _serverAuthRequest.Update(new ServerAuthSettings()
            {
                perProjectPermissions = _perProjectPermissions,
                modules = _authModules
            });
        }

        [TearDown]
        public void TearDown()
        {
            softy.AssertAll();
        }

        private void SetupServerAuthSettings()
        {
            // get current project permissions
            _perProjectPermissions = _serverAuthRequest.Read().perProjectPermissions;

            // set perProjectPermissions to True so we can test roles
            _authModules = TestDataGenerator.Generate<AuthModules>();
            _serverAuthRequest.Update(new ServerAuthSettings()
            {
                perProjectPermissions = true,
                modules = _authModules
            });
        }
    }
}
