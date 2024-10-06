using TeamcityTestingFramework.Api.Models;

namespace TeamcityTestingFramework.Api.Requests
{
    public interface IBuildQueueOperations<T>
    {
        T StartBuild(BaseModel model);
    }
}
