using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using NUnit.Framework;
using Client1;
using NSubstitute;
using System.ServiceModel;

namespace Client1Test
{
    [TestFixture]
    public class Client1ProxyTest
    {
        private Client1Proxy clientTest;

        [OneTimeSetUp]
        public void SetupTest()
        {
            clientTest = new Client1Proxy();
            clientTest.Factory = Substitute.For<ICompanyService>();

            clientTest.Factory.Login("ceo1", "ceo1").Returns(true);
            clientTest.Factory.Login("ceo", "ceo").Returns(false);
            clientTest.Factory.Login("exception", "exception").Returns((x) => { throw new Exception(); });

            clientTest.Factory.LogOut("ceo1").Returns(true);
            clientTest.Factory.LogOut("ceo").Returns(false);
            clientTest.Factory.LogOut("exception").Returns((x) => { throw new Exception(); });

            clientTest.Factory.AddUser(Arg.Is<User>(x => x.Username == "user1" && x.Password == "pass1")).Returns(true);
            clientTest.Factory.AddUser(Arg.Is<User>(x => x.Username == "user2" && x.Password == "pass2")).Returns(false);
            clientTest.Factory.AddUser(Arg.Is<User>(x => x.Username == "user3" && x.Password == "pass3")).Returns((x) => { throw new Exception(); });


            clientTest.Factory.EditUser(Arg.Is<User>(x => x.Username == "user1" && x.Password == "pass1")).Returns(true);
            clientTest.Factory.EditUser(Arg.Is<User>(x => x.Username == "user2" && x.Password == "pass2")).Returns(false);
            clientTest.Factory.EditUser(Arg.Is<User>(x => x.Username == "user3" && x.Password == "pass3")).Returns((x) => { throw new Exception(); });


            clientTest.Factory.GetUser("user1").Returns(new User() { Username = "user" });
            clientTest.Factory.GetUser("user2").Returns((x) => { throw new NullReferenceException(); });

            clientTest.Factory.GetAllOnlineUsers().Returns(new List<User> { new User() { Username = "user1" } });
            clientTest.Factory.GetAllEmployees().Returns(new List<User> { new User() { Username = "user1" }, new User() { Username = "user2" } });
            clientTest.Factory.GetAllPartnerCompanies(Arg.Is<User>(x => x.Username == "user1")).Returns(new List<string> { "partner1", "partner2" });
            clientTest.Factory.GetAllProjects().Returns(new List<Project> { new Project() { Name = "Projekat1" } });
            clientTest.Factory.GetAllProjectsForUser(Arg.Is<User>(x => x.Username == "user1")).Returns(new List<Project> { new Project() { Name = "Projekat1" } });
            clientTest.Factory.GetAllUserStories(Arg.Is<Project>(x => x.Name == "Projekat1")).Returns(new List<string> { "Projekat1", "Projekat2" });

            clientTest.Factory.AddPartnerCompany(Arg.Is<User>(x => x.Username == "user1"), "Kompanija1").Returns(true);
            clientTest.Factory.AddPartnerCompany(Arg.Is<User>(x => x.Username == "u"), "Komp").Returns(false);
            clientTest.Factory.AddPartnerCompany(Arg.Is<User>(x => x.Username == "u1"), "Komp1").Returns((x) => { throw new Exception(); });

            clientTest.Factory.UpdateProject(Arg.Is<Project>(x => x.Name == "Projekat1")).Returns(true);
            clientTest.Factory.UpdateProject(Arg.Is<Project>(x => x.Name == "Proj")).Returns(false);
            clientTest.Factory.UpdateProject(Arg.Is<Project>(x => x.Name == "Proj1")).Returns((x) => { throw new Exception(); });

            clientTest.Factory.CreateProject(Arg.Is<Project>(x => x.Name == "Projekat1")).Returns(true);
            clientTest.Factory.CreateProject(Arg.Is<Project>(x => x.Name == "Proj")).Returns(false);
            clientTest.Factory.CreateProject(Arg.Is<Project>(x => x.Name == "Proj1")).Returns((x) => { throw new Exception(); });

            clientTest.Factory.ChangePass("ceo1", "ceo1", "c1").Returns(true);
            clientTest.Factory.ChangePass("ceo", "ceo", "c1").Returns(false);
            clientTest.Factory.ChangePass("ceo1", "ceo1", "c11").Returns((x) => { throw new Exception(); });

        }

