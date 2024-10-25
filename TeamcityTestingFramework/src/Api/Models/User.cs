using TeamcityTestingFramework.src.Api.Attributes;
using RandomAttribute = TeamcityTestingFramework.src.Api.Attributes.RandomAttribute;

namespace TeamcityTestingFramework.src.Api.Models
{
    public class User : BaseModel
    {
        public long id;

        [Random]
        public string username;

        [Random]
        public string password;

        [Parameterizable]
        public Roles roles;
    }
}
