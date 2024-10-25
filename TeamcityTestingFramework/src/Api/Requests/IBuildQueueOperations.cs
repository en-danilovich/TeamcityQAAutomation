using TeamcityTestingFramework.src.Api.Models;

namespace TeamcityTestingFramework.src.Api.Requests
{
    public interface IBuildQueueOperations<T>
    {
        T StartBuild(BaseModel model);
    }
}
