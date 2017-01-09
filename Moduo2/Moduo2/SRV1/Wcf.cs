using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using SRV2.Access;
using System.Windows.Forms;

namespace SRV2
{
    public class Wcf : ICommonService
    {

        static public List<string> kompanije = new List<string>();


        public bool PartnershipRequest(string naziv)
            {
          
             //   projekti.Add(naziv);
                kompanije.Add(naziv);
                DialogResult result = MessageBox.Show("Da li zelite da prihvatite partnerstvo?", "Warning",
 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    return true;
                }
                else if (result == DialogResult.No)
                {
                    return false;
                }
                else if (result == DialogResult.Cancel)
                {
                    return false;
                }
                return false;
            }


        public List<string> GetAllOutsourcingCompanies()
        {
            List<string> kompanije = new List<string>();
            kompanije.Add("kompanijaA");
            kompanije.Add("kompanijaB");

            return kompanije;
        }
    }
}
