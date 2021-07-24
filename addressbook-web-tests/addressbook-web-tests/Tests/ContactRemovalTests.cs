using NUnit.Framework;

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

            app.Contacts.Remove(2);
        }
    }
}
