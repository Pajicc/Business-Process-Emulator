using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace SRV2.Access
{
    public interface IDB
    {
        bool AddUser(User user);
        User CheckUser(string username, string pass);
        bool LogOut(string username, string pass);
        User GetUser(string username);
        bool EditUser(User userMain, User userEdit);
        List<User> GetAllLogedUsers();
        List<User> GetAllUsers();
        bool UpdatePass(string username, string pass);



        bool AddProject(Project project);
        List<Project> GetAllProjects();
        bool AddTeam(Tim tim);
        List<User> GetUsersByType(Roles role);
        List<Tim> GetAllTeams();
        Tim GetTimByName(string naziv);
        bool AddTeamToProject(string nazivProjekta, string nazivTima);



    }
}
