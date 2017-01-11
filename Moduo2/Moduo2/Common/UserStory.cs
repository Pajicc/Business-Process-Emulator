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
        private DateTime startTime = new DateTime();
        private DateTime endTime = new DateTime();
        private List<Task> tasks = new List<Task>();
        private int tezina = 0;

        public UserStory() { }
        public UserStory(string name, string criteria, DateTime start, DateTime end, List<Task> lista, int tezina)
        {
            this.name = name;
            this.criteria = criteria;
            this.startTime = start;
            this.endTime = end;
            this.tezina = tezina;
          
        }

     
        public  List<Task> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }
       

        public int Tezina
        {
            get { return tezina; }
            set { tezina = value; }
        }
        
        

        public DateTime EndTime
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
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
    }
}
