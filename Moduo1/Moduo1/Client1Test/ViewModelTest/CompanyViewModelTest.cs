using Client1;
using Client1.ViewModel;
using Common;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client1Test.ViewModelTest
{
    [TestFixture, RequiresSTA]
    public class CompanyViewModelTest
    {
        private CompanyViewModel companyViewModelTest;
        private Context wrap;

        [OneTimeSetUp]
        public void SetupTest()
        {
            wrap = new Context();

            companyViewModelTest = new CompanyViewModel();
            wrap.Proxy.Factory = Substitute.For<ICompanyService>();

            wrap.Proxy.Factory.Login("user", "user").ReturnsForAnyArgs(true);

            wrap.Proxy.Factory.LogOut("user").ReturnsForAnyArgs(true);


            wrap.Proxy.Factory.AddUser(Arg.Is<User>(x => x.Username == "user1" && x.Password == "pass1")).Returns(true);      
            wrap.Proxy.Factory.EditUser(Arg.Is<User>(x => x.Name == "user1" && x.Password == "pass1")).Returns(true);

            wrap.Proxy.Factory.GetAllEmployees().Returns(new List<User>() { new User() { Name = "user" } });
            wrap.Proxy.Factory.GetAllOnlineUsers().Returns(new List<User>() { new User() { Name = "user" } });


        }

        [Test]
        public void CompanyViewModelConstructorTest()
        {
            Assert.DoesNotThrow(() => new CompanyViewModel());
        }

        [Test]
        public void LoginClickTest()
        {
            string[] param = { "user", "user" };
            Assert.DoesNotThrow(() => companyViewModelTest.Login.Execute(param));

        }

        [Test]
        public void LoginCommandTest()
        {
            Assert.IsNotNull(companyViewModelTest.Login);
        }

        [Test]
        public void AddUserTest()
        {
            string[] param = { "user1", "pass1" };
            Assert.DoesNotThrow(() => companyViewModelTest.AddUser.Execute(param));

        }
        [Test]
        public void EditPcTest()
        {
            string[] param = { "user1", "pass1" };
            Assert.DoesNotThrow(() => companyViewModelTest.EditPc.Execute(param));

        }
        [Test]
        public void EditPiTest()
        {
            string[] param = { "user1", "pass1" };
            Assert.DoesNotThrow(() => companyViewModelTest.EditPi.Execute(param));

        }


        /*[Test]
        public void AdminEditUserTest()
        {
            string[] param = { "user1", "pass1" };
            Assert.DoesNotThrow(() => companyViewModelTest.AdminEditUser.Execute(param));

        }
        [Test]
        public void PoAddProjectTest()
        {
            string[] param = { "user", "user" };
            Assert.DoesNotThrow(() => companyViewModelTest.PoAddProject.Execute(param));

        }

        [Test]
        public void SendRequestTest()
        {
            string[] param = { "user", "user" };
            Assert.DoesNotThrow(() => companyViewModelTest.SendRequest.Execute(param));

        }
        [Test]
        public void ApproveProjectTest()
        {
            string[] param = { "user", "user" };
            Assert.DoesNotThrow(() => companyViewModelTest.ApproveProject.Execute(param));

        }
        [Test]
        public void SendProjectTest()
        {
            string[] param = { "user", "user" };
            Assert.DoesNotThrow(() => companyViewModelTest.SendProject.Execute(param));

        }
        [Test]
        public void CloseProjectTest()
        {
            string[] param = { "user1", "pass1" };
            Assert.DoesNotThrow(() => companyViewModelTest.CloseProject.Execute(param));

        }*/

        #region propertiesTests

        [Test]
        public void LoginCommand()
        {
            Assert.IsNotNull(companyViewModelTest.Login);

        }
        [Test]
        public void AddUserCommand()
        {
            Assert.IsNotNull(companyViewModelTest.AddUser);

        }
        [Test]
        public void EditPcCommand()
        {
            Assert.IsNotNull(companyViewModelTest.EditPc);

        }
        [Test]
        public void EditPiCommand()
        {
            Assert.IsNotNull(companyViewModelTest.EditPi);

        }
        [Test]
        public void AdminAddUserCommand()
        {
            Assert.IsNotNull(companyViewModelTest.AdminAddUser);

        }
        [Test]
        public void AdminEditUserCommand()
        {
            Assert.IsNotNull(companyViewModelTest.AdminEditUser);

        }
        [Test]
        public void PoAddProjectCommand()
        {
            Assert.IsNotNull(companyViewModelTest.PoAddProject);

        }
        [Test]
        public void SendProjectCommand()
        {
            Assert.IsNotNull(companyViewModelTest.SendProject);

        }
        [Test]
        public void SendRequestCommand()
        {
            Assert.IsNotNull(companyViewModelTest.SendRequest);

        }
        [Test]
        public void ApproveProjectCommand()
        {
            Assert.IsNotNull(companyViewModelTest.ApproveProject);

        }
        [Test]
        public void CloseProjectCommand()
        {
            Assert.IsNotNull(companyViewModelTest.CloseProject);

        }
        [Test]
        public void CloseWindowCommand()
        {
            Assert.IsNotNull(companyViewModelTest.CloseWindow);

        }

        [Test]
        public void EmployeeListTest()
        {
            ObservableCollection<User> employeeList = new ObservableCollection<User>() { new User() { Username = "user1" } };

            companyViewModelTest.EmployeeList = employeeList;

            Assert.AreEqual(employeeList, companyViewModelTest.EmployeeList);
        }
        [Test]
        public void ProjectsTest()
        {
            ObservableCollection<Project> projects = new ObservableCollection<Project>() { new Project() { Name = "Projekat" } };

            companyViewModelTest.Projects = projects;

            Assert.AreEqual(projects, companyViewModelTest.Projects);
        }
        [Test]
        public void NotActiveProjectsTest()
        {

            ObservableCollection<Project> projects = new ObservableCollection<Project>() { new Project() { Name = "Projekat" } };

            companyViewModelTest.NotActiveProjects = projects;

            Assert.AreEqual(projects, companyViewModelTest.NotActiveProjects);
        }
        [Test]
        public void ActiveProjectsTest()
        {
            ObservableCollection<Project> projects = new ObservableCollection<Project>() { new Project() { Name = "Projekat" } };

            companyViewModelTest.ActiveProjects = projects;

            Assert.AreEqual(projects, companyViewModelTest.ActiveProjects);
        }
        [Test]
        public void ProjectsAdminTest()
        {
            ObservableCollection<Project> projects = new ObservableCollection<Project>() { new Project() { Name = "Projekat" } };

            companyViewModelTest.ProjectsAdmin = projects;

            Assert.AreEqual(projects, companyViewModelTest.ProjectsAdmin);
        }

        [Test]
        public void FinishedProjectsTest()
        {
            ObservableCollection<Project> projects = new ObservableCollection<Project>() { new Project() { Name = "Projekat" } };

            companyViewModelTest.FinishedProjects = projects;

            Assert.AreEqual(projects, companyViewModelTest.FinishedProjects);
        }
        [Test]
        public void PartnerCompaniesTest()
        {
            ObservableCollection<string> companies = new ObservableCollection<string>() { "partner1", "partner2" };

            companyViewModelTest.PartnerCompanies = companies;

            Assert.AreEqual(companies, companyViewModelTest.PartnerCompanies);
        }
       
        [Test]
        public void LoggedInUserTest()
        {
            string user = "user";

            companyViewModelTest.LoggedInUser = user;

            Assert.AreEqual(user, companyViewModelTest.LoggedInUser);
        }
        [Test]
        public void SelectedUserForEditTest()
        {
            string user = "user";

            companyViewModelTest.SelectedUserForEdit = user;

            Assert.AreEqual(user, companyViewModelTest.SelectedUserForEdit);
        }
        [Test]
        public void UsernameLoginTest()
        {
            string user = "user";

            companyViewModelTest.UsernameLogin = user;

            Assert.AreEqual(user, companyViewModelTest.UsernameLogin);
        }
        [Test]
        public void PasswordLoginTest()
        {
            string user = "user";

            companyViewModelTest.PasswordLogin = user;

            Assert.AreEqual(user, companyViewModelTest.PasswordLogin);
        }
        [Test]
        public void UsernameAddUserTest()
        {
            string user = "user";

            companyViewModelTest.UsernameAddUser = user;

            Assert.AreEqual(user, companyViewModelTest.UsernameAddUser);
        }
        [Test]
        public void PasswordAddUserTest()
        {
            string user = "user";

            companyViewModelTest.PasswordAddUser = user;

            Assert.AreEqual(user, companyViewModelTest.PasswordAddUser);
        }

        [Test]
        public void Pi_usernameTest()
        {
            string user = "user";

            companyViewModelTest.PiUsername = user;

            Assert.AreEqual(user, companyViewModelTest.PiUsername);
        }
        [Test]
        public void Pi_lastnameTest()
        {
            string user = "user";

            companyViewModelTest.PiLastname = user;

            Assert.AreEqual(user, companyViewModelTest.PiLastname);
        }
        [Test]
        public void Pi_nameTest()
        {
            string user = "user";

            companyViewModelTest.PiName = user;

            Assert.AreEqual(user, companyViewModelTest.PiName);
        }
        [Test]
        public void Pi_emailTest()
        {
            string user = "user";

            companyViewModelTest.PiEmail = user;

            Assert.AreEqual(user, companyViewModelTest.PiEmail);
        }
        [Test]
        public void Pi_fromTest()
        {
            string user = "user";

            companyViewModelTest.PiFrom = user;

            Assert.AreEqual(user, companyViewModelTest.PiFrom);
        }
        [Test]
        public void Pi_toTest()
        {
            string user = "user";

            companyViewModelTest.PiTo = user;

            Assert.AreEqual(user, companyViewModelTest.PiTo);
        }
        [Test]
        public void Pi_passwordTest()
        {
            string user = "user";

            companyViewModelTest.PiPassword = user;

            Assert.AreEqual(user, companyViewModelTest.PiPassword);
        }
        [Test]
        public void Pc_passwordChangeTest()
        {
            string user = "user";

            companyViewModelTest.PcNewPassword = user;

            Assert.AreEqual(user, companyViewModelTest.PcNewPassword);
        }
        [Test]
        public void Ae_username_adminTest()
        {
            string user = "user";

            companyViewModelTest.AeUsernameAdmin = user;

            Assert.AreEqual(user, companyViewModelTest.AeUsernameAdmin);
        }
        [Test]
        public void Ae_password_adminTest()
        {
            string user = "user";

            companyViewModelTest.AePasswordAdmin = user;

            Assert.AreEqual(user, companyViewModelTest.AePasswordAdmin);
        }
        [Test]
        public void Ae_lastname_adminTest()
        {
            string user = "user";

            companyViewModelTest.AeLastnameAdmin = user;

            Assert.AreEqual(user, companyViewModelTest.AeLastnameAdmin);
        }
        [Test]
        public void Ae_name_adminTest()
        {
            string user = "user";

            companyViewModelTest.AeNameAdmin = user;

            Assert.AreEqual(user, companyViewModelTest.AeNameAdmin);
        }
        [Test]
        public void Ae_email_adminTest()
        {
            string user = "user";

            companyViewModelTest.AeEmailAdmin = user;

            Assert.AreEqual(user, companyViewModelTest.AeEmailAdmin);
        }
        [Test]
        public void Ae_roleComboBox_adminTest()
        {
            string user = "user";

            companyViewModelTest.AeRoleComboBoxAdmin = user;

            Assert.AreEqual(user, companyViewModelTest.AeRoleComboBoxAdmin);
        }
        [Test]
        public void Ae_role_adminTest()
        {
            string user = "user";

            companyViewModelTest.AeRoleAdmin = user;

            Assert.AreEqual(user, companyViewModelTest.AeRoleAdmin);
        }
        [Test]
        public void Ae_roleComboboxIdx_adminTest()
        {
            int user = 0;

            companyViewModelTest.AeRoleAdminIdx = user;

            Assert.AreEqual(user, companyViewModelTest.AeRoleAdminIdx);
        }



        [Test]
        public void Ee_username_adminTest()
        {
            string user = "user";

            companyViewModelTest.EeUsernameAdmin = user;

            Assert.AreEqual(user, companyViewModelTest.EeUsernameAdmin);
        }
        [Test]
        public void Ee_password_adminTest()
        {
            string user = "user";

            companyViewModelTest.EePasswordAdmin = user;

            Assert.AreEqual(user, companyViewModelTest.EePasswordAdmin);
        }
        [Test]
        public void Ee_lastname_adminTest()
        {
            string user = "user";

            companyViewModelTest.EeLastnameAdmin = user;

            Assert.AreEqual(user, companyViewModelTest.EeLastnameAdmin);
        }
        [Test]
        public void Ee_name_adminTest()
        {
            string user = "user";

            companyViewModelTest.EeNameAdmin = user;

            Assert.AreEqual(user, companyViewModelTest.EeNameAdmin);
        }
        [Test]
        public void Ee_email_adminTest()
        {
            string user = "user";

            companyViewModelTest.EeEmailAdmin = user;

            Assert.AreEqual(user, companyViewModelTest.EeEmailAdmin);
        }
        [Test]
        public void Ee_roleComboBox_adminTest()
        {
            string user = "user";

            companyViewModelTest.EeRoleComboBoxAdmin = user;

            Assert.AreEqual(user, companyViewModelTest.EeRoleComboBoxAdmin);
        }
        [Test]
        public void Ee_role_adminTest()
        {
            string user = "user";

            companyViewModelTest.EeRoleAdmin = user;

            Assert.AreEqual(user, companyViewModelTest.EeRoleAdmin);
        }
        [Test]
        public void Ee_roleComboboxIdx_adminTest()
        {
            int user = 0;

            companyViewModelTest.EeRoleAdminIdx = user;

            Assert.AreEqual(user, companyViewModelTest.EeRoleAdminIdx);
        }
        [Test]
        public void ApNamePoTest()
        {
            string user = "user";

            companyViewModelTest.ApNamePo = user;

            Assert.AreEqual(user, companyViewModelTest.ApNamePo);
        }
        [Test]
        public void ApDescPoTest()
        {
            string user = "user";

            companyViewModelTest.ApDescPo = user;

            Assert.AreEqual(user, companyViewModelTest.ApDescPo);
        }
        [Test]
        public void ApToPoTest()
        {
            string user = "user";

            companyViewModelTest.ApToPo = user;

            Assert.AreEqual(user, companyViewModelTest.ApToPo);
        }
        [Test]
        public void ApFroPoTest()
        {
            string user = "user";

            companyViewModelTest.ApFromPo = user;

            Assert.AreEqual(user, companyViewModelTest.ApFromPo);
        }

        #endregion

    }
}
