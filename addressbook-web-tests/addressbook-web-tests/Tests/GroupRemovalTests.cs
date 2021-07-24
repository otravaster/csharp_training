using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("mz");
            group.Header = "mz_header";
            group.Footer = "mz_footer";

            //check if Group exists and if false - then create a group
            app.Groups.CreateGroupIfNeeded(group);

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
