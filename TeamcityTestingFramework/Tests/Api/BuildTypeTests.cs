﻿using Allure.Net.Commons;
using Allure.NUnit;
using TeamcityTestingFramework.Api.Enums;
using TeamcityTestingFramework.Api.Generators;
using TeamcityTestingFramework.Api.Models;
using TeamcityTestingFramework.Api.Requests.Checked;
using TeamcityTestingFramework.Api.Spec;

namespace TeamcityTestingFramework.Tests.Api
{
    [Category("Regression")]
    public class BuildTypeTests: BaseApiTest
    {
        //[Test(Description = "User should be able to create build type")]
        [Test]
        [Description("User should be able to create build type")]
        [Category("Positive")]
        [Category("CRUD")]
        public void UserCreatesBuildType()
        {
            AllureApi.Step("Create user", () =>
            {
                var user = TestDataGenerator.Generate<User>();

                var requester = new CheckedBase<User>(Specifications.SuperUserAuth(), Endpoint.USERS);
                requester.Create(user);
            });

            // create user
            // create project by user
            // create buildType for project by user
            // check build type was created successfully with correct data           
        }

        [Test(Description = "User should not be able to create two build types with the same id")]
        [Category("Negative")]
        [Category("CRUD")]
        public void UserCreatesTwoBuildTypesWithTheSameId()
        {
            // create user
            // create project by user
            // create buildType1 for project by user
            // create buildType2 with same id as buildType1 for project by user
            // check buildType2 was not created with bad request code
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