        [Test]
        public void Client1ProxyConstructorTestWithParamteres()
        {
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://10.1.212.121:9998/CommonService";
            Assert.DoesNotThrow(() => new Client1Proxy(binding, new EndpointAddress(new Uri(address))));
        }

        [Test]
        [TestCase("user1", "user1")]
        public void LoginTestOk(string username, string pass)
        {
            Assert.DoesNotThrow(() =>
            {
                clientTest.Login(username, pass);
            });
        }

        [Test]
        [TestCase("user1")]
        [TestCase("us")]
        public void GetUserOk(string username)
        {
            Assert.DoesNotThrow(() =>
            {
                clientTest.GetUser(username);
            });
        }
        [Test]
        public void GetUserTest()
        {
            User result = clientTest.GetUser("user1");
            string username = "user";
            Assert.AreEqual(result.Username, username);
        }

        [Test]
        public void GetUserTestException()
        {
            Assert.DoesNotThrow(() => clientTest.GetUser("user2"));
        }
        [Test]
        public void LoginTestFault()
        {
            bool result = clientTest.Login("ceo", "ceo");
            Assert.IsFalse(result);
        }

        [Test]
        public void LoginTestException()
        {
            Assert.DoesNotThrow(() => clientTest.Login("exception", "exception"));
        }

        [Test]
        public void LogoutTestOk()
        {
            bool result = clientTest.LogOut("ceo1");
            Assert.IsTrue(result);
        }
       
        [Test]
        public void LogoutTestFault()
        {
            bool result = clientTest.LogOut("ceo");
            Assert.IsFalse(result);
        }

        [Test]
        public void LogoutTestException()
        {
            Assert.DoesNotThrow(() => clientTest.LogOut("exception"));
        }

