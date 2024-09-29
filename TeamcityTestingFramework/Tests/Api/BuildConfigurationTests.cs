using TeamcityTestingFramework.Api.Models;
using TeamcityTestingFramework.Api.Spec;
using static RestAssured.Dsl;

namespace TeamcityTestingFramework.Tests.Api
{
    [TestFixture]
    public class BuildConfigurationTests: BaseApiTest
    {
        [Test]
        public void BuildConfiguraitonTest()
        {
            var user = new User(Username: "admin", Password: "admin");

            var token = Given()
                .Spec(Specifications.GetSpec().AuthSpec(user))
                .QueryParam("csrf")
                .Get("/authenticationTest.html")
                .Then().AssertThat().StatusCode(System.Net.HttpStatusCode.OK)
                .Extract().Body().ToString();

            Console.WriteLine(token);
        }
    }
}
