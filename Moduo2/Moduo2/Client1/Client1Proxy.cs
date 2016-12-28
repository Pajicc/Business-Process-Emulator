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
    }
}
