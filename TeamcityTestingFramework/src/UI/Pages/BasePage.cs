using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Pages
{
    public abstract class BasePage
    {
        protected static readonly float BASE_WAITING_MS = 30000; // 30 sec
        protected static readonly float LONG_WAITING_MS = 180000; // 3 min

        protected readonly IPage Page;

        public BasePage(IPage page)
        {
            Page = page;
        }
    }
}
