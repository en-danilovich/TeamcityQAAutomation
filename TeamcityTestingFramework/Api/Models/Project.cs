namespace TeamcityTestingFramework.Api.Models
{
    public record Project: BaseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Locator { get; set; } = "_Root";
    }
}
