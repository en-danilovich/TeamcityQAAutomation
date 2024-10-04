using TeamcityTestingFramework.Api.Attributes;
using RandomAttribute = TeamcityTestingFramework.Api.Attributes.RandomAttribute;

namespace TeamcityTestingFramework.Api.Models
{
    public class BuildType: BaseModel
    {
        [Random]
        [Parameterizable]
        public string id;

        [Random]
        public string name;

        [Parameterizable]
        public Project project;

        [Optional]
        public Steps steps;
    }
}
