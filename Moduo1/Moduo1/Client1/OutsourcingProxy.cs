using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client1
{
    public class OutsourcingProxy : ChannelFactory<IOutsourcingCompanyService>, IOutsourcingCompanyService, IDisposable
    {
        IOutsourcingCompanyService factory;

        public OutsourcingProxy(NetTcpBinding binding, EndpointAddress address)
            : base(binding, address)
        {
            factory = this.CreateChannel();
        }

        public bool PartnershipRequest(string company)
        {
            bool allowed = false;

            try
            {
                allowed = factory.PartnershipRequest(company);
                Console.WriteLine("PartnershipRequest() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to PartnershipRequest(). {0}", e.Message);
            }

            return allowed;
        }

        public List<string> GetAllOutsourcingCompanies()
        {
            List<string> companies = new List<string>();

            try
            {
                companies = factory.GetAllOutsourcingCompanies();
                Console.WriteLine("GetAllOutsourcingCompanies() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to GetAllOutsourcingCompanies(). {0}", e.Message);
            }

            return companies;
        }

        public bool SendProject(string name, string desc, string company)
        {
            bool allowed = false;

            try
            {
                allowed = factory.SendProject(name, desc, company);
                Console.WriteLine("SendProject() >> succeded");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to SendProject(). {0}", e.Message);
            }
            return allowed;
        }
    }
}
