using TeamcityTestingFramework.Api.Attributes;
using RandomAttribute = TeamcityTestingFramework.Api.Attributes.RandomAttribute;

namespace TeamcityTestingFramework.Api.Models
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
