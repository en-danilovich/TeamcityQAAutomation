using Allure.NUnit;
using TeamcityTestingFramework.Api.Generators;
using TeamcityTestingFramework.Api.Models;
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
        protected TestData TestData { get; private set; }

        [SetUp]
        public void TestSetUp()
        {
            softy = new SoftAssert();
            TestData = TestDataGenerator.Generate();
        }

        [TearDown]
        public void TestTearDown()
        {
            softy.AssertAll();
            TestDataStorage.GetInstance().DeleteCreatedEntities();
        }
    }
}