        [Test]
        public void AddUserTestOk()
        {
            User user = new User() { Username = "user1", Password = "pass1" };
            bool result = clientTest.AddUser(user);
            Assert.IsTrue(result);
        }
        [Test]
        public void AddUserTestFault()
        {
            User user = new User() { Username = "user2", Password = "pass2" };
            bool result = clientTest.AddUser(user);
            Assert.IsFalse(result);
        }
        [Test]
        public void AddUserTestException()
        {
            User user = new User() { Username = "user3", Password = "pass3" };
            Assert.DoesNotThrow(() => clientTest.AddUser(user));
        }
        [Test]
        public void EditUserTestOk()
        {
            User user = new User() { Username = "user1", Password = "pass1" };
            bool result = clientTest.EditUser(user);
            Assert.IsTrue(result);
        }
        [Test]
        public void EditUserTestFault()
        {
            User user = new User() { Username = "user2", Password = "pass2" };
            bool result = clientTest.EditUser(user);
            Assert.IsFalse(result);
        }
        [Test]
        public void EditUserTestException()
        {
            User user = new User() { Username = "user3", Password = "pass3" };
            Assert.DoesNotThrow(() => clientTest.EditUser(user));
        }
        [Test]
        public void AddPartnerCompanyTestOk()
        {
            User u = new User() { Username = "user1" };
            string comp = "Kompanija1";
            bool result = clientTest.AddPartnerCompany(u, comp);
            Assert.IsTrue(result);
        }
        [Test]
        public void AddPartnerCompanyTestFault()
        {
            User u = new User() { Username = "u" };
            string comp = "Komp";
            bool result = clientTest.AddPartnerCompany(u, comp);
            Assert.IsFalse(result);
        }
        [Test]
        public void AddPartnerCompanyTestException()
        {
            User u = new User() { Username = "u1" };
            string comp = "Komp1";
            Assert.DoesNotThrow(() => clientTest.AddPartnerCompany(u, comp));
        }
        [Test]
        public void UpdateProjectTestOk()
        {
            Project proj = new Project() { Name = "Projekat1" };
            bool result = clientTest.UpdateProject(proj);
            Assert.IsTrue(result);
        }
        [Test]
        public void UpdateProjectTestFault()
        {
            Project proj = new Project() { Name = "Proj" };
            bool result = clientTest.UpdateProject(proj);
            Assert.IsFalse(result);
        }
        [Test]
        public void UpdateProjectTestException()
        {
            Project proj = new Project() { Name = "Proj1" };
            Assert.DoesNotThrow(() => clientTest.UpdateProject(proj));
        }
        [Test]
        public void CreateProjectTestOk()
        {
            Project proj = new Project() { Name = "Projekat1" };
            bool result = clientTest.CreateProject(proj);
            Assert.IsTrue(result);
        }
        [Test]
        public void CreateProjectTestFault()
        {
            Project proj = new Project() { Name = "Proj" };
            bool result = clientTest.CreateProject(proj);
            Assert.IsFalse(result);
        }
        [Test]
        public void CreateProjectTestException()
        {
            Project proj = new Project() { Name = "Proj1" };
            Assert.DoesNotThrow(() => clientTest.CreateProject(proj));
        }
        [Test]
        public void ChangePassTestOk()
        {
            bool result = clientTest.ChangePass("ceo1", "ceo1", "c1");
            Assert.IsTrue(result);
        }
        [Test]
        public void ChangePassTestFault()
        {
            bool result = clientTest.ChangePass("ceo", "ceo", "c1");
            Assert.IsFalse(result);
        }
        [Test]
        public void ChangePassTestException()
        {
            Assert.DoesNotThrow(() => clientTest.ChangePass("ceo1", "ceo1", "c11"));
        }
        [Test]
        public void GetAllOnlineUsersTest()
        {
            List<User> expectedList = new List<User>() { new User() { Username = "user1" } };
            List<User> list = clientTest.GetAllOnlineUsers();
            Assert.AreEqual(list[0].Name, expectedList[0].Name);
        }
        [Test]
        public void GetAllOnlineUsersTestException()
        {
            Assert.DoesNotThrow(() => clientTest.GetAllOnlineUsers());
        }
        [Test]
        public void GetAllEmployeesTest()
        {
            List<User> expectedList = new List<User>() { new User() { Username = "user1" }, new User() { Username = "user2" } };
            List<User> list = clientTest.GetAllEmployees();
            Assert.AreEqual(expectedList[0].Username, list[0].Username);
        }

        [Test]
        public void GetAllPartnerCompaniesTest()
        {
            User u = new User() { Username = "user1" };
            List<string> expectedList = new List<string>() { "partner1", "partner2" };
            List<string> list = clientTest.GetAllPartnerCompanies(u);
            Assert.AreEqual(list, expectedList);
        }
        [Test]
        public void GetAllProjectsTest()
        {
            List<Project> expectedList = new List<Project>() { new Project() { Name = "Projekat1" } };
            List<Project> list = clientTest.GetAllProjects();
            Assert.AreEqual(list[0].Name, expectedList[0].Name);
        }
        [Test]
        public void GetAllProjectsForUserTest()
        {
            User u = new User() { Username = "user1" };
            List<Project> expectedList = new List<Project>() { new Project() { Name = "Projekat1" } };
            List<Project> list = clientTest.GetAllProjectsForUser(u);
            Assert.AreEqual(list[0].Name, expectedList[0].Name);
        }
        [Test]
        public void GetAllUserStoriesTest()
        {
            Project p = new Project() { Name = "Projekat1" };
            List<string> expectedList = new List<string>() { "Projekat1", "Projekat2" };
            List<string> list = clientTest.GetAllUserStories(p);
            Assert.AreEqual(list, expectedList);
        }

    }
}