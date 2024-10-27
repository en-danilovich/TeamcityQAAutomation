using Microsoft.Playwright;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Models;
using TeamcityTestingFramework.src.UI.Pages;
using TeamcityTestingFramework.src.UI.Pages.Admin;

namespace TeamcityTestingFramework.Tests.UI
{
    [Category("Regression")]
    public class CreateProjectTests : BaseUITest
    {
        private static readonly string REPO_URL = "https://github.com/en-danilovich/enotes-automation";

        [Test(Description = "User should be able to create project")]
        [Category("Positive"), Category("Example")]
        public async Task UserCreatesProject()
        {
            // подготовка окружения            
            await LoginAsAsync(TestData.User);

            // взаимодействие с UI
            var createProjectPage = new CreateProjectPage(Page);
            await createProjectPage.NavigateAsync();
            await createProjectPage.CreateForm(REPO_URL);
            await createProjectPage.SetupProjectAsync(TestData.Project.name, TestData.BuildType.name);

            var createdProject = superUserCheckRequests.GetRequest<Project>(Endpoint.PROJECTS).Read($"name:{TestData.Project.name}");
            softy.Assert(() => Assert.That(createdProject, Is.Not.Null, $"Project with name {TestData.Project.name} was not found"));

            // Check that project is visible on Projects Page http://localhost:8111/favorite/projects
            var projectPage = new ProjectPage(Page, createdProject.id);
            await projectPage.NavigateAsync();
            await Assertions.Expect(projectPage._projectTitle).ToHaveTextAsync(TestData.Project.name);

            var projectsPage = new ProjectsPage(Page);
            await projectsPage.NavigateAsync();
            var projects = await projectsPage.GetProjectsAsync();
            var tasks = projects.Select(async project =>
            {
                var nameText = await project.Name.TextContentAsync();
                return (project, nameText);
            });
            var results = await Task.WhenAll(tasks);
            var filteredProjects = results.Where(result => result.nameText == TestData.Project.name).ToList();
            softy.Assert(() => Assert.That(filteredProjects.Count(), Is.EqualTo(1)));
        }

        [Test(Description = "User should not be able to create project without name")]
        [Category("Negative")]
        public void UserCreatesProjectWithoutName()
        {
            // Login as user 
            // Check number of projects

            // Open 'Create Project Page' http://localhost:8111/admin/createObjectMenu.html
            // Send all project parameters (repository URL)
            // Click Proceed
            // Set Project Name value is empty
            // Click Proceed

            // Check that number of projects did not change"

            // Check that error appears 'Project name must not be empty'
        }
    }
}
