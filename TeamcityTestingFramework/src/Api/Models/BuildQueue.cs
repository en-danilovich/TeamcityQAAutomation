namespace TeamcityTestingFramework.src.Api.Models
{
    public class BuildQueue : BaseModel
    {
        public long id;
        public BuildType buildType;
        public string state;
    }
}
