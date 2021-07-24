using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("Maria", "Zavgor");
            
            //check if Contact exists and if false - then create a Contact
            app.Contacts.CreateContactIfNeeded(contact);

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(2);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
