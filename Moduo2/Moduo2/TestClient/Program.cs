using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        public static TestClientProxy proxy;
        static void Main(string[] args)
        {

            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9998/CompanyService";
            proxy = new TestClientProxy(binding, new EndpointAddress(new Uri(address)));


            proxy.PartnershipRequest("PROJEKAT1");
            proxy.GetAllOutsourcingCompanies();
            Console.ReadLine();

        }
    }
}
