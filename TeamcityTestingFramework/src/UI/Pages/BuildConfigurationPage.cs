using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Pages
{
    public class BuildConfigurationPage : BasePage
    {
        private static readonly string BUILD_CONFIGURATION_URL = "/buildConfiguration/{0}";

        public readonly ILocator RunButton;

        public BuildConfigurationPage(IPage page) : base(page)
        {
            RunButton = Page.Locator("button[data-test='run-build']");
        }

        public async Task NavigateAsync(string buildTypeId)
        {
            await Page.GotoAsync(string.Format(BUILD_CONFIGURATION_URL, buildTypeId));
        }
    }
}
