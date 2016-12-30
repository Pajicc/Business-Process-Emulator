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
        private string ime = string.Empty;
        private string name = string.Empty;
        private string criteria = string.Empty;
        private bool approved = false;
        private double startTime = 0;
        private double endTime = 0;

        public UserStory() { }
        public UserStory(string ime, string criteria, double start, double end)
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
        public double EndTime
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
        public double StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
    }
}
