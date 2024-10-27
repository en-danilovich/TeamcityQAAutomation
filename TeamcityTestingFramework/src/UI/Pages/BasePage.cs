using Microsoft.Playwright;
using TeamcityTestingFramework.src.UI.Elements;

namespace TeamcityTestingFramework.src.UI.Pages
{
    public abstract class BasePage
    {
        protected static readonly float BASE_WAITING_MS = 30000;

        protected readonly IPage Page;

        public BasePage(IPage page)
        {
            Page = page;
        }

        protected List<T> GeneratePageElements<T>(IReadOnlyList<ILocator> locatorsList, Func<ILocator, T> creator) where T : BasePageElement
        {
            return locatorsList.Select(creator).ToList();
        }
    }
}
