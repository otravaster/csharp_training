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
            ContactData contact = new ContactData("Maria", "Zavgor");
            ContactData modifiedContact = new ContactData("Marianna", "Kolom");

            //check if Contact exists and if false - then create a Contact
            app.Contacts.CreateContactIfNeeded(contact);

            app.Contacts.Modify(2, modifiedContact);
        }
    }
}
