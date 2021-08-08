using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDetailsTests : AuthTestBase
    {

        [Test]
        public void ContactDetailsTest()
        {
            string detailsFromViewForm = app.Contacts.GetContactDetailsFromViewForm(0);
            ContactData fromEditForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(detailsFromViewForm, fromEditForm.AllDetails);
        }
    }
}
