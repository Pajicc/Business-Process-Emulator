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
        private User ceo = new User();
        private List<Project> projects = new List<Project>();

        public HiringCompany() { }
        public HiringCompany(string name, User ceo, List<Project> projects)
        {
            this.name = name;
            this.ceo = ceo;
            this.projects = projects;
        }

        [Key]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public User CEO
        {
            get { return ceo; }
            set { ceo = value; }
        }

        public List<Project> Projects
        {
            get { return projects; }
            set { projects = value; }
        }


    }
}
