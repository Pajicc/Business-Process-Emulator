using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface ICommonService
    {
        [OperationContract]
        bool PartnershipRequest(string company);

        [OperationContract]
        List<string> GetAllOutsourcingCompanies();

        [OperationContract]
        bool SendProject(Project p);
    }
}
