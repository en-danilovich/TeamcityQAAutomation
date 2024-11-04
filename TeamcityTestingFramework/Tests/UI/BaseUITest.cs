using Microsoft.Playwright;
using TeamcityTestingFramework.src.Api.Config;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Models;
using TeamcityTestingFramework.src.UI.Pages;

namespace TeamcityTestingFramework.Tests.UI
{
    [TestFixture]
    public class BaseUITest : BaseTest
    {
        private IPlaywright _playwright;
        public IBrowser Browser { get; private set; }
        public IBrowserContext BrowserContext { get; private set; }
        public IPage Page { get; private set; }

        [OneTimeSetUp]
        public async Task SetupUITest()
        {
            _playwright = await Playwright.CreateAsync();

            var browserType = Config.GetProperty<string>("browser").ToLower();
            var browserLaunchOptions = new BrowserTypeLaunchOptions()
            {
                Headless = Config.GetProperty<bool>("headless"),
            };
            Browser = browserType switch
            {
                "firefox" => await _playwright.Firefox.LaunchAsync(browserLaunchOptions),
                "webkit" => await _playwright.Webkit.LaunchAsync(browserLaunchOptions),
                _ => await _playwright.Chromium.LaunchAsync(browserLaunchOptions)
            };
        }

        [SetUp]
        public async Task SetUp()
        {
            BrowserContext = await Browser.NewContextAsync(new BrowserNewContextOptions()
            {
                BaseURL = $"http://{Config.GetProperty<string>("host")}",
                ViewportSize = new ViewportSize() { Width = Config.GetProperty<int>("viewportWidth"), Height = Config.GetProperty<int>("viewportHeight") },
            });
            await BrowserContext.ClearCookiesAsync();

            Page = await BrowserContext.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await Page.CloseAsync();
            await BrowserContext.CloseAsync();
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            await Browser.CloseAsync();
            await Browser.DisposeAsync();
            _playwright.Dispose();
        }

        protected async Task LoginAsAsync(User user)
        {
            superUserCheckRequests.GetRequest<User>(Endpoint.USERS).Create(TestData.User);

            var loginPage = new LoginPage(Page);
            await loginPage.NavigateAsync();
            await loginPage.LoginAsync(user);
        }
    }
}
