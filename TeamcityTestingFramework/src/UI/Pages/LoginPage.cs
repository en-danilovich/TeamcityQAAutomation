using Allure.NUnit.Attributes;
using Microsoft.Playwright;
using System.Net;
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

        [AllureStep("Open login page")]
        public async Task NavigateAsync()
        {            
            await Page.GotoAsync(LOGIN_URL);
        }

        [AllureStep("Login as {user.username}")]
        public async Task LoginAsync(User user)
        {
            await _userNameInput.FillAsync(user.username);
            await _passwordInput.FillAsync(user.password);
            await Page.RunAndWaitForResponseAsync(async () =>
            {
                await _submitLoginInput.ClickAsync();
            }, response => response.Url.Contains("loginSubmit.html") && response.Status == (int)HttpStatusCode.OK && response.Request.Method == "POST");
        }
    }
}
