using TeamcityTestingFramework.Api.Enums;
using TeamcityTestingFramework.Api.Generators;
using TeamcityTestingFramework.Api.Matchers;
using TeamcityTestingFramework.Api.Models;
using TeamcityTestingFramework.Api.Requests;
using TeamcityTestingFramework.Api.Requests.Unchecked;
using TeamcityTestingFramework.Api.Spec;

namespace TeamcityTestingFramework.Tests.Api
{
    [Category("Regression")]
    public class BuildTypeTests: BaseApiTest
    {
        [Test(Description = "User should be able to create build type")]
        [Category("Positive")]
        [Category("CRUD")]
        public void UserCreatesBuildType()
        {
            var userCheckRequests = new CheckedRequests(Specifications.AuthSpec(TestData.User));                        
            superUserCheckRequests.GetRequest<User>(Endpoint.USERS).Create(TestData.User);

            userCheckRequests.GetRequest<Project>(Endpoint.PROJECTS).Create(TestData.Project);
           
            userCheckRequests.GetRequest<BuildType>(Endpoint.BUILD_TYPES).Create(TestData.BuildType);

            var createdBuildType = userCheckRequests.GetRequest<BuildType>(Endpoint.BUILD_TYPES).Read(TestData.BuildType.id);

            softy.Assert(() => Assert.That(createdBuildType.name, Is.EqualTo(TestData.BuildType.name), "Build type name is not correct"));
        }

        [Test(Description = "User should not be able to create two build types with the same id")]
        [Category("Negative")]
        [Category("CRUD")]
        public void UserCreatesTwoBuildTypesWithTheSameId()
        {
            var userCheckRequests = new CheckedRequests(Specifications.AuthSpec(TestData.User));
            superUserCheckRequests.GetRequest<User>(Endpoint.USERS).Create(TestData.User);

            userCheckRequests.GetRequest<Project>(Endpoint.PROJECTS).Create(TestData.Project);
            
            var buildTypeWithSameId = TestDataGenerator.Generate<BuildType>(new List<BaseModel> { TestData.Project }, TestData.BuildType.id);

            userCheckRequests.GetRequest<BuildType>(Endpoint.BUILD_TYPES).Create(TestData.BuildType);
            new UncheckedBase(Specifications.AuthSpec(TestData.User), Endpoint.BUILD_TYPES)
                .Create(buildTypeWithSameId)
                .Then().AssertThat().StatusCode(System.Net.HttpStatusCode.BadRequest)
                .Body(new ContainsStringMatcher($"The build configuration / template ID \"{TestData.BuildType.id}\" is already used by another configuration or template"));
        }

        [Test(Description = "Project admin should be able to create build type for their project")]
        [Category("Positive")]
        [Category("Roles")]
        public void ProjectAdminCreatesBuildType()
        {
            // create user1
            // create project1
            // grant user1 PROJECT_ADMIN role in project1            
            // create buildType for project by user1            
            // check build type was created successfully
        }

        [Test(Description = "Project admin should not be able to create build type for not their project")]
        [Category("Negative")]
        [Category("Roles")]
        public void ProjectAdminCreatesBuildTypeForAnotherUserProject()
        {
            // create user1
            // create project1
            // grant user1 PROJECT_ADMIN role in project1

            // create user2
            // create project2
            // grant user2 PROJECT_ADMIN role in project2
                        
            // create buildType for project1 by user2            
            // check buildType was not created with forbidden code
        }
    }
}
