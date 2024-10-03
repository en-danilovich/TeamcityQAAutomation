namespace TeamcityTestingFramework.Tests.Api
{
    public class SoftAssert
    {
        private readonly List<Exception> _exceptions = new List<Exception>();
                
        public void Assert(Action assertAction)
        {
            try
            {
                assertAction();
            }
            catch (Exception ex)
            {                
                _exceptions.Add(ex);
            }
        }
                
        public void AssertAll()
        {
            if (_exceptions.Count > 0)
            {
                throw new AggregateException(_exceptions);
            }
        }
    }
}
