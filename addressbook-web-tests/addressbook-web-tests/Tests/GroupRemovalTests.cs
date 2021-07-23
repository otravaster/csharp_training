using NUnit.Framework;

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

            app.Groups.Remove(1, group);
        }
    }
}
