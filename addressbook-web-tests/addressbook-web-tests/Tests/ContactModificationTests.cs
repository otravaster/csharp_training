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

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Modify(2, modifiedContact);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = modifiedContact.Firstname;
            oldContacts[0].Lastname = modifiedContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
