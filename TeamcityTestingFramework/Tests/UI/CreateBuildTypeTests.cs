using Microsoft.Playwright;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Models;
using TeamcityTestingFramework.src.UI.Pages;
using TeamcityTestingFramework.src.UI.Pages.Admin;
using TeamcityTestingFramework.src.UI.Elements;
using TeamcityTestingFramework.src.Api.Requests.Unchecked;
using TeamcityTestingFramework.src.Api.Spec;
using TeamcityTestingFramework.src.Constants;

namespace TeamcityTestingFramework.Tests.UI
{
    [Category("Regression"), Category("UI1")]
    public class CreateBuildTypeTests : BaseUITest
    {
        private static readonly string REPO_URL = "https://github.com/en-danilovich/enotes-automation";

        [Test(Description = "User should be able to create build type")]
        [Category("Positive")]
        public async Task UserCreatesBuildType()
        {
            // prepare data           
            superUserCheckRequests.GetRequest<Project>(Endpoint.PROJECTS).Create(TestData.Project);
            await LoginAsAsync(TestData.User);

            // ui steps
            var createBuildTypePage = new CreateBuildTypePage(Page);
            await createBuildTypePage.NavigateAsync(TestData.Project.id);
            await createBuildTypePage.CreateFormAsync(REPO_URL);
            var buildTypeDetailsPage = await createBuildTypePage.SetupBuildTypeAsync(TestData.BuildType.name);

            // verify build type created on api level
            var createdBuildType = await Task.Run(() => superUserCheckRequests.GetRequest<BuildType>(Endpoint.BUILD_TYPES).Read($"name:{TestData.BuildType.name}"));
            softy.Assert(() => 
                Assert.That(createdBuildType, Is.Not.Null, $"BuildType with name {TestData.BuildType.name} was not found"));

            // verify build type details page and success massage
            softy.Assert(() =>
                buildTypeDetailsPage.VerifyBuildTypeCreatedAsync(TestData.BuildType.name, REPO_URL + "#refs/heads/main").GetAwaiter().GetResult());

            // Check that build type is visible on Projects Page http://localhost:8111/favorite/projects
            var projectsPage = new ProjectsPage(Page);
            await projectsPage.NavigateAsync();
            var project = (await projectsPage.GetProjectsAsync()).FindProjectWithName(TestData.Project.name);
            await project.ShowSubprojectsArrow.ClickAsync();
            softy.Assert(async() => await Assertions.Expect(project.SubprojectBuildTypesLocator).ToHaveCountAsync(1));            

            var projectBuildTypes = await project.GetSubprojectBuildTypes();
            softy.Assert(async () => 
                await Assertions.Expect(projectBuildTypes.First().BuildTypeButton).ToHaveAttributeAsync("aria-label", TestData.BuildType.name));
        }

        [Test(Description = "User should not be able to create build type without name")]
        [Category("Negative")]
        public async Task UserCreatesBuildTypeWithoutName()
        {
            await Page.WaitForTimeoutAsync(10000);

            // prepare data           
            superUserCheckRequests.GetRequest<Project>(Endpoint.PROJECTS).Create(TestData.Project);
            await LoginAsAsync(TestData.User);

            // ui steps
            var createBuildTypePage = new CreateBuildTypePage(Page);
            await createBuildTypePage.NavigateAsync(TestData.Project.id);
            await createBuildTypePage.CreateFormAsync(REPO_URL);

            await createBuildTypePage.BuildTypeInput.ClearAsync();
            await createBuildTypePage.SubmitButton.ClickAsync();
            softy.Assert(() =>
            {
                Assertions.Expect(createBuildTypePage.BuildTypeNameError).ToBeVisibleAsync().GetAwaiter().GetResult();
                Assertions.Expect(createBuildTypePage.BuildTypeNameError).ToHaveTextAsync(ValidationErrors.BuildNameMustNotBeEmpty).GetAwaiter().GetResult();
            });

            // verify build type was not created on api level
            new UncheckedBase(Specifications.SuperUserAuthSpec(), Endpoint.BUILD_TYPES)
                .Read($"name:{TestData.BuildType.name}")
                .Then().AssertThat().StatusCode(System.Net.HttpStatusCode.NotFound);

            // Check that build type is not visible on Projects Page http://localhost:8111/favorite/projects
            var projectsPage = new ProjectsPage(Page);
            await projectsPage.NavigateAsync();
            var project = (await projectsPage.GetProjectsAsync()).FindProjectWithName(TestData.Project.name);            
            Assert.Multiple(async () =>
            {
                await Assertions.Expect(project.ShowSubprojectsArrow).ToBeHiddenAsync();
                await Assertions.Expect(project.SubprojectBuildTypesLocator).ToHaveCountAsync(0);
            });
        }
    }
}