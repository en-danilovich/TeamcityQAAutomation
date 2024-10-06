using TeamcityTestingFramework.Api.Attributes;
using RandomAttribute = TeamcityTestingFramework.Api.Attributes.RandomAttribute;

namespace TeamcityTestingFramework.Api.Models
{
    public class Step: BaseModel
    {
        [Random]
        public string id;

        [Random]
        public string name;

        public string type = "simpleRunner";

        [Parameterizable]
        public Properties properties;
    }
}
