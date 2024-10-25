using TeamcityTestingFramework.src.Api.Attributes;
using RandomAttribute = TeamcityTestingFramework.src.Api.Attributes.RandomAttribute;

namespace TeamcityTestingFramework.src.Api.Models
{
    public class Step : BaseModel
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
