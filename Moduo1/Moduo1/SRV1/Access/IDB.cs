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
        User CheckUser(string username, string pass);
        bool LogOut(string username, string pass);
        User GetUser(string username);
        bool EditUser(User userMain, User userEdit);
        List<User> GetAllEmployees();
        bool CreateProject(Project prj);
        bool DeleteProject(Project prj);
        bool UpdateProject(Project p);
        List<Project> GetAllProjects();
        List<string> GetAllPartnerCompanies(string username);
        bool AddPartnerCompany(string ceo, string partner);
        bool AddHiringCompany(HiringCompany hc);
    }
}
