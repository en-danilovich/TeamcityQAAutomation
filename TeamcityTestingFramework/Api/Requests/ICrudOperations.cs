using TeamcityTestingFramework.Api.Models;

namespace TeamcityTestingFramework.Api.Requests
{
    public interface ICrudOperations<T, N>
    {
        T Create(BaseModel model);
        T Read(string id);
        T Update(string id, BaseModel model);
        N Delete(string id);
    }
}
