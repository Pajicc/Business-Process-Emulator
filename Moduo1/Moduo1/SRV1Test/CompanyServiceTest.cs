using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SRV1;
using Common;
using SRV1.Access;
using NSubstitute;

namespace SRV1Test
{
    [TestFixture]
    public class CompanyServiceTest
    {
        private CompanyService companyServiceTest;

        [OneTimeSetUp]
        public void SetupTest()
        {
            companyServiceTest = new CompanyService();
            DB.Instance = Substitute.For<IDB>();

            DB.Instance.Login("ceo1", "ceo1").Returns(true);
            DB.Instance.Login("ceo", "ceo").Returns(false);

            DB.Instance.LogOut("ceo1").Returns(true);
            DB.Instance.LogOut("ceo").Returns(false);

            DB.Instance.AddUser(new User() { Username = "user1", Password = "pass1" }).Returns(true);
            DB.Instance.AddUser(new User() { Username = "user2", Password = "pass2" }).Returns(false);

            DB.Instance.EditUser(new User() { Username = "user1", Password = "pass1" }).Returns(true);
            DB.Instance.EditUser(new User() { Username = "user2", Password = "pass2" }).Returns(false);

            DB.Instance.GetUser("user1").Returns(new User() { Username = "user" });

            DB.Instance.GetAllOnlineUsers().Returns(new List<User> { new User() { Username = "user1" } });
            DB.Instance.GetAllEmployees().Returns(new List<User> { new User() { Username = "user1" } });
            DB.Instance.GetAllHiringCompanies().Returns(new List<string> { "hiringCompany1", "hiringCompany2" });
            DB.Instance.GetAllPartnerCompanies(new User() { Username = "usr1" }).Returns(new List<string> { "partner1", "partner2" });
            DB.Instance.GetAllProjects().Returns(new List<Project> { new Project() { Name = "Projekat1" } });
            DB.Instance.GetAllProjectsForUser(new User() { Username = "ceo1" }).Returns(new List<Project> { new Project() { Name = "Projekat1" } });
            DB.Instance.GetAllUserStories(new Project() { Name = "Projekat1" }).Returns(new List<string> { "Projekat1", "Projekat2" });

            DB.Instance.AddHiringCompany(new HiringCompany() { Name = "HiringCompany3" }).Returns(true);
            DB.Instance.AddHiringCompany(new HiringCompany() { Name = "company" }).Returns(false);

            DB.Instance.AddPartnerCompany(new User() { Name = "ceo1" }, "Kompanija1").Returns(true);
            DB.Instance.AddPartnerCompany(new User() { Name = "u" }, "Komp").Returns(false);

            DB.Instance.AddUserStory("UserStory1", "criteria", "Projekat1").Returns(true);
            DB.Instance.AddUserStory("UserStory2", "criteria2", "project").Returns(false);

            DB.Instance.UpdateProject(new Project() { Name = "Projekat1" }).Returns(true);
            DB.Instance.UpdateProject(new Project() { Name = "Proj" }).Returns(false);

            DB.Instance.CreateProject(new Project() { Name = "Projekat" }).Returns(true);
            DB.Instance.CreateProject(new Project() { Name = "Proj" }).Returns(false);

            DB.Instance.ChangePass("ceo1", "ceo1", "c1").Returns(true);
            DB.Instance.ChangePass("ceo", "ceo", "c1").Returns(false);

        }

        [Test]
        [TestCase("user1", "user1")]
        public void LoginTestOk(string username, string pass)
        {
            Assert.DoesNotThrow(() => { companyServiceTest.Login(username, pass); });
        }

        [Test]
        [TestCase("user1")]
        [TestCase("us")]
        public void GetUserOk(string username)
        {
            Assert.DoesNotThrow(() => { companyServiceTest.GetUser(username); });
        }
        [Test]
        public void GetUserTest()
        {
            User result = companyServiceTest.GetUser("user");
            string name = "user1";
            Assert.AreEqual(result.Name, name);
        }

        [Test]
        public void LoginTestFault()
        {
            bool result = companyServiceTest.Login("ceo", "ceo");
            Assert.IsFalse(result);
        }

