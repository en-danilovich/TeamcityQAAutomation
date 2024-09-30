namespace TeamcityTestingFramework.Api.Models
{
    public record Steps: BaseModel
    {
        public int count { get; set; }
        public List<Step> step { get; set; }
    }
}
