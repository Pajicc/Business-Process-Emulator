using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common
{
    public class Tim
    {
        

        private string nazivTima;
        private User tl = new User();
        private User employee1 = new User();
        private User employee2 = new User();
        private User employee3 = new User();


        public User Tl
        {
            get { return tl; }
            set { tl = value; }
        }

       

        [Key]
        public string NazivTima
        {
            get { return nazivTima; }
            set { nazivTima = value; }
        }

        public User Employee1
        {
            get { return employee1; }
            set { employee1 = value; }
        }

        public User Employee2
        {
            get { return employee2; }
            set { employee2 = value; }
        }

        public User Employee3
        {
            get { return employee3; }
            set { employee3 = value; }
        }
        
    }
}
