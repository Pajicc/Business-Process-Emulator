using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Client1
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

        public List<User> GetAllEmployees()
        {
            List<User> allEmpl = new List<User>();

            try
            {
                allEmpl = factory.GetAllEmployees();
                Console.WriteLine("GetAllEmployees() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetAllEmployees(). {0}", e.Message);
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

        public bool CreateProject(Project prj)
        {
            bool allowed = false;

            try
            {
                factory.CreateProject(prj);
                Console.WriteLine("CreateProject() >> succeded");
                allowed = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to CreateProject(). {0}", e.Message);
            }

            return allowed;
        }

        public bool DeleteProject(Project prj)
        {
            bool allowed = false;

            try
            {
                factory.DeleteProject(prj);
                Console.WriteLine("DeleteProject() >> succeded");
                allowed = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to DeleteProject(). {0}", e.Message);
            }

            return allowed;
        }

        public List<Project> GetAllProjects()
        {
            List<Project> projekti = new List<Project>();

            try
            {
                projekti = factory.GetAllProjects();
                Console.WriteLine("GetAllProjects() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetAllProjects(). {0}", e.Message);
            }

            return projekti;
        }
    }
}
