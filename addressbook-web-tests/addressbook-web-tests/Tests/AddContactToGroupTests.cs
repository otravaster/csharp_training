using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class AddContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            app.Groups.CreateGroupIfNeeded(new GroupData("mz_group"));
            app.Contacts.CreateContactIfNeeded(new ContactData("Mary", "Barry"));

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldContactList = group.GetContacts();
            List<ContactData> allContacts = ContactData.GetAll();

            if (allContacts.Count == oldContactList.Count)
            {
                app.Contacts.Create(new ContactData("Test", "MZ"));
            }

            ContactData contact = ContactData.GetAll().Except(oldContactList).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newContactList = group.GetContacts();
            oldContactList.Add(contact);
            oldContactList.Sort();
            newContactList.Sort();
            
            Assert.AreEqual(oldContactList, newContactList);
        }
    }
}
