using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Pages.Setup
{
    public class FirstStartPage : BasePage
    {
        private readonly ILocator _proceedButton;
        private readonly ILocator _restoreButton;
        private readonly ILocator _dbTypeSelect;
        private readonly ILocator _acceptLicenseCheckbox;
        private readonly ILocator _submitButton;

        public FirstStartPage(IPage page) : base(page)
        {
            _proceedButton = Page.Locator("#proceedButton");
            _restoreButton = Page.Locator("#restoreButton");
            _dbTypeSelect = Page.Locator("#dbType");
            _acceptLicenseCheckbox = Page.Locator("#accept");
            _submitButton = Page.Locator("input[type='submit']");
        }

        public async Task NavigateAsync()
        {
            await Page.GotoAsync("/");
            await _restoreButton.WaitForAsync(new LocatorWaitForOptions() { State = WaitForSelectorState.Visible, Timeout = LONG_WAITING_MS });
        }

        public async Task SetupFirstStartAsync()
        {
            await _proceedButton.ClickAsync();
            await _dbTypeSelect.WaitForAsync(new LocatorWaitForOptions() { State = WaitForSelectorState.Visible, Timeout = LONG_WAITING_MS });
            await _proceedButton.ClickAsync();
            await _acceptLicenseCheckbox.WaitForAsync(new LocatorWaitForOptions() { State = WaitForSelectorState.Attached, Timeout = LONG_WAITING_MS });
            await _acceptLicenseCheckbox.ScrollIntoViewIfNeededAsync();
            await _acceptLicenseCheckbox.ClickAsync();
            await _submitButton.ClickAsync();
        }
    }
}
