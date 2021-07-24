using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData group = new GroupData("mz");
            group.Header = "mz_header";
            group.Footer = "mz_footer";

            GroupData modifiedGroup = new GroupData("mz_upd");
            modifiedGroup.Header = null;
            modifiedGroup.Footer = null;

            //check if Group exists and if false - then create a group
            app.Groups.CreateGroupIfNeeded(group);

            app.Groups.Modify(0, modifiedGroup);
        }
    }
}
