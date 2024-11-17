namespace TeamcityTestingFramework.src.Api.Models
{
    public class ServerAuthSettings : BaseModel
    {
        public bool perProjectPermissions;
        public AuthModules modules;
    }
}
