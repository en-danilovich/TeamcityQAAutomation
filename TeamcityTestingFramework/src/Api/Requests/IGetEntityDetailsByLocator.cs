namespace TeamcityTestingFramework.src.Api.Requests
{
    public interface IGetEntityDetailsByLocator<T>
    {
        T GetDetails(string locator);
    }
}
