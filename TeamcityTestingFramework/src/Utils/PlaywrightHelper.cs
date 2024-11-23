using Allure.Net.Commons;
using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.Utils
{
    public class PlaywrightHelper
    {
        private IPage _page;

        public void SetPage(IPage page)
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
            var screenshotBytes = await _page.ScreenshotAsync(new PageScreenshotOptions { FullPage = true });

            // Save screenshot as attachment in Allure report
            AllureApi.AddAttachment($"{testName} Screenshot", "image/png", screenshotBytes, ".png");
        }
    }
}
