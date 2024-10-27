using Microsoft.Playwright;
using TeamcityTestingFramework.src.UI.Elements;

namespace TeamcityTestingFramework.src.UI.Pages
{
    public class ProjectsPage : BasePage
    {
        public static readonly string PROJECTS_URL = "/favorite/projects";

        private ILocator _projectElements;
        private ILocator _header;

        public ProjectsPage(IPage page) : base(page)
        {
            _projectElements = Page.Locator("div[class*='Subproject__container']");
            _header = Page.Locator(".MainPanel__router--gF");
        }

        public async Task NavigateAsync()
        {
            await Page.GotoAsync(PROJECTS_URL);
            await _header.WaitForAsync(new LocatorWaitForOptions() { State = WaitForSelectorState.Visible });
        }

        public async Task<List<ProjectElement>> GetProjectsAsync()
        {
            var locators = await _projectElements.AllAsync();
            return GeneratePageElements(locators, locator => new ProjectElement(locator));
        }
    }
}
