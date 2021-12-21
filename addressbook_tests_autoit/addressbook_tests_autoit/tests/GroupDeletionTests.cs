using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupDeletionTests : TestBase
    {
        [Test]
        public void TestGroupDeletion()
        {
            GroupData newGroup = new GroupData()
            {
                Name = "mztest"
            };

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            if (oldGroups == null)
            {
                app.Groups.Add(newGroup);
                oldGroups = app.Groups.GetGroupList();
            }

            GroupData toBeDeleted = oldGroups[0];
            
            app.Groups.Delete(toBeDeleted);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(toBeDeleted);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
