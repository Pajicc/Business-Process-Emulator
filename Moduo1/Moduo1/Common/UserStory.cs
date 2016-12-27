using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class UserStory
    {
        private string name = string.Empty;
        private string criteria = string.Empty;
        private double startTime = 0;
        private double endTime = 0;

        public UserStory() { }
        public UserStory(string name, string criteria, double start, double end)
        {
            this.name = name;
            this.criteria = criteria;
            this.startTime = start;
            this.endTime = end;
        }

        public double EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
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
