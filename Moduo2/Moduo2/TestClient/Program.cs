using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;
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


            proxy.PartnershipRequest("komp1");
            proxy.GetAllOutsourcingCompanies();
           
            Project projekat1 = new Project();
            projekat1.Name = "projekat1";
            projekat1.Description = " pafsd;klfj;sdalj";
            projekat1.StartTime = 12.23;
            projekat1.EndTime = 12.27;
            proxy.SendProject(projekat1);


            

            Console.ReadLine();

        }
    }
}
