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
        private string ime;
        private string name;
        private string criteria;
        private bool approved;
        private string startTime;
        private string endTime;

        public UserStory() { }
        public UserStory(string ime, string criteria, string start, string end)
        {
            this.ime = ime;
            this.criteria = criteria;
            this.startTime = start;
            this.endTime = end;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        public bool Approved
        {
            get { return approved; }
            set { approved = value; }
        }
        public string Criteria
        {
            get { return criteria; }
            set { criteria = value; }
        }
        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
    }
}
