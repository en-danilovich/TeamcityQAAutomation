using RandomAttribute = TeamcityTestingFramework.src.Api.Attributes.RandomAttribute;

namespace TeamcityTestingFramework.src.Api.Models
{
    public class Project : BaseModel
    {
        [Random]
        public string id;

        [Random]
        public string name;

        public string locator;
    }
}
