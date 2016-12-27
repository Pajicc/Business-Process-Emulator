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
		
		public bool Login(string username, string pass)
		{
			bool allowed = false;

			try
			{
                allowed = factory.Login(username, pass);
				Console.WriteLine("Login() >> {0}", allowed);
			}
			catch (Exception e)
			{
				Console.WriteLine("Error while trying to Login(). {0}", e.Message);
			}

			return allowed;
		}
    }
}
