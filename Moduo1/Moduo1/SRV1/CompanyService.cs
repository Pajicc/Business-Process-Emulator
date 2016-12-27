using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using SRV1.Access;

namespace SRV1
{
    public class CompanyService : ICompanyService
    {
        public User Login(string username, string pass)
        {
            Console.WriteLine("Username: " + username + "\nPassword: " + pass);

            User u = new User();
            u = DB.Instance.CheckUser(username, pass);

            if (u != null)
                return u;
            else
                return null;

        }

    }
}
