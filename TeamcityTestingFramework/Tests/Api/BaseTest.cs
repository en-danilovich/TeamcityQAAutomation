using Allure.NUnit;
using TeamcityTestingFramework.Api.Requests;
using TeamcityTestingFramework.Api.Spec;

namespace TeamcityTestingFramework.Tests.Api
{
    [AllureNUnit]
    [TestFixture]
    public class BaseTest
    {
        protected SoftAssert softy;
        protected CheckedRequests superUserCheckRequests = new(Specifications.SuperUserAuthSpec());

        [SetUp]
        public void TestSetUp()
        {
            softy = new SoftAssert();
        }

        [TearDown]
        public void TestTearDown()
        {
            softy.AssertAll();
        }
    }
}