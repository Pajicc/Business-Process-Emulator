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
        private ICompanyService factory;

        public ICompanyService Factory
        {
            get
            {
                return factory;
            }

            set
            {
                factory = value;
            }
        }

        public Client1Proxy(NetTcpBinding binding, EndpointAddress address) : base(binding, address)
        {
            Factory = this.CreateChannel();
        }

        public Client1Proxy()
        {
        }

        public bool Login(string username, string pass)
        {
            bool allowed = false;

            try
            {
                allowed = Factory.Login(username, pass);
                Console.WriteLine("Login() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to Login(). {0}", e.Message);
            }

            return allowed;
        }

        public bool LogOut(string username)
        {
            bool done = false;

            try
            {
                done = Factory.LogOut(username);
                Console.WriteLine("LogOut() >> succeded");             
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
                allowed = Factory.AddUser(u);
                Console.WriteLine("AddUser() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to AddUser(). {0}", e.Message);
            }

            return allowed;
        }


        public bool EditUser(User editUser)
        {
            bool allowed = false;

            try
            {
                allowed = Factory.EditUser(editUser);
                Console.WriteLine("EditUser() >> succeded");
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
                allEmpl = Factory.GetAllEmployees();
                Console.WriteLine("GetAllEmployees() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetAllEmployees(). {0}", e.Message);
            }

            return allEmpl;
        }
        public List<User> GetAllOnlineUsers()
        {
            List<User> allEmpl = new List<User>();

            try
            {
                allEmpl = Factory.GetAllOnlineUsers();
                Console.WriteLine("GetAllOnlineUsers() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetAllOnlineUsers(). {0}", e.Message);
            }

            return allEmpl;
        }

        public User GetUser(string username)
        {
            User u = new User();

            try
            {
                u = Factory.GetUser(username);
                Console.WriteLine("GetUser() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetUser(). {0}", e.Message);
            }

            return u;
        }

        public bool CreateProject(Project prj)
        {
            bool allowed = false;

            try
            {
                allowed = Factory.CreateProject(prj);
                Console.WriteLine("CreateProject() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to CreateProject(). {0}", e.Message);
            }

            return allowed;
        }

        public bool UpdateProject(Project prj)
        {
            bool allowed = false;

            try
            {
                allowed = Factory.UpdateProject(prj);
                Console.WriteLine("UpdateProject() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to UpdateProject(). {0}", e.Message);
            }

            return allowed;
        }

        public List<Project> GetAllProjectsForUser(User user)
        {
            List<Project> projekti = new List<Project>();

            try
            {
                projekti = Factory.GetAllProjectsForUser(user);
                Console.WriteLine("GetAllProjectsForUser() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetAllProjects(). {0}", e.Message);
            }

            return projekti;
        }

        public List<Project> GetAllProjects()
        {
            List<Project> projekti = new List<Project>();

            try
            {
                projekti = Factory.GetAllProjects();
                Console.WriteLine("GetAllProjects() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetAllProjects(). {0}", e.Message);
            }

            return projekti;
        }

        public List<string> GetAllPartnerCompanies(User user)
        {
            List<string> companies = new List<string>();

            try
            {
                companies = Factory.GetAllPartnerCompanies(user);
                Console.WriteLine("GetAllPartnerCompanies() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetAllPartnerCompanies(). {0}", e.Message);
            }

            return companies;
        }

        public bool AddPartnerCompany(User user, string partner)
        {
            bool allowed = false;

            try
            {
                allowed = Factory.AddPartnerCompany(user, partner);
                Console.WriteLine("AddPartnerCompany() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to AddPartnerCompany(). {0}", e.Message);
            }

            return allowed;
        }

        public bool ChangePass(string username, string oldPass, string newPass)
        {
            bool allowed = false;

            try
            {
                allowed = Factory.ChangePass(username, oldPass, newPass);
                Console.WriteLine("ChangePass() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to ChangePass(). {0}", e.Message);
            }

            return allowed;
        }

        public List<string> GetAllUserStories(Project proj)
        {
            List<string> userStories = new List<string>();

            try
            {
                userStories = Factory.GetAllUserStories(proj);
                Console.WriteLine("GetAllUserStories() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetAllUserStories(). {0}", e.Message);
            }

            return userStories;
        }
    }
}
