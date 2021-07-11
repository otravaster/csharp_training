using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("Maria", "Zavgor");
            ContactData newData = new ContactData("Marianna", "Kolom");

            app.Contacts.Modify(contact, newData);
        }
    }
}
