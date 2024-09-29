using TeamcityTestingFramework.Api.Models;

namespace TeamcityTestingFramework.Api.Requests
{
    public interface CrudInterface
    {
        Object Create(BaseModel model);
        Object Read(string id);
        Object Update(string id, BaseModel model);
        Object Delete(string id);
    }
}
