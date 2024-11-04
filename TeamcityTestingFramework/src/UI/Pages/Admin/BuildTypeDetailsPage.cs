using Microsoft.Playwright;
using System.Text.RegularExpressions;

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

        public string ParseProjectIdFromUrl()
        {
            string pattern = @"buildType:([a-zA-Z0-9]+)_";
            var regex = new Regex(pattern);
            var match = regex.Match(Page.Url);
            if (match.Success)
            {
                // Extract the project ID from the matched group
                return match.Groups[1].Value;
            }
            else
            {
                throw new KeyNotFoundException("No valid project id found in the URL.");
            }
        }

        public string ParseBuildtypeIdFromUrl()
        {
            string pattern = @"buildType:(.+)";
            var match = Regex.Match(Page.Url, pattern);
            if (match.Success)
            {
                // Extract the build type ID from the matched group
                return match.Groups[1].Value;
            }
            else
            {
                throw new KeyNotFoundException("No valid buildType found in the URL.");
            }
        }
    }
}
