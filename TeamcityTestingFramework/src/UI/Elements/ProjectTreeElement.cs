using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Elements
{
    public class ProjectTreeElement : BasePageElement
    {
        public readonly ILocator Name;

        public ProjectTreeElement(ILocator locator) : base(locator)
        {
            Name = Locator("span[class*='ProjectsTreeItem__name']");
        }
    }
}
