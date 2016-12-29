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

    }
}
