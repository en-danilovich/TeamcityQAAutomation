using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Elements
{
    public class ProjectElement : BasePageElement
    {
        public readonly ILocator Name;
        public readonly ILocator Link;
        public readonly ILocator Button;

        public ProjectElement(ILocator locator) : base(locator)
        {
            Name = Locator("span[class*='MiddleEllipsis']").First;
            Link = Locator("a");
            Button = Locator("button");
        }
    }
}
