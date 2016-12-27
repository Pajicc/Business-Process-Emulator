using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace SRV2.Access
{
    public interface IDB
    {
        bool AddUser(User action);
        bool CheckUser(string username, string pass);
        bool EditUser(string username, string pass);
    }
}
