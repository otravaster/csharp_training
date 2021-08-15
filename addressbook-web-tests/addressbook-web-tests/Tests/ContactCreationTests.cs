using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 10; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(5), GenerateRandomString(10)));
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            //ContactData contact = new ContactData("Maria", "Zavgor");
            //contact.Address = "Saint-Petersburg Nevskiy prospect 32";
            //contact.HomePhone = "+71234567890";
            //contact.MobilePhone = "+71234567895";
            //contact.WorkPhone = "+71234567899";
            //contact.Email = "a@b.c";
            //contact.Email2 = "a2@b.c";
            //contact.Email3 = "a3@b.c";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
