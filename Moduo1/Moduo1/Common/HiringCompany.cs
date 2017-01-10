using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common
{
    [Table("HiringCompanies")]
    public class HiringCompany
    {
        private string name = string.Empty;
        private string ceo = string.Empty;
        private List<Partner> partnerCompanies = new List<Partner>();

        public HiringCompany() { }
        public HiringCompany(string name, string ceo)
        {
            this.name = name;
            this.ceo = ceo;
        }

        [Key]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string CEO
        {
            get { return ceo; }
            set { ceo = value; }
        }

        [NotMapped]
        public List<Partner> ParnterCompanies
        {
            get { return partnerCompanies; }
            set { partnerCompanies = value; }
        }
       
    }
}
