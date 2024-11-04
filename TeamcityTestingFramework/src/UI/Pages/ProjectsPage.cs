using Microsoft.Playwright;
using TeamcityTestingFramework.src.Extensions;
using TeamcityTestingFramework.src.UI.Elements;

namespace TeamcityTestingFramework.src.UI.Pages
{
    public class ProjectsPage : BasePage
    {
        public static readonly string PROJECTS_URL = "/favorite/projects";

        private string _headerStringLocator = ".MainPanel__router--gF > div";

        private ILocator _projectElements;
        private ILocator _header;
        private ILocator _childProjectsLoader;
        private ILocator _treeProjectsLoader;
        public ILocator ProjectsTreeItems;
        private ILocator _searchProjectsInput;

        public ProjectsPage(IPage page) : base(page)
        {
            _projectElements = Page.Locator("div[class*='Subproject__container']");
            _header = Page.Locator(_headerStringLocator);
            _childProjectsLoader = Page.Locator(".ring-loader-inline-children");
            _treeProjectsLoader = Page.Locator("div[data-test='ring-loader-inline']");
            ProjectsTreeItems = Page.Locator("div[class*='ProjectsTreeItem__row']");
            _searchProjectsInput = Page.Locator("#search-projects");
        }

        public async Task NavigateAsync()
        {
            await Page.GotoAsync(PROJECTS_URL);
            await WaitForProjectsToBeLoadedAsync();
        }

        public async Task SearchProject(string searchText)
        {
            await _searchProjectsInput.FillAsync(searchText);
            await _treeProjectsLoader.WaitForAsync(new LocatorWaitForOptions()
            {
                State = WaitForSelectorState.Hidden
            });
        }

        public async Task<List<ProjectElement>> GetProjectsAsync()
        {
            await WaitForProjectsToBeLoadedAsync();
            var locators = await _projectElements.AllAsync();
            return locators.GenerateElements(locator => new ProjectElement(locator));
        }

        public async Task<List<ProjectTreeElement>> GetProjectsFromTreeAsync()
        {
            var locators = await ProjectsTreeItems.AllAsync();
            return locators.GenerateElements(locator => new ProjectTreeElement(locator));
        }

        private async Task WaitForProjectsToBeLoadedAsync()
        {
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            await _childProjectsLoader.WaitForAsync(new LocatorWaitForOptions()
            {
                State = WaitForSelectorState.Hidden
            });
        }
    }
}
