using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Pages.Admin
{
    public class CreateProjectPage : CreateBasePage
    {
        private static readonly string PROJECT_SHOW_MODE = "createProjectMenu";

        private ILocator _projectNameInput;

        public CreateProjectPage(IPage page) : base(page)
        {
            _projectNameInput = Page.Locator("#projectName");
        }

        public async Task NavigateAsync(string projectId = "_Root")
        {
            await Page.GotoAsync(string.Format(CREATE_URL, projectId, PROJECT_SHOW_MODE));
        }

        public async Task CreateForm(string repoUrl)
        {
            await BaseCreateFormAsync(repoUrl);
        }

        public async Task<ProjectsPage> SetupProjectAsync(string projectName, string buildType)
        {
            await _projectNameInput.FillAsync(projectName);
            await _buildTypeInput.FillAsync(buildType);
            await _submitButton.ClickAsync();
            return new ProjectsPage(Page);
        }
    }
}
