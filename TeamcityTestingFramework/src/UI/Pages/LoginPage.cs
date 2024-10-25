using Microsoft.Playwright;
using TeamcityTestingFramework.src.Api.Models;

namespace TeamcityTestingFramework.src.UI.Pages
{
    public class LoginPage : BasePage
    {
        private static readonly string LOGIN_URL = "/login.html";

        private readonly ILocator _userNameInput;
        private readonly ILocator _passwordInput;
        private readonly ILocator _submitLoginInput;

        public LoginPage(IPage page) : base(page)
        {
            _userNameInput = Page.Locator("#username");
            _passwordInput = Page.Locator("#password");
            _submitLoginInput = Page.Locator(".loginButton[type='submit']");
        }

        public async Task NavigateAsync()
        {            
            await Page.GotoAsync(LOGIN_URL);
        }

        public async Task LoginAsync(User user)
        {
            await _userNameInput.FillAsync(user.username);
            await _passwordInput.FillAsync(user.password);
            await _submitLoginInput.ClickAsync();
            await Page.WaitForLoadStateAsync();
        }
    }
}
