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
            var buildTypeWithSameId = TestDataGenerator.Generate<BuildType>(new List<BaseModel> { TestData.Project }, TestData.BuildType.id);

            var userCheckRequests = new CheckedRequests(Specifications.AuthSpec(TestData.User));
            superUserCheckRequests.GetRequest<User>(Endpoint.USERS).Create(TestData.User);

            userCheckRequests.GetRequest<Project>(Endpoint.PROJECTS).Create(TestData.Project);

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
            superUserCheckRequests.GetRequest<Project>(Endpoint.PROJECTS).Create(TestData.Project);
            
            TestData.User.roles.role = [new Role() { roleId = "PROJECT_ADMIN", scope = $"p:{TestData.Project.id}" }];
            superUserCheckRequests.GetRequest<User>(Endpoint.USERS).Create(TestData.User);

            var userCheckRequests = new CheckedRequests(Specifications.AuthSpec(TestData.User));

            userCheckRequests.GetRequest<BuildType>(Endpoint.BUILD_TYPES).Create(TestData.BuildType);
            var createdBuildType = userCheckRequests.GetRequest<BuildType>(Endpoint.BUILD_TYPES).Read(TestData.BuildType.id);

            softy.Assert(() => Assert.That(createdBuildType.name, Is.EqualTo(TestData.BuildType.name), "Build type name is not correct"));
        }

        [Test(Description = "Project admin should not be able to create build type for not their project")]
        [Category("Negative")]
        [Category("Roles")]
        public void ProjectAdminCreatesBuildTypeForAnotherUserProject()
        {
            // create user1 with PROJECT_ADMIN role in project1
            superUserCheckRequests.GetRequest<Project>(Endpoint.PROJECTS).Create(TestData.Project);
            TestData.User.roles.role = [new Role() { roleId = "PROJECT_ADMIN", scope = $"p:{TestData.Project.id}" }];
            superUserCheckRequests.GetRequest<User>(Endpoint.USERS).Create(TestData.User);

            // create user2 with PROJECT_ADMIN role in project2
            var secondProject = TestDataGenerator.Generate<Project>();            
            var secondUser = TestDataGenerator.Generate<User>(new Roles { role = [new Role() { roleId = "PROJECT_ADMIN", scope = $"p:{secondProject.id}" }]});
            superUserCheckRequests.GetRequest<Project>(Endpoint.PROJECTS).Create(secondProject);
            superUserCheckRequests.GetRequest<User>(Endpoint.USERS).Create(secondUser);

            // create buildType for project1 by user2
            // check buildType was not created with forbidden code
            var buildTypeOfProject1 = TestData.BuildType;
            var secondUserUncheckRequests = new UncheckedRequests(Specifications.AuthSpec(secondUser));
            secondUserUncheckRequests.GetRequest(Endpoint.BUILD_TYPES).Create(buildTypeOfProject1)
                .Then().AssertThat().StatusCode(System.Net.HttpStatusCode.Forbidden)
                .Body(new ContainsStringMatcher($"You do not have enough permissions to edit project with id: {TestData.Project.id}"));
        }
    }
}
