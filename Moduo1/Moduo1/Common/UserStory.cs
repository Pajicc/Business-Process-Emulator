using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common
{
    [Table("UserStories")]
    public class UserStory
    {
        private int id;
        private string name;
        private string project;
        private string criteria;

        public UserStory() { }
        public UserStory(string name, string criteria)
        {
            this.name = name;
            this.criteria = criteria;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Project
        {
            get { return project; }
            set { project = value; }
        }    
        public string Criteria
        {
            get { return criteria; }
            set { criteria = value; }
        }
    }
}
