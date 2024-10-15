using TeamcityTestingFramework.Api.Enums;
using TeamcityTestingFramework.Extensions;

namespace TeamcityTestingFramework.Api.Models
{
    public class Role : BaseModel
    {
        public string roleId = UserRole.SystemAdmin.ToDescription();
        public string scope = "g";
    }
}
