using RandomAttribute = TeamcityTestingFramework.Api.Attributes.RandomAttribute;

namespace TeamcityTestingFramework.Api.Models
{
    public class Project: BaseModel
    {
        [Random]
        public string id;

        [Random]
        public string name;

        public string locator;
    }
}
