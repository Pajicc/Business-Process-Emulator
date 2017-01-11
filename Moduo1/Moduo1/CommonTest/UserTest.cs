using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest
{
    [TestFixture]
    public class UserTest
    {
        #region Declarations

        private User user;
        private string username = "username";
        private string password = "password";
        private string passeditime = "01/01/2001 12:12:12";
        private string name = "name";
        private string lastName = "lastname";
        private string email = "email@email.com";
        private bool loggedIn = false;
        private string workTimeStart = "01/01/2001 12:12:12";
        private string workTimeEnd = "01/01/2001 12:12:12";
        private Roles role = 0;

        #endregion Declarations

        #region setup

        [OneTimeSetUp]
        //[TestFixtureSetUp]
        public void SetupTest()
        {
            this.user = new User();
        }

        #endregion setup

        #region tests

        [Test]
        public void UserConstructorTestWithoutParameters()
        {
            Assert.DoesNotThrow(() => new User());
        }

        [Test]
        public void UserConstructorTestWithParameters()
        {      
            Assert.DoesNotThrow(() => new User(username, password, email, workTimeStart, workTimeEnd, role));
        }

        [Test]
        public void UserConstructorTestWithAllParameters()
        {
            Assert.DoesNotThrow(() => new User(username, password, passeditime, name, lastName, email, loggedIn, workTimeStart, workTimeEnd, role));
        }

        [Test]
        public void Username()
        {       
            user.Username = username;

            Assert.AreEqual(username, user.Username);
        }

        [Test]
        public void Password()
        {
            user.Password = password;

            Assert.AreEqual(password, user.Password);
        }

        [Test]
        public void PassedTime()
        {
            user.Passeditime = passeditime;

            Assert.AreEqual(passeditime, user.Passeditime);
        }

        [Test]
        public void Name()
        {
            user.Name = name;

            Assert.AreEqual(name, user.Name);
        }

        [Test]
        public void LastName()
        {
            user.LastName = lastName;

            Assert.AreEqual(lastName, user.LastName);
        }

        [Test]
        public void Email()
        {
            user.Email = email;

            Assert.AreEqual(email, user.Email);
        }

        [Test]
        public void LoggedIn()
        {
            user.LoggedIn = loggedIn;

            Assert.AreEqual(loggedIn, user.LoggedIn);
        }


        [Test]
        public void WorkTimeStart()
        {
            user.WorkTimeStart = workTimeStart;

            Assert.AreEqual(workTimeStart, user.WorkTimeStart);
        }

        [Test]
        public void WorkTimeEnd()
        {
            user.WorkTimeEnd = workTimeEnd;

            Assert.AreEqual(workTimeEnd, user.WorkTimeEnd);
        }
        #endregion tests
    }
}

     