using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace SRV1
{
    public class CompanyService : ICompanyService
    {
        public bool Login(string username, string pass)
        {
            Console.WriteLine("Usao u login");
            return true;

        }

    }
}
