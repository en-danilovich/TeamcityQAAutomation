using Microsoft.Playwright;
using TeamcityTestingFramework.src.Extensions;

namespace TeamcityTestingFramework.src.UI.Elements
{
    public class ProjectElement : BasePageElement
    {
        public readonly ILocator Name;
        public readonly ILocator Link;
        public readonly ILocator ShowSubprojectsArrow;
        public readonly ILocator SubprojectBuildTypesLocator;

        public ProjectElement(ILocator locator) : base(locator)
        {
            Name = Locator("span[class*='MiddleEllipsis']").First;
            Link = Locator("a");            
            ShowSubprojectsArrow = Locator("span[class*='Subproject__arrow']");
            SubprojectBuildTypesLocator = Locator("[class*='BuildTypes__item']");
        }

        public async Task<IReadOnlyList<SubprojectBuildTypeElement>> GetSubprojectBuildTypes()
        {
            var locators = await SubprojectBuildTypesLocator.AllAsync();
            return locators.GenerateElements(locator => new SubprojectBuildTypeElement(locator));
        }
    }
}
