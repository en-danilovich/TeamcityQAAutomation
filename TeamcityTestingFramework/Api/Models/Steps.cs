namespace TeamcityTestingFramework.Api.Models
{
    public record Steps: BaseModel
    {
        public int Count { get; set; }
        public List<Step> Step { get; set; }
    }
}
