using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


using Common;namespace TestClient
{  
    
    public class TestClientProxy : ChannelFactory<ICommonService>, ICommonService, IDisposable
    {
         ICommonService factory;
         List<string> kompanije = new List<string>();


         public TestClientProxy(NetTcpBinding binding, EndpointAddress address)
            : base(binding, address)
        {
            factory = this.CreateChannel();
        }

         public bool PartnershipRequest(string naziv)
        {
            try
            {
                factory.PartnershipRequest(naziv);
                Console.WriteLine("test");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to Login(). {0}", e.Message);
            }
            return true;

        }


        public List<string> GetAllOutsourcingCompanies()
        {
            try
            {
               
                kompanije= factory.GetAllOutsourcingCompanies();
                for (int i = 0; i < kompanije.Count;i++ )
                    Console.WriteLine(kompanije[i]+"\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to Login(). {0}", e.Message);
            }
            return kompanije;
           
        }


        public void SendProject(Project projekat)
        {
            try
            {
                factory.SendProject(projekat);
                Console.WriteLine("Projekat");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while trying to Login(). {0}", e.Message);
            }
            
        }
    }
}
