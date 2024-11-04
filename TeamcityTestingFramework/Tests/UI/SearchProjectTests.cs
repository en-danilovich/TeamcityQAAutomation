using Microsoft.Playwright;
using TeamcityTestingFramework.src.Api.Enums;
using TeamcityTestingFramework.src.Api.Models;
using TeamcityTestingFramework.src.UI.Pages;

namespace TeamcityTestingFramework.Tests.UI
{
    [Category("Regression"), Category("UI")]
    public class SearchProjectTests : BaseUITest
    {
        [Test(Description = "User should be able search project by full name")]
        [Category("Positive")]
        public async Task UserSearchesProjectByFullName()
        {
            // prepare data
            superUserCheckRequests.GetRequest<Project>(Endpoint.PROJECTS).Create(TestData.Project);
            await LoginAsAsync(TestData.User);

            // ui steps
            var projectsPage = new ProjectsPage(Page);
            await projectsPage.NavigateAsync();
            await projectsPage.SearchProject(TestData.Project.name);

            softy.Assert(() => Assertions.Expect(projectsPage.ProjectsTreeItems).ToHaveCountAsync(1).GetAwaiter().GetResult());
            var treeProjects = await projectsPage.GetProjectsFromTreeAsync();
            var projectFound = treeProjects.First();
            softy.Assert(() => Assertions.Expect(projectFound.Name).ToHaveTextAsync(TestData.Project.name).GetAwaiter().GetResult());

            await projectFound.Name.PressAsync("Enter");
            var projectPage = new ProjectPage(Page, TestData.Project.id);
            await Assertions.Expect(projectPage._projectTitle).ToHaveTextAsync(TestData.Project.name);
        }
    }
}
