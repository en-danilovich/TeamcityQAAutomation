using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace TeamcityTestingFramework.src.Api.Enums
{
    public enum UserRole
    {
        [Description("SYSTEM_ADMIN")]
        SystemAdmin,
        [Description("PROJECT_ADMIN")]
        ProjectAdmin
    }
}
