using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Tim
    {
        private List<User> employees = new List<User>();

        private string nazivTima;
      
        private User tl = new User();

        public User Tl
        {
            get { return tl; }
            set { tl = value; }
        }

        public List<User> Employees
        {
            get { return employees; }
            set { employees = value; }
        }

        public string NazivTima
        {
            get { return nazivTima; }
            set { nazivTima = value; }
        }
        
    }
}
