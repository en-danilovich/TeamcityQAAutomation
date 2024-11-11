using Allure.NUnit;
using TeamcityTestingFramework.src.Api.Generators;
using TeamcityTestingFramework.src.Api.Models;
using TeamcityTestingFramework.src.Api.Requests;
using TeamcityTestingFramework.src.Api.Spec;
using TeamcityTestingFramework.Tests.Api;

namespace TeamcityTestingFramework.Tests
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
            //TestDataStorage.GetInstance().DeleteCreatedEntities();
        }
    }
}