namespace TeamcityTestingFramework.Api.Models
{
    public class Steps : BaseModel
    {
        public int count { get; set; }
        public List<Step> step { get; set; }
    }
}
