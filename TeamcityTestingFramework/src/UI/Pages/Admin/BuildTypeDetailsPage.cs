using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Pages.Admin
{
    public class BuildTypeDetailsPage : BasePage
    {
        public static readonly string PAGE_URL = "/admin/discoverRunners.html";
        private static readonly string BUILD_CREATED_MESSAGE_TEMPLATE = "New build configuration \"{0}\" and VCS root \"{1}\" have been successfully created.";

        private ILocator _successMessage;

        private ILocator _buildTitle;

        public BuildTypeDetailsPage(IPage page) : base(page)
        {
            _successMessage = Page.Locator("#unprocessed_objectsCreated");
            _buildTitle = Page.Locator("#restPageTitle");
        }

        public async Task VerifyBuildTypeCreatedAsync(string buildTypeName, string vsc)
        {
            var _buildTitleText = await _buildTitle.TextContentAsync();
            await Assertions.Expect(_buildTitle).ToHaveTextAsync(buildTypeName);
            await Assertions.Expect(_successMessage).ToHaveTextAsync(string.Format(BUILD_CREATED_MESSAGE_TEMPLATE, buildTypeName, vsc));
        }
    }
}
