namespace TeamcityTestingFramework.Exceptions
{
    public class StopRetryException : Exception
    {
        public StopRetryException() : base() { }

        public StopRetryException(string message) : base("Retry terminated. " + message) { }
    }
}
