using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Pages
{
    public class BuildConfigurationPage : BasePage
    {
        private static readonly string BUILD_CONFIGURATION_URL = "/buildConfiguration/{0}";

        public readonly ILocator RunButton;
        public readonly ILocator BuildName;

        public BuildConfigurationPage(IPage page) : base(page)
        {
            RunButton = Page.Locator("button[data-test='run-build']");
            BuildName = Page.Locator("h1.ring-heading-heading > span");
        }

        public async Task NavigateAsync(string buildTypeId)
        {
            await Page.GotoAsync(string.Format(BUILD_CONFIGURATION_URL, buildTypeId));
        }
    }
}
