namespace TeamcityTestingFramework.Api.Models
{
    public record Step: BaseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } = "simpleRunner";
    }
}
