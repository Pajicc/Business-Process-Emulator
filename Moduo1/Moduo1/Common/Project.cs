using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common
{
    [Table("Projects")]
    public class Project
    {
        private string name;
        private string description;
        private string startTime;
        private string endTime;
        private bool active = false;
        private string po;
        private List<UserStory> userStories = new List<UserStory>();

        public Project() { }
        public Project(string name, string desc, string start, string end, string po, List<UserStory> userStories)
        {
            this.name = name;
            this.description = desc;
            this.startTime = start;
            this.endTime = end;
            this.po = po;
            this.userStories = userStories;
        }

        [Key]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public string Po
        {
            get { return po; }
            set { po = value; }
        }

        //[Compare("UserStories")]
        public List<UserStory> UserStories
        {
            get { return userStories; }
            set { userStories = value; }
        }
    }
}
