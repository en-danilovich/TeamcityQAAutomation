namespace TeamcityTestingFramework.Api.Models
{
    public record BuildType: BaseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
        public Steps Steps { get; set; }
    }
}
