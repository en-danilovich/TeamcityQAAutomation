using Microsoft.Playwright;
using TeamcityTestingFramework.src.UI.Elements;

namespace TeamcityTestingFramework.src.Extensions
{
    public static class ElementsExtensions
    {
        public static List<T> GenerateElements<T>(this IReadOnlyList<ILocator> locatorsList, Func<ILocator, T> creator) where T : BasePageElement
        {
            return locatorsList.Select(creator).ToList();
        }
    }
}
