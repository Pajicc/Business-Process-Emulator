using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Project
    {
        private string name = string.Empty;    
        private string description = string.Empty;        
        private double startTime = 0;
        private double endTime = 0;
        private bool active = false;
        private User po = new User();
        private List<UserStory> userStories = new List<UserStory>();

        public Project() { }
        public Project(string name, string desc, double start, double end, User po, List<UserStory> userStories)
        {
            this.name = name;
            this.description = desc;
            this.startTime = start;
            this.endTime = end;
            this.po = po;
            this.userStories = userStories;
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public double StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        public double EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        public User Po
        {
            get { return po; }
            set { po = value; }
        }
        public List<UserStory> UserStories
        {
            get { return userStories; }
            set { userStories = value; }
        }
    }
}