        [Test]
        public void LogoutTestOk()
        {
            bool result = companyServiceTest.LogOut("ceo1");
            Assert.IsTrue(result);
        }
        [Test]
        public void LogoutTestFault()
        {
            bool result = companyServiceTest.LogOut("ceo");
            Assert.IsFalse(result);
        }
        [Test]
        public void AddUserTestOk()
        {
            User user = new User() { Username = "user1" };
            bool result = companyServiceTest.AddUser(user);
            Assert.IsTrue(result);
        }
        [Test]
        public void AddUserTestFault()
        {
            User user = new User() { Username = "user2" };
            bool result = companyServiceTest.AddUser(user);
            Assert.IsFalse(result);
        }
        [Test]
        public void EditUserTestOk()
        {
            User user = new User() { Username = "user1", Password = "pass1" };
            bool result = companyServiceTest.EditUser(user);
            Assert.IsTrue(result);
        }
        [Test]
        public void EditUserTestFault()
        {
            User user = new User() { Username = "user2", Password = "pass2" };
            bool result = companyServiceTest.EditUser(user);
            Assert.IsFalse(result);
        }
        [Test]
        public void AddHiringCompanyTestOk()
        {
            HiringCompany comp = new HiringCompany() { Name = "HiringCompany3" };
            bool result = companyServiceTest.AddHiringCompany(comp);
            Assert.IsTrue(result);
        }
        [Test]
        public void AddHiringCompanyTestFault()
        {
            HiringCompany comp = new HiringCompany() { Name = "company" };
            bool result = companyServiceTest.AddHiringCompany(comp);
            Assert.IsFalse(result);
        }
        [Test]
        public void AddPartnerCompanyTestOk()
        {
            User u = new User() { Username = "ceo1" };
            string comp = "Kopmanija1";
            bool result = companyServiceTest.AddPartnerCompany(u, comp);
            Assert.IsTrue(result);
        }
        [Test]
        public void AddPartnerCompanyTestFault()
        {
            User u = new User() { Username = "u" };
            string comp = "Komp";
            bool result = companyServiceTest.AddPartnerCompany(u, comp);
            Assert.IsFalse(result);
        }
        [Test]
        public void AddUserStoryTestOk()
        {
            bool result = companyServiceTest.ApproveUserStory("UserStory1", "criteria", "Projekat1");
            Assert.IsTrue(result);
        }
        [Test]
        public void AddUserStoryTestFalse()
        {
            bool result = companyServiceTest.ApproveUserStory("UserStory2", "criteria2", "project");
            Assert.IsFalse(result);
        }
        [Test]
        public void UpdateProjectTestOk()
        {
            Project proj = new Project() { Name = "Projekat1" };
            bool result = companyServiceTest.UpdateProject(proj);
            Assert.IsTrue(result);
        }
        [Test]
        public void UpdateProjectTestFault()
        {
            Project proj = new Project() { Name = "Proj" };
            bool result = companyServiceTest.UpdateProject(proj);
            Assert.IsFalse(result);
        }
        [Test]
        public void CreateProjectTestOk()
        {
            Project proj = new Project() { Name = "Projekat1" };
            bool result = companyServiceTest.CreateProject(proj);
            Assert.IsTrue(result);
        }
        [Test]
        public void CreateProjectTestFault()
        {
            Project proj = new Project() { Name = "Proj" };
            bool result = companyServiceTest.CreateProject(proj);
            Assert.IsFalse(result);
        }
        [Test]
        public void ChangePassTestOk()
        {
            bool result = companyServiceTest.ChangePass("ceo1", "ceo1", "c1");
            Assert.IsTrue(result);
        }
        [Test]
        public void ChangePassTestFault()
        {
            bool result = companyServiceTest.ChangePass("ceo", "ceo", "c1");
            Assert.IsFalse(result);
        }
        [Test]
        public void GetAllOnlineUsersTest()
        {
            List<User> expectedList = new List<User>() { new User() { Name = "user1" } };
            List<User> list = companyServiceTest.GetAllOnlineUsers();
            Assert.AreEqual(list, expectedList);
        }
        [Test]
        public void GetAllEmployeesTest()
        {
            List<User> expectedList = new List<User>() { new User() { Name = "user1" } };
            List<User> list = companyServiceTest.GetAllEmployees();
            Assert.AreEqual(list, expectedList);
        }
        [Test]
        public void GetAllHiringCompaniesTest()
        {
            List<string> expectedList = new List<string>() { "hiringCompany1", "hiringCompany2" };
            List<string> list = companyServiceTest.GetAllHiringCompanies();
            Assert.AreEqual(list, expectedList);
        }
        [Test]
        public void GetAllPartnerCompaniesTest()
        {
            User u = new User() { Username = "usr1" };
            List<string> expectedList = new List<string>() { "partner1", "partner2" };
            List<string> list = companyServiceTest.GetAllPartnerCompanies(u);
            Assert.AreEqual(list, expectedList);
        }
        [Test]
        public void GetAllProjectsTest()
        {
            List<Project> expectedList = new List<Project>() { new Project() { Name = "Projekat1" } };
            List<Project> list = companyServiceTest.GetAllProjects();
            Assert.AreEqual(list, expectedList);
        }
        [Test]
        public void GetAllProjectsForUserTest()
        {
            User u = new User() { Username = "ceo1" };
            List<Project> expectedList = new List<Project>() { new Project() { Name = "Projekat1" } };
            List<Project> list = companyServiceTest.GetAllProjectsForUser(u);
            Assert.AreEqual(list, expectedList);
        }
        [Test]
        public void GetAllUserStoriesTest()
        {
            Project p = new Project() { Name = "Projekat1" };
            List<string> expectedList = new List<string>() { "Projekat1", "Projekat2" };
            List<string> list = companyServiceTest.GetAllUserStories(p);
            Assert.AreEqual(list, expectedList);
        }
    }
}
