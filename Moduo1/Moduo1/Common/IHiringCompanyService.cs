﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IHiringCompanyService
    {
        [OperationContract]
        List<string> GetAllHiringCompanies();

        [OperationContract]
        bool ApproveUserStory(string usName, string usCriteria, string projectName);
    }
}
