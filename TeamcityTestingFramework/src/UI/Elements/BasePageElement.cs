using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Elements
{
    public abstract class BasePageElement
    {
        protected readonly ILocator _elementLocator;

        public BasePageElement(ILocator locator)
        {
            _elementLocator = locator;
        }

        protected ILocator Locator(string selector)
        {
            return _elementLocator.Locator(selector);
        }
    }
}
