using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace SRV1.Access
{
    public interface IDB
    {
        bool AddUser(User user);
        bool Login(string username, string pass);
        bool LogOut(string username);
        User GetUser(string username);
        bool EditUser(User userEdit);
        List<User> GetAllEmployees();
        List<User> GetAllOnlineUsers();
        bool CreateProject(Project prj);
        bool UpdateProject(Project p);
        List<Project> GetAllProjectsForUser(User user);
        List<Project> GetAllProjects();
        List<string> GetAllPartnerCompanies(User user);
        bool AddPartnerCompany(User user, string partner);
        bool AddHiringCompany(HiringCompany hc);
        bool ChangePass(string username, string oldPass, string newPass);
        List<string> GetAllHiringCompanies();
        List<string> GetAllUserStories(Project proj);
        bool AddUserStory(string usName, string usCriteria, string projectName);
    }
}
