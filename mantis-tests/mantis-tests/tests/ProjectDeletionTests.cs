using NUnit.Framework;
using System.Collections.Generic;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectDeletionTests : AuthTestBase
    {
        [Test]
        public void ProjectDeletionTest()
        {
            app.ProjectManagement.CreateProjectIfNeeded(new ProjectData(GetRandomString(10))
            {
                Description = GetRandomString(15),
            });
            List<ProjectData> oldProjects = app.ProjectManagement.GetProjectsList();
            app.ProjectManagement.Delete(0);
            List<ProjectData> newProjects = app.ProjectManagement.GetProjectsList();
            oldProjects.RemoveAt(0);

            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
