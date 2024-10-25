using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TeamcityTestingFramework.Tests.UI
{
    public class ExampleTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            // Set the desired capabilities for the browser
            var options = new ChromeOptions();
            //options.AddArgument("--headless"); // Run in headless mode if desired

            // Set the remote WebDriver URL (replace with your hub URL)
            var remoteWebDriverUrl = new Uri("http://localhost:4444/wd/hub");

            // Initialize the Remote WebDriver
            _driver = new RemoteWebDriver(remoteWebDriverUrl, options.ToCapabilities());
        }

        [Test]
        public void TestExample()
        {
            // Navigate to a webpage
            _driver.Navigate().GoToUrl("https://example.com");

            // Perform some actions (e.g., find an element and click)
            var someElement = _driver.FindElement(By.XPath("//h1"));
            var text = someElement.Text;

            // Assert a condition
            Assert.AreEqual("Example Domain", text);
        }

        [TearDown]
        public void Cleanup()
        {
            // Clean up the driver
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
