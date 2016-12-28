using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface ICompanyService
    {
        [OperationContract]
        User Login(string username, string pass);

        [OperationContract]
        bool AddUser(User user);

        [OperationContract]
        bool EditUser(User userMain, User editUser);
   
    }
}
