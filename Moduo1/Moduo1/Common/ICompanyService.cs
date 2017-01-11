using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface ICompanyService
    {

        [OperationContract]
        bool Login(string username, string pass);

        [OperationContract]
        bool LogOut(string username);

        [OperationContract]
        bool AddUser(User user);

        [OperationContract]
        bool EditUser(User editUser);

        [OperationContract]
        List<User> GetAllEmployees();

        [OperationContract]
        List<User> GetAllOnlineUsers();

        [OperationContract]
        User GetUser(string username);

        [OperationContract]
        bool CreateProject(Project prj);

        [OperationContract]
        bool DeleteProject(Project prj);

        [OperationContract]
        List<Project> GetAllProjects();

        [OperationContract]
        List<Project> GetAllProjectsCEO(string username);

        [OperationContract]
        bool UpdateProject(Project p);

        [OperationContract]
        List<string> GetAllPartnerCompanies(string username);

        [OperationContract]
        bool AddPartnerCompany(string ceo, string partner);

        [OperationContract]
        bool ChangePass(string username, string oldPass, string newPass);

        [OperationContract]
        string GetCompany(string username);

        [OperationContract]
        List<string> GetAllUserStories(Project proj);
    }
}
