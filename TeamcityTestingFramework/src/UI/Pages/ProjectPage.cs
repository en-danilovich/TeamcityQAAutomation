using Allure.NUnit.Attributes;
using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Pages
{
    public class ProjectPage : BasePage
    {
        private static readonly string PROJECT_URL = "/project/{0}";

        private string _projectId;

        public ILocator _projectTitle;

        public ProjectPage(IPage page, string projectId) : base(page)
        {
            _projectId = projectId;
            _projectTitle = Page.Locator("span[class*='ProjectPageHeader']");
        }

        [AllureStep("Open project page")]
        public async Task NavigateAsync()
        {
            await Page.GotoAsync(string.Format(PROJECT_URL, _projectId));
        }
    }
}
