using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Pages.Admin
{
    public abstract class CreateBasePage : BasePage
    {
        protected static readonly string CREATE_URL = "/admin/createObjectMenu.html?projectId={0}&showMode={1}";

        public readonly ILocator RepositoryUrlInput;
        public readonly ILocator SubmitButton;

        public readonly ILocator BuildTypeInput;
        public readonly ILocator BuildTypeNameError;

        public readonly ILocator ConnectionSuccessfulMessage;

        protected CreateBasePage(IPage page) : base(page)
        {
            RepositoryUrlInput = Page.Locator("#url");
            SubmitButton = Page.Locator("[value='Proceed']");
            BuildTypeInput = Page.Locator("#buildTypeName");
            BuildTypeNameError = Page.Locator("#error_buildTypeName");
            ConnectionSuccessfulMessage = Page.Locator(".connectionSuccessful");
        }

        protected async Task BaseCreateFormAsync(string repoUrl)
        {
            await RepositoryUrlInput.FillAsync(repoUrl);
            await SubmitButton.ClickAsync();
            await Assertions.Expect(ConnectionSuccessfulMessage).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions() { Timeout = BASE_WAITING_MS });
        }
    }
}
