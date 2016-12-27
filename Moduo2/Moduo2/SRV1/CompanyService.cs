using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using SRV2.Access;

namespace SRV2
{
    public class CompanyService : ICompanyService
    {
        public bool Login(string username, string pass)
        {
            //Console.WriteLine("Username: "+username+"\nPassword: "+pass);

            
           /* if (DB.Instance.CheckUser(username, pass))
            {
                Console.WriteLine("Username: " + username + "\nPassword: " + pass);
                return true;
            }*/
            
            
            DB.Instance.AddUser(new User
            {
                Username = username,
                Password = pass,
            });
             
            

            return false;

        }

    }
}
