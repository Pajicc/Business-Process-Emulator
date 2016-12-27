using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
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

        public User CEO
        {
            get { return ceo; }
            set { ceo = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Project> Projects
        {
            get { return projects; }
            set { projects = value; }
        }


    }
}
