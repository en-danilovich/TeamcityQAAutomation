using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Pages.Admin
{
    public abstract class CreateBasePage : BasePage
    {
        protected static readonly string CREATE_URL = "admin/createObjectMenu.html?projectId={0}&showMode={1}";

        protected ILocator _repositoryUrlInput;
        protected ILocator _submitButton;
        protected ILocator _buildTypeInput;

        protected CreateBasePage(IPage page) : base(page)
        {
            _repositoryUrlInput = Page.Locator("#url");
            _submitButton = Page.Locator("[value='Proceed']");
            _buildTypeInput = Page.Locator("#buildTypeName");
        }

        protected async Task BaseCreateFormAsync(string repoUrl)
        {
            await _repositoryUrlInput.FillAsync(repoUrl);
            await _submitButton.ClickAsync();
        }
    }
}
