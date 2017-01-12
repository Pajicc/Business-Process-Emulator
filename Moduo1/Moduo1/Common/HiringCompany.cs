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
        private string name;
        private string ceo;
        private string sm;

        public HiringCompany() { }
        public HiringCompany(string name, string ceo, string sm)
        {
            this.name = name;
            this.ceo = ceo;
            this.sm = sm;
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

        public string SM
        {
            get { return sm; }
            set { sm = value; }
        }
    }
}
