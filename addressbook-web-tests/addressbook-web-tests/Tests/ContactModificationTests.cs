using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContact = new ContactData("Maria", "Zavgor");
            ContactData modifiedContact = new ContactData("Marianna", "Kolom");
            
            //check if Contact exists and if false - then create a Contact
            app.Contacts.CreateContactIfNeeded(newContact);

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModified = oldContacts[0];

            app.Contacts.Modify(toBeModified, modifiedContact);
            
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            toBeModified.Firstname = modifiedContact.Firstname;
            toBeModified.Lastname = modifiedContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeModified.Id)
                {
                    Assert.AreEqual(modifiedContact.Firstname, contact.Firstname);
                    Assert.AreEqual(modifiedContact.Lastname, contact.Lastname);
                }
            }
        }
    }
}
