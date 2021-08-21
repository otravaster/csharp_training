using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newGroup = new GroupData("mz") {
                Header = "mz_header",
                Footer = "mz_footer"
            };

            GroupData modifiedGroup = new GroupData("mz_upd") {
                Header = null,
                Footer = null
            };

            //check if Group exists and if false - then create a group
            app.Groups.CreateGroupIfNeeded(newGroup);

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModified = oldGroups[0];

            app.Groups.Modify(toBeModified, modifiedGroup);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            toBeModified.Name = modifiedGroup.Name;
            //oldGroups.Sort();
            //newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModified.Id)
                {
                    Assert.AreEqual(modifiedGroup.Name, group.Name);
                }
            }
        }
    }
}
