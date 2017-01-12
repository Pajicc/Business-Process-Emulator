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

        public HiringCompany() { }
        public HiringCompany(string name)
        {
            this.name = name;
        }

        [Key]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
