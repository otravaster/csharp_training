using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("mz_upd");
            newData.Header = "mz_upd_header";
            newData.Footer = "mz_upd_footer";

            app.Groups.Modify(1, newData);
        }
    }
}
