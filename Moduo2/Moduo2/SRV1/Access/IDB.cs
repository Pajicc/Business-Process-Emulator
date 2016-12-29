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
        bool AddUser(User user);
        User CheckUser(string username, string pass);
        User GetUser(string username);
        bool EditUser(User userMain, User userEdit);
        List<User> GetAllEmployees();
    }
}
