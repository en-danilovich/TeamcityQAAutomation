using Allure.Net.Commons;
using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.Utils
{
    public class PlaywrightHelper
    {
        private IPage _page;

        public PlaywrightHelper(IPage page)
        {
            _page = page;
        }

        public async Task CaptureScreenshotOnFailureAsync(string testName)
        {
            if (_page == null)
            {
                return;
            }

            var screenshotPath = Path.Combine(Directory.GetCurrentDirectory(), "allure-results", $"{testName}-screenshot.png");

            Directory.CreateDirectory(Path.GetDirectoryName(screenshotPath));

            var screenshotBytes = await _page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath });

            // Save screenshot as attachment in Allure report
            AllureApi.AddAttachment($"{testName} Screenshot", "image/png", screenshotBytes, ".png");
        }
    }
}
