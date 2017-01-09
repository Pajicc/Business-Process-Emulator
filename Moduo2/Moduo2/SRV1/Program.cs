using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;

namespace SRV2
{
    class Program
    {
        static void Main(string[] args)
        {
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/CompanyService";

            ServiceHost host = new ServiceHost(typeof(CompanyService));
            host.AddServiceEndpoint(typeof(ICompanyService), binding, address);

            host.Open();
            Console.WriteLine("CompanyService is opened. Press <enter> to finish...");

            NetTcpBinding binding2 = new NetTcpBinding();
            string address2 = "net.tcp://localhost:9998/CompanyService";

            ServiceHost host2 = new ServiceHost(typeof(Wcf));
            host2.AddServiceEndpoint(typeof(IWcf), binding2, address2);

            host2.Open();

           

            Console.ReadLine();

            host.Close();
        }
    }
}
