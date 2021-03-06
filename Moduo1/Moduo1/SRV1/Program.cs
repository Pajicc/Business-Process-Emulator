﻿using System;
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
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static ILog Log
        {
            get
            {
                return log;
            }

        }

        public static void Main(string[] args)
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = System.IO.Path.GetDirectoryName(executable);
            path = path.Substring(0, path.LastIndexOf("bin")) + "DB";
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AccessDB, Configuration>());

            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/CompanyService";
            NetTcpBinding binding2 = new NetTcpBinding();
            string address2 = "net.tcp://localhost:8888/CompanyService";


            ServiceHost host = new ServiceHost(typeof(CompanyService));
            host.AddServiceEndpoint(typeof(ICompanyService), binding, address);           

            ServiceHost host2 = new ServiceHost(typeof(CompanyService));
            host2.AddServiceEndpoint(typeof(IHiringCompanyService), binding2, address2);

            host.Open();
            host2.Open();

            Console.WriteLine("CompanyService is opened. Press <enter> to finish...");
            Log.Info("CompanyService has started working");

            //addovanje CEO i HiringCompanies
            /*List<User> users = new List<User>();

            User test = new User("test", "test", "test@li.com", "09:00:00", "12:00:00", Roles.CEO, "HiringCompany1");
            users.Add(test);
            User ceo1 = new User("ceo1", "ceo1", "mail1@li.com", "09:00:00", "12:00:00", Roles.CEO, "HiringCompany1");
            users.Add(ceo1);
            User ceo2 = new User("ceo2", "ceo2", "mail2@li.com", "09:00:00", "12:00:00", Roles.CEO, "HiringCompany2");
            users.Add(ceo2);
            User ceo3 = new User("ceo3", "ceo3", "mail3@li.com", "09:00:00", "12:00:00", Roles.CEO, "HiringCompany3");
            users.Add(ceo3);

            User po1 = new User("po1", "po1", "po1@li.com", "09:00:00", "12:00:00", Roles.PO, "HiringCompany1");
            users.Add(po1);
            User po2 = new User("po2", "po2", "po2@li.com", "09:00:00", "12:00:00", Roles.PO, "HiringCompany1");
            users.Add(po2);

            User hr1 = new User("hr1", "hr1", "hr1@li.com", "09:00:00", "12:00:00", Roles.HR, "HiringCompany1");
            users.Add(hr1);
            User hr2 = new User("hr2", "hr2", "hr2@li.com", "09:00:00", "12:00:00", Roles.HR, "HiringCompany2");
            users.Add(hr2);
            User hr3 = new User("hr3", "hr3", "hr3@li.com", "09:00:00", "12:00:00", Roles.HR, "HiringCompany3");
            users.Add(hr3);

            User sm1 = new User("sm1", "sm1", "sm1@li.com", "09:00:00", "12:00:00", Roles.SM, "HiringCompany1");
            users.Add(sm1);
            User sm2 = new User("sm2", "sm2", "sm2@li.com", "09:00:00", "12:00:00", Roles.SM, "HiringCompany2");
            users.Add(sm2);

            User user1 = new User("user1", "user1", "user1@li.com", "09:00:00", "12:00:00", Roles.Employee, "HiringCompany1");
            users.Add(user1);
            User user2 = new User("user2", "user2", "user2@li.com", "09:00:00", "12:00:00", Roles.Employee, "HiringCompany2");
            users.Add(user2);

            HiringCompany hc1 = new HiringCompany("HiringCompany1");
            HiringCompany hc2 = new HiringCompany("HiringCompany2");
            HiringCompany hc3 = new HiringCompany("HiringCompany3");

            using (var access = new AccessDB())
            {
                if (access.Users.Count<User>() == 0)
                {
                    foreach (User us in users)
                    {
                        DB.Instance.AddUser(us);
                    }

                    DB.Instance.AddHiringCompany(hc1);
                    DB.Instance.AddHiringCompany(hc2);
                    DB.Instance.AddHiringCompany(hc3);

                    Console.WriteLine("Uspesno popunjena baza!");
                }
            }*/

            Console.ReadLine();

            host.Close();
        }
    }
}
