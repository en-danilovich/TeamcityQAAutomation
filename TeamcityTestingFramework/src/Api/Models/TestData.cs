namespace TeamcityTestingFramework.src.Api.Models
{
    public record TestData
    {
        public Project Project;
        public User User;
        public BuildType BuildType;
        public BuildQueue BuildQueue;
    }
}
