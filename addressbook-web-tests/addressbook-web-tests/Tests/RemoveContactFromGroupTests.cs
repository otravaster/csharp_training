using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            app.Groups.CreateGroupIfNeeded(new GroupData("mz_group"));
            app.Contacts.CreateContactIfNeeded(new ContactData("mary", "barry"));

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldContactList = group.GetContacts();
            ContactData contact = ContactData.GetAll().First();

            if (oldContactList.Count == 0)
            {
                app.Contacts.AddContactToGroup(contact, group);
                oldContactList = group.GetContacts();
            }

            app.Contacts.RemoveContactFromGroup(contact, group);
            
            List<ContactData> newContactList = group.GetContacts();
            oldContactList.Remove(contact);
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);
        }
    }
}
