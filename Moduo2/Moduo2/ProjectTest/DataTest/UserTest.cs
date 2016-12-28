using Common;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectTest.DataTest.UserTest
{
    [TestFixture]
    public class UserTest
    {
         #region Declarations

        private User user;
        private string username = "flasica";
        private string password = "123";
        private string email = "flasica123";
        private bool loggedIn = false;
        private double workTimeStart = 15;
        private double workTimeEnd = 19;
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

       /* [Test]
        public void ConstructorTest()
        {
            Assert.DoesNotThrow(() => new User());
        }*/

        [Test]
        public void UserConstructorTestBezParametra()
        {
            Assert.DoesNotThrow(() => new User());
        }

        [Test]
        public void UserConstructorTestSaParametrima()
        {
            int id = 1;
            Assert.DoesNotThrow(() => new User(id, username, password, email, workTimeStart, workTimeEnd,role));
        }

        [Test]
        public void UserIdTest()
        {
            int id = 1;
            user.Id = id;

            Assert.AreEqual(id, user.Id);
        }

        [Test]
        public void UserUsername()
        {
            user.Username = username;

            Assert.AreEqual(username, user.Username);
        }

        [Test]
        public void UserPassword()
        {
            user.Password = password;

            Assert.AreEqual(password, user.Password);
        }


        [Test]
        public void UserEmail()
        {
            user.Email = email;

            Assert.AreEqual(email, user.Email);
        }

        [Test]
        public void UserLoggedIn()
        {
            user.LoggedIn = loggedIn;

            Assert.AreEqual(loggedIn, user.LoggedIn);
        }
   
        [Test]
        public void UserWorkTimeStart()
        {
            user.WorkTimeStart = workTimeStart;

            Assert.AreEqual(workTimeStart, user.WorkTimeStart);
        }

        [Test]
        public void UserWorkTimeEnd()
        {
            user.WorkTimeEnd = workTimeStart;

            Assert.AreEqual(workTimeStart, user.WorkTimeEnd);
        }

        [Test]
        public void UserRole()
        {
            user.Role = role;

            Assert.AreEqual(role, user.Role);
        }

    }
 }

