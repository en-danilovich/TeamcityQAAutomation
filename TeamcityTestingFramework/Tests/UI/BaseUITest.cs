using Microsoft.Playwright;
using TeamcityTestingFramework.src.Api.Config;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Models;
using TeamcityTestingFramework.src.UI.Pages;

namespace TeamcityTestingFramework.Tests.UI
{
    public class BaseUITest : BaseTest
    {
        public IBrowser Browser { get; private set; }
        public IPage Page { get; private set; }


        [OneTimeSetUp]
        public async Task SetupUITest()
        {
            var playwright = await Playwright.CreateAsync();            
            var browserType = Config.GetProperty<string>("browser").ToLower();

            var browserLaunchOptions = new BrowserTypeLaunchOptions()
            {
                Headless = Config.GetProperty<bool>("headless"),
                //Channel = "chrome",
                //ExecutablePath = Config.GetProperty<string>("remote"),
                
            };

            Browser = browserType switch
            {
                "firefox" => await playwright.Firefox.LaunchAsync(browserLaunchOptions),
                "webkit" => await playwright.Webkit.LaunchAsync(browserLaunchOptions),
                _ => await playwright.Chromium.LaunchAsync(browserLaunchOptions)
            };

            //var context = await Browser.NewContextAsync(new BrowserNewContextOptions()
            //{
            //    BaseURL = $"http://{Config.GetProperty<string>("host")}",
            //    ViewportSize = new ViewportSize() { Width = Config.GetProperty<int>("viewportWidth"), Height = Config.GetProperty<int>("viewportHeight") },
            //});

            Page = await Browser.NewPageAsync(new BrowserNewPageOptions()
            {
                BaseURL = $"http://{Config.GetProperty<string>("host")}",
                ViewportSize = new ViewportSize() { Width = Config.GetProperty<int>("viewportWidth"), Height = Config.GetProperty<int>("viewportHeight") },
            });

        }

        [TearDown]
        public async Task TearDown()
        {
            //await Page.CloseAsync();
            await Browser.CloseAsync();
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
