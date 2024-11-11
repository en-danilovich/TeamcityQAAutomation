using Microsoft.Playwright;

namespace TeamcityTestingFramework.src.UI.Elements
{
    public class SubprojectBuildTypeElement : BasePageElement
    {
        public readonly ILocator BuildTypeButton;

        public SubprojectBuildTypeElement(ILocator locator) : base(locator)
        {
            BuildTypeButton = Locator("button[class*='BuildTypeLine__button']");
        }
    }
}
