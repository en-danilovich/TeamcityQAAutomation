using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Pages
{
    public abstract class BasePage
    {
        protected readonly IPage Page;

        public BasePage(IPage page)
        {
            Page = page;
        }
    }
}
