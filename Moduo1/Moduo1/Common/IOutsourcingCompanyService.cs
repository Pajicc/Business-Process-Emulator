using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IOutsourcingCompanyService
    {
        [OperationContract]
        bool PartnershipRequest(string company);

        [OperationContract]
        List<string> GetAllOutsourcingCompanies();

        [OperationContract]
        bool SendProject(string name, string desc, string company);
    }
}
