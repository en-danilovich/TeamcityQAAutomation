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
            var testData = TestDataGenerator.Generate();

            var userCheckRequests = new CheckedRequests(Specifications.AuthSpec(testData.User));                        
            superUserCheckRequests.GetRequest<User>(Endpoint.USERS).Create(testData.User);

            userCheckRequests.GetRequest<Project>(Endpoint.PROJECTS).Create(testData.Project);
           
            userCheckRequests.GetRequest<BuildType>(Endpoint.BUILD_TYPES).Create(testData.BuildType);

            var createdBuildType = userCheckRequests.GetRequest<BuildType>(Endpoint.BUILD_TYPES).Read(testData.BuildType.id);

            softy.Assert(() => Assert.That(createdBuildType.name, Is.EqualTo(testData.BuildType.name), "Build type name is not correct"));
        }

        [Test(Description = "User should not be able to create two build types with the same id")]
        [Category("Negative")]
        [Category("CRUD")]
        public void UserCreatesTwoBuildTypesWithTheSameId()
        {
            var user = TestDataGenerator.Generate<User>();

            var userCheckRequests = new CheckedRequests(Specifications.AuthSpec(user));
            superUserCheckRequests.GetRequest<User>(Endpoint.USERS).Create(user);

            var project = TestDataGenerator.Generate<Project>();
            project = userCheckRequests.GetRequest<Project>(Endpoint.PROJECTS).Create(project);

            var buildType1 = TestDataGenerator.Generate<BuildType>(new List<BaseModel> { project });
            var buildType2 = TestDataGenerator.Generate<BuildType>(new List<BaseModel> { project }, buildType1.id);

            userCheckRequests.GetRequest<BuildType>(Endpoint.BUILD_TYPES).Create(buildType1);
            new UncheckedBase(Specifications.AuthSpec(user), Endpoint.BUILD_TYPES)
                .Create(buildType2)
                .Then().AssertThat().StatusCode(System.Net.HttpStatusCode.BadRequest)
                .Body(new ContainsStringMatcher($"The build configuration / template ID \"{buildType1.id}\" is already used by another configuration or template"));
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
