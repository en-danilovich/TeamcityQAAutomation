namespace TeamcityTestingFramework.Tests.UI
{
    [Category("Regression")]
    public class CreateProjectTests : BaseUITest
    {
        [Test(Description = "User should be able to create project")]
        [Category("Positive")]        
        public void UserCreatesProject()
        {
            // Login as user

            // Open 'Create Project Page' http://localhost:8111/admin/createObjectMenu.html
            // Send all project parameters (repository URL)
            // Click Proceed
            // Fix Project Name and Build Type name values
            // Click Proceed

            // Check that all entities (project, buildType) were sucessfully created with correct data on API level

            // Check that project is visible on Projects Page http://localhost:8111/favorite/projects
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
