using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("Marianna", "Kolom");
            ContactData modifiedContact = new ContactData("Marianna", "Kolom");

            app.Contacts.Modify(2, contact, modifiedContact);
        }
    }
}
