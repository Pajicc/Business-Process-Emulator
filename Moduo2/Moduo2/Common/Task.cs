using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Task
    {
        private int id;
        private string nazivTask = string.Empty;

        Task() { }

        Task(string naziv)
        {
            this.nazivTask = naziv;
        }
      
        public string NazivTask
        {
            get { return nazivTask; }
            set { nazivTask = value; }
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
    }
}
