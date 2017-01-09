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
        private string name = "name";
        private string prezime = "prz";
        private string username = "flasica";
        private string password = "123";
        private string email = "flasica123";
        private bool loggedIn = false;
        private int workTimeStarthour = 15;
        private int workTimeStartMin = 44;
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
            
            Assert.DoesNotThrow(() => new User(username, password, email, workTimeStarthour, workTimeStartMin, workTimeEnd,role));
        }

        [Test]
        public void Name()
        {
         
            user.Name = name;

            Assert.AreEqual(name, user.Name);
        }


        [Test]
        public void Prezime()
        {

            user.LastName = prezime;

            Assert.AreEqual(prezime, user.LastName);
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
            user.WorkTimeStartHour = workTimeStarthour;

            Assert.AreEqual(workTimeStarthour, user.WorkTimeStartHour);
        }
        [Test]
        public void UserWorkTimeStartMin()
        {
            user.WorkTimeStartMin = workTimeStartMin;

            Assert.AreEqual(workTimeStartMin, user.WorkTimeStartMin);
        }

        [Test]
        public void UserWorkTimeEnd()
        {
            user.WorkTimeEnd = workTimeEnd;

            Assert.AreEqual(workTimeEnd, user.WorkTimeEnd);
        }

        [Test]
        public void UserRole()
        {
            user.Role = role;

            Assert.AreEqual(role, user.Role);
        }

    }
 }

