using TeamcityTestingFramework.Api.Attributes;
using RandomAttribute = TeamcityTestingFramework.Api.Attributes.RandomAttribute;

namespace TeamcityTestingFramework.Api.Models
{
    public record BuildType: BaseModel
    {
        public string Id { get; set; }

        [Random]
        public string Name { get; set; }

        [Parameterizable]
        public Project Project { get; set; }

        [Optional]
        public Steps Steps { get; set; }
    }
}
