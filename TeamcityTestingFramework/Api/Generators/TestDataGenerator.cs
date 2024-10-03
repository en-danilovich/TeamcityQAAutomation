using NUnit.Framework.Interfaces;
using System.Collections;
using System.Reflection;
using TeamcityTestingFramework.Api.Attributes;
using TeamcityTestingFramework.Api.Models;
using RandomAttribute = TeamcityTestingFramework.Api.Attributes.RandomAttribute;

namespace TeamcityTestingFramework.Api.Generators
{
    public class TestDataGenerator
    {
        private TestDataGenerator() { }
                
        public static T Generate<T>(List<BaseModel> generatedModels, params object[] parameters) where T : BaseModel, new()
        {
            try
            {
                T instance = new T();
                var fields = typeof(T).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

                foreach (var field in fields)
                {
                    // Check if the field is marked as Optional
                    if (!field.IsDefined(typeof(OptionalAttribute), false))
                    {
                        var generatedClass = generatedModels.FirstOrDefault(m => m.GetType() == field.FieldType);

                        // If the field is marked as Parameterizable and parameters are provided
                        if (field.IsDefined(typeof(ParameterizableAttribute), false) && parameters.Length > 0)
                        {
                            field.SetValue(instance, parameters[0]);
                            parameters = parameters.Skip(1).ToArray();
                        }
                        // If the field is marked as Random and it's a string
                        else if (field.IsDefined(typeof(RandomAttribute), false) && field.FieldType == typeof(string))
                        {
                            field.SetValue(instance, RandomData.GetString());
                        }
                        // If the field is a subclass of BaseModel
                        else if (typeof(BaseModel).IsAssignableFrom(field.FieldType))
                        {
                            object[] finalParameters = parameters;
                            field.SetValue(instance, generatedClass ?? Generate(field.FieldType, finalParameters));
                        }
                        // If the field is a List<BaseModel>
                        else if (typeof(IList).IsAssignableFrom(field.FieldType))
                        {
                            var listType = field.FieldType.GetGenericArguments()[0];
                            if (typeof(BaseModel).IsAssignableFrom(listType))
                            {
                                object[] finalParameters = parameters;

                                // workaround to create list with certain type inherited from BaseModel
                                var issue = Generate(listType, finalParameters);
                                Type listTypeG = typeof(List<>).MakeGenericType(issue.GetType());
                                IList listInstance = (IList)Activator.CreateInstance(listTypeG);
                                listInstance.Add(issue);

                                field.SetValue(instance, generatedClass != null ? new List<BaseModel> { generatedClass } : listInstance);
                            }
                        }
                    }
                }
                return instance;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Cannot generate test data", e);
            }
        }

        // Generate method to generate one entity (with empty generatedModels parameter)
        public static T Generate<T>(params object[] parameters) where T : BaseModel, new()
        {
            return Generate<T>(new List<BaseModel>(), parameters);
        }

        // Helper method to generate BaseModel object (for recursive calls)
        public static BaseModel Generate(Type modelType, object[] parameters)
        {
            var method = typeof(TestDataGenerator).GetMethod(nameof(Generate), BindingFlags.Static | BindingFlags.Public,
                null,
                new[] { typeof(List<BaseModel>), typeof(object[]) },
                null);
            var generic = method.MakeGenericMethod(modelType);
            return (BaseModel)generic.Invoke(null, new object[] { new List<BaseModel>(), parameters });
        }
    }
}
