using RandomAttribute = TeamcityTestingFramework.Api.Attributes.RandomAttribute;

namespace TeamcityTestingFramework.Api.Models
{
    public record User : BaseModel
    {
        [Random]
        public string username;

        [Random]
        public string password;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public User()
        {

        }
    }
}
