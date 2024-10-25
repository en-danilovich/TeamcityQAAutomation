using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Extensions;

namespace TeamcityTestingFramework.src.Api.Models
{
    public class Role : BaseModel
    {
        public string roleId = UserRole.SystemAdmin.ToDescription();
        public string scope = "g";
    }
}
