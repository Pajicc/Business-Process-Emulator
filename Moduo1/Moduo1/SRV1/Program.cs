using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;
using System.Data.Entity;
using SRV1.Access;
using log4net.Config;
using log4net;
using log4net.Appender;

namespace SRV1
{
    public class Program
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = System.IO.Path.GetDirectoryName(executable);
            path = path.Substring(0, path.LastIndexOf("bin")) + "DB";
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AccessDB, Configuration>());

            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/CompanyService";

            ServiceHost host = new ServiceHost(typeof(CompanyService));
            host.AddServiceEndpoint(typeof(ICompanyService), binding, address);

            host.Open();
            Console.WriteLine("CompanyService is opened. Press <enter> to finish...");
            log.Info("CompanyService has started working");
            
            Console.ReadLine();

            host.Close();
        }

        public void ProveravajPass()
        {

        }
    }
}
