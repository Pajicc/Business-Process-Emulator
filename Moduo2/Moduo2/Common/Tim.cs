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
        private string tl = string.Empty;
        private string employee1 = string.Empty;
        private string employee2 = string.Empty;
        private string employee3 = string.Empty;


        public string Tl
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

        public string Employee1
        {
            get { return employee1; }
            set { employee1 = value; }
        }

        public string Employee2
        {
            get { return employee2; }
            set { employee2 = value; }
        }

        public string Employee3
        {
            get { return employee3; }
            set { employee3 = value; }
        }
        
    }
}
