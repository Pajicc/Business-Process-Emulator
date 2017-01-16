using Common;
using NSubstitute;
using NUnit.Framework;
using SRV1.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV1Test.AccessTest
{
    [TestFixture]
    public class DBTest
    {
        private IDB idbTest;
        private DB dbTest;

        [OneTimeSetUp]
        public void SetupTest()
        {
            this.idbTest = DB.Instance;

           // DB.Instance = Substitute.For<IDB>();

            idbTest = Substitute.For<IDB>();

            idbTest.Login("user1", "pass1").Returns(true);
            idbTest.Login("user3", "pass3");
            idbTest.Login("user2", "pass2").Returns(false);

            //DB.Instance.Login("user1", "pass1").Returns(true);
            /* dbTest.LogOut("ceo1").Returns(true);
             dbTest.LogOut("ceo").Returns(false);*/

            //idbTest.AddUser(Arg.Is<User>(x => x.Username == "user1" && x.Password == "pass1")).Returns(true);

            /*dbTest.EditUser(Arg.Is<User>(x => x.Username == "user1" && x.Password == "pass1")).Returns(true);
            dbTest.EditUser(Arg.Is<User>(x => x.Username == "user2" && x.Password == "pass2")).Returns(false);

            dbTest.GetUser("user1").Returns(new User() { Username = "user" });

            dbTest.GetAllOnlineUsers().Returns(new List<User> { new User() { Username = "user1" }, new User() { Username = "user2" } });
            dbTest.GetAllEmployees().Returns(new List<User> { new User() { Username = "user1" } });
            dbTest.GetAllHiringCompanies().Returns(new List<string> { "hiringCompany1", "hiringCompany2" });
            dbTest.GetAllPartnerCompanies(Arg.Is<User>(x => x.Username == "user1")).Returns(new List<string> { "partner1", "partner2" });
            dbTest.GetAllProjects().Returns(new List<Project> { new Project() { Name = "Projekat1" } });
            dbTest.GetAllProjectsForUser(Arg.Is<User>(x => x.Username == "user1")).Returns(new List<Project> { new Project() { Name = "Projekat1" } });
            dbTest.GetAllUserStories(Arg.Is<Project>(x => x.Name == "Projekat1")).Returns(new List<string> { "Projekat1", "Projekat2" });

            dbTest.AddHiringCompany(Arg.Is<HiringCompany>(x => x.Name == "HiringCompany")).Returns(true);
            dbTest.AddHiringCompany(Arg.Is<HiringCompany>(x => x.Name == "company")).Returns(false);

            dbTest.AddPartnerCompany(Arg.Is<User>(x => x.Username == "user1"), "Kompanija1").Returns(true);
            dbTest.AddPartnerCompany(Arg.Is<User>(x => x.Username == "u"), "Komp").Returns(false);

            dbTest.AddUserStory("UserStory1", "criteria", "Projekat1").Returns(true);
            dbTest.AddUserStory("UserStory2", "criteria2", "project").Returns(false);
            dbTest.AddUserStory("UserStory3", "criteria3", "project").Returns(false);

            dbTest.UpdateProject(Arg.Is<Project>(x => x.Name == "Projekat1")).Returns(true);
            dbTest.UpdateProject(Arg.Is<Project>(x => x.Name == "Proj")).Returns(false);

            dbTest.CreateProject(Arg.Is<Project>(x => x.Name == "Projekat1")).Returns(true);
            dbTest.CreateProject(Arg.Is<Project>(x => x.Name == "Proj")).Returns(false);

            dbTest.ChangePass("ceo1", "ceo1", "c1").Returns(true);
            dbTest.ChangePass("ceo", "ceo", "c1").Returns(false);

            dbTest.UpdateProject2(Arg.Is<Procent>(x => x.ImeProj == "proj1" && x.Procenat == 1)).Returns(true);
            dbTest.UpdateProject2(Arg.Is<Procent>(x => x.ImeProj == "proj2" && x.Procenat == 2)).Returns(false);*/
        }


        [Test]
         [TestCase("user1", "user1")]
        [TestCase("user1", "pass1")]
        public void LoginTestLoggedIn(string username, string pass)
         {
             Assert.DoesNotThrow(() =>
             {
                 DB.Instance.Login(username, pass);
             });
         }

        [Test]
        public void LoginTestWrongPass()
        {
            bool result = DB.Instance.Login("user1", "pass1");
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("user1")]
        public void LogoutTestLoggedIn(string username )
        {
            Assert.DoesNotThrow(() =>
            {
                DB.Instance.LogOut(username);
            });
        }

        [Test]
        public void LogoutTestWrongPass()
        {
            bool result = DB.Instance.LogOut("user1");
            Assert.IsTrue(result);
        }

        [Test]
        public void GetAllEmployeesTest()
        {
            Assert.DoesNotThrow(() =>
            {
                DB.Instance.GetAllEmployees();
            });
        }
        [Test]
        public void GetAllHiringCompaniesTest()
        {
            Assert.DoesNotThrow(() =>
            {
                DB.Instance.GetAllHiringCompanies();
            });
        }
        [Test]
        public void GetAllOnlineUsersTest()
        {
            Assert.DoesNotThrow(() =>
            {
                DB.Instance.GetAllOnlineUsers();
            });
        }
       
        [Test]
        public void GetAllProjectsTest()
        {
            Assert.DoesNotThrow(() =>
            {
                DB.Instance.GetAllProjects();
            });
        }
        [Test]
        public void GetAllPartnerCompaniesTest()
        {
            User u = new User();
            u.Username = "user1";

            Assert.DoesNotThrow(() =>
            {
                DB.Instance.GetAllPartnerCompanies(u);
            });
        }

        [Test]
        public void GetAllUserStoriesTest()
        {
            Project u = new Project();
            u.Name = "projekat1";

            Assert.DoesNotThrow(() =>
            {
                DB.Instance.GetAllUserStories(u);
            });
        }
        [Test]
        public void GetAllProjectsForUserTest()
        {
            User u = new User();
            u.Username = "user1";

            Assert.DoesNotThrow(() =>
            {
                DB.Instance.GetAllProjectsForUser(u);
            });
        }
       
    }
}
