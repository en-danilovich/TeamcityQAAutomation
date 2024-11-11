using System.Collections.Concurrent;
using System.Reflection;
using TeamcityTestingFramework.src.Api.Requests.Unchecked;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Models;
using TeamcityTestingFramework.src.Api.Spec;

namespace TeamcityTestingFramework.src.Api.Generators
{
    public class TestDataStorage
    {
        private static TestDataStorage _instance;
        private ConcurrentDictionary<Endpoint, HashSet<string>> createdEntitiesDict;

        private TestDataStorage()
        {
            createdEntitiesDict = new ConcurrentDictionary<Endpoint, HashSet<string>>();
        }

        public static TestDataStorage GetInstance()
        {
            _instance ??= new TestDataStorage();
            return _instance;
        }

        public void AddCreatedEntity(Endpoint endpoint, BaseModel model)
        {
            AddCreatedEntity(endpoint, GetEntityIdOrLocator(model));
        }

        public void DeleteCreatedEntities()
        {
            foreach (var (endpoint, ids) in createdEntitiesDict)
            {
                foreach (var id in ids)
                {
                    new UncheckedBase(Specifications.SuperUserAuthSpec(), endpoint).Delete($"id:{id}");
                }
            }

            createdEntitiesDict.Clear();
        }

        private void AddCreatedEntity(Endpoint endpoint, string id)
        {
            createdEntitiesDict.AddOrUpdate(endpoint,
                [id],
                (key, existingSet) =>
                {
                    existingSet.Add(id);
                    return existingSet;
                });
        }


        private string GetEntityIdOrLocator(BaseModel model)
        {
            try
            {
                var idField = model.GetType().GetField("id", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                if (idField != null)
                {
                    return idField.GetValue(model)?.ToString();
                }
            }
            catch (Exception)
            {
                // Игнорируем исключение, продолжаем проверять другое поле
            }

            try
            {
                var locatorField = model.GetType().GetField("locator", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                if (locatorField != null)
                {
                    return locatorField.GetValue(model)?.ToString();
                }
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Cannot get id or locator of entity");
            }

            throw new InvalidOperationException("Neither id nor locator found on entity");
        }
    }
}
