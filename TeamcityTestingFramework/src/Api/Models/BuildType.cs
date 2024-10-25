using TeamcityTestingFramework.src.Api.Attributes;
using RandomAttribute = TeamcityTestingFramework.src.Api.Attributes.RandomAttribute;

namespace TeamcityTestingFramework.src.Api.Models
{
    public class BuildType : BaseModel
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
