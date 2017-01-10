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

            ServiceHost host2 = new ServiceHost(typeof(CommonService));
            host2.AddServiceEndpoint(typeof(ICommonService), binding2, address2);

            host2.Open();
           /* User u1 = new User();
            User u2 = new User();
            u1.Name = "marko";
            u2.Name = "pera";
            List<User> usrs = new List<User>();

            usrs.Add(u1);
            usrs.Add(u2);
           
           
            
            Tim tim1 = new Tim();
            tim1.Tl = SRV2.Access.DB.Instance.GetUser("l").ToString();
            //tim1.Employees = usrs;
            tim1.NazivTima = "trimDim";
            SRV2.CompanyService.timovi.Add(tim1);*/

            Console.ReadLine();

            host.Close();
        }
    }
}
