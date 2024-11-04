using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Pages.Admin
{
    public class CreateBuildTypePage : CreateBasePage
    {
        private static readonly string BUILD_SHOW_MODE = "createBuildTypeMenu";

        public CreateBuildTypePage(IPage page) : base(page)
        {
        }

        public async Task NavigateAsync(string projectId = "_Root")
        {
            await Page.GotoAsync(string.Format(CREATE_URL, projectId, BUILD_SHOW_MODE));
        }

        public async Task CreateFormAsync(string repoUrl)
        {
            await BaseCreateFormAsync(repoUrl);
        }

        public async Task<BuildTypeDetailsPage> SetupBuildTypeAsync(string buildType)
        {
            await BuildTypeInput.FillAsync(buildType);
            await SubmitButton.ClickAsync();
            await Page.WaitForURLAsync($"**{BuildTypeDetailsPage.PAGE_URL}**");
            return new BuildTypeDetailsPage(Page);
        }
    }
}
