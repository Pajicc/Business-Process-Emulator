using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Client2
{
    public class Client1Proxy : ChannelFactory<ICompanyService>, ICompanyService, IDisposable
    {
        ICompanyService factory;

        public Client1Proxy(NetTcpBinding binding, EndpointAddress address)
            : base(binding, address)
        {
            factory = this.CreateChannel();
        }

        public User Login(string username, string pass)
        {
            User u = new User();

            try
            {
                u = factory.Login(username, pass);
                Console.WriteLine("Login() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to Login(). {0}", e.Message);
            }

            return u;
        }

        public bool LogOut(string username, string pass)
        {
            bool done = false;

            try
            {
                factory.LogOut(username, pass);
                Console.WriteLine("LogOut() >> succeded");
                done = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to LogOut(). {0}", e.Message);
            }

            return done;
        }

        public bool AddUser(User u)
        {
            bool allowed = false;

            try
            {
                factory.AddUser(u);
                Console.WriteLine("AddUser() >> succeded");
                allowed = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to AddUser(). {0}", e.Message);
            }

            return allowed;
        }

        public bool EditUser(User userMain, User editUser)
        {
            bool allowed = false;

            try
            {
                factory.EditUser(userMain, editUser);
                Console.WriteLine("EditUser() >> succeded");
                allowed = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to EditUser(). {0}", e.Message);
            }

            return allowed;
        }

        public List<User> GetAllLogedUsers()
        {
            List<User> allEmpl = new List<User>();

            try
            {
                allEmpl = factory.GetAllLogedUsers();
                Console.WriteLine("GetAllEmployees() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetAllEmployees(). {0}", e.Message);
            }

            return allEmpl;
        }

        public List<string> GetCompanyes()
        {
            List<string> allEmpl = new List<string>();

            try
            {
                allEmpl = factory.GetCompanyes();
                Console.WriteLine("GetAllproj() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetAllproj(). {0}", e.Message);
            }

            return allEmpl;
        }

        public User GetUser(string username)
        {
            User u = new User();

            try
            {
                u = factory.GetUser(username);
                Console.WriteLine("GetUser() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetUser(). {0}", e.Message);
            }

            return u;
        }

        public List<User> GetOnlineUsers()
        {
            List<User> onlineUsers = new List<User>();

            try
            {
                onlineUsers = factory.GetOnlineUsers();
                Console.WriteLine("GetOnlineUsers() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetOnlineUsers(). {0}", e.Message);
            }

            return onlineUsers;
        }



        public List<Tim> GetAllTims()
        {

            List<Tim> allTims = new List<Tim>();

            try
            {
                allTims = factory.GetAllTims();
                Console.WriteLine("GetAllTims() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetAllTims(). {0}", e.Message);
            }

            return allTims;
        }


        public List<Project> GetProjects()
        {
            List<Project> allProjects = new List<Project>();

            try
            {
                allProjects = factory.GetProjects();
                Console.WriteLine("GetAllTims() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetAllTims(). {0}", e.Message);
            }

            return allProjects;
        }


        public bool AddProjectToBase(Project proj)
        {
            bool allowed = false;

            try
            {
                factory.AddProjectToBase(proj);
                Console.WriteLine("AddProject() >> succeded");
                allowed = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to AddUser(). {0}", e.Message);
            }

            return allowed;
        }


        public bool AddTeam(Tim tim)
        {
            bool allowed = false;

            try
            {
                factory.AddTeam(tim);
                Console.WriteLine("AddTeam() >> succeded");
                allowed = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to AddUser(). {0}", e.Message);
            }

            return allowed;
        }


        public List<User> GetUsersByType(Roles role)
        {
            List<User> users = new List<User>();

            try
            {
                users = factory.GetUsersByType(role);
                Console.WriteLine("GetUsers() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetUsers(). {0}", e.Message);
            }

            return users;
        }


        public Tim GetTimByName(string name)
        {
            Tim u = new Tim();

            try
            {
                u = factory.GetTimByName(name);
                Console.WriteLine("GetTeam() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetTeam(). {0}", e.Message);
            }

            return u;
        }


        public bool AddTeamToProject(string nazivProjekta, string nazivTima)
        {
            bool allowed = false;

            try
            {
                factory.AddTeamToProject(nazivProjekta,nazivTima);
                Console.WriteLine("AddTeamToProject() >> succeded");
                allowed = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to AddTeamToProject(). {0}", e.Message);
            }

            return allowed;
        }


        public List<User> GetAllUsers()
        {
            List<User> allEmpl = new List<User>();

            try
            {
                allEmpl = factory.GetAllUsers();
                Console.WriteLine("GetAllUSers() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetAllUsers(). {0}", e.Message);
            }

            return allEmpl;
        }


        public bool UpdatePass(string username, string pass)
        {
            bool allowed = false;

            try
            {
                factory.UpdatePass(username, pass);
                Console.WriteLine("UpdatePass() >> succeded");
                allowed = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to UpdatePass(). {0}", e.Message);
            }

            return allowed;
        }


        public bool AddUserStory(UserStory us)
        {
            bool allowed = false;

            try
            {
                factory.AddUserStory(us);
                Console.WriteLine("AddUS() >> succeded");
                allowed = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to AddUS(). {0}", e.Message);
            }

            return allowed;
        }


        public bool AddTeamToUser(string imeTima, string username)
        {
            bool allowed = false;

            try
            {
                factory.AddTeamToUser(imeTima, username);
                Console.WriteLine("AddTeamToUser() >> succeded");
                allowed = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to AddTeamToUser(). {0}", e.Message);
            }

            return allowed;
        }


        public bool AddUserStoryToTeam(User u, UserStory us)
        {
            bool allowed = false;

            try
            {
                factory.AddUserStoryToTeam(u, us);
                Console.WriteLine("AddTeamToUser() >> succeded");
                allowed = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to AddTeamToUser(). {0}", e.Message);
            }

            return allowed;
        }


        public UserStory GetUserStoryFromUser(User u)
        {
            UserStory us = new UserStory();

            try
            {
                us = factory.GetUserStoryFromUser(u);
                Console.WriteLine("GetUserStoryFromUser() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetUserStoryFromUser(). {0}", e.Message);
            }

            return us;
        }
    }
}