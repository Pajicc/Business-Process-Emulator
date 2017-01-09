using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using SRV2.Access;

namespace SRV2
{
    public class Wcf : IWcf
    {

        static public List<string> projekti = new List<string>();
        
         
        public bool PosaljiZahtev(string naziv)
            {
          
                projekti.Add(naziv);
               
                
                return true;
            }


        public List<string> GetOCompany()
        {
            List<string> kompanije = new List<string>();
            kompanije.Add("kompanijaA");
            kompanije.Add("kompanijaB");

            return kompanije;
        }
    }
}
