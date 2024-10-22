using Microsoft.Playwright;
using TeamcityTestingFramework.Api.Config;

namespace TeamcityTestingFramework.Tests.UI
{
    public class BaseUITest : BaseTest
    {
        public IBrowser Browser { get; private set; }
        public IPage Page { get; private set; }

        [OneTimeSetUp]
        // TODO: mayabe use setup attribute
        public async Task SetupUITest()
        {            
            var playwright = await Playwright.CreateAsync();
            var browserType = Config.GetProperty<string>("browser").ToLower();

            var browserLaunchOptions = new BrowserTypeLaunchOptions()
            {
                Headless = false,
                //Channel = "chrome",
                ExecutablePath = Config.GetProperty<string>("remote"),                
            };

            Browser = browserType switch
            {
                "firefox" => await playwright.Firefox.LaunchAsync(browserLaunchOptions),
                "webkit" => await playwright.Webkit.LaunchAsync(browserLaunchOptions),
                _ => await playwright.Chromium.LaunchAsync(browserLaunchOptions)
            };

            Page = await Browser.NewPageAsync(new BrowserNewPageOptions
            {
                BaseURL = $"http://{Config.GetProperty<string>("host")}",
                ViewportSize = new ViewportSize() { Width = Config.GetProperty<int>("viewportWidth"), Height = Config.GetProperty<int>("viewportWidth") }
            });

        }

        [TearDown]
        public async Task TearDown()
        {
            await Page.CloseAsync();
            await Browser.CloseAsync();
        }
    }
}
