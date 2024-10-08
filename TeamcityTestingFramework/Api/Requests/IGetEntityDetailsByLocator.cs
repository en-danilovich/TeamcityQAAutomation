namespace TeamcityTestingFramework.Api.Requests
{
    public interface IGetEntityDetailsByLocator<T>
    {
        T GetDetails(string locator);
    }
}
