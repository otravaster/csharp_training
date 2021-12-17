//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;

//namespace mantis_tests
//{
//    [TestFixture]
//    public class AccountCreationTests : TestBase
//    {
//        [OneTimeSetUp]
//        public void SetUpConfig()
//        {
//            app.Ftp.BackupFile("config/config_inc.php");
//            using (Stream localFile = File.Open("/config/config_inc.php", FileMode.Open))
//            {
//                app.Ftp.Upload("/config/config_inc.php", localFile);
//            }
//        }
        
//        [Test]
//        public void TestAccountRegistration()
//        {
//            AccountData account = new AccountData() 
//            { 
//                Name = "testuser1",
//                Password = "password",
//                Email = "testuser1@localhost.localdomain"
//            };
            
//            app.James.Delete(account);
//            app.James.Add(account);

//            app.Registration.Register(account);
//        }

//        [OneTimeTearDown]
//        public void RestoreConfig()
//        {
//            app.Ftp.RestoreBackupFile("/config/config_inc.php");
//        }

//    }
//}
