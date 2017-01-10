using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common
{
    public class Project
    {
        private string name = string.Empty;    
        private string description = string.Empty;        
        private double startTime = 0;
        private double endTime = 0;
        private string kompanija = string.Empty;
        private string tim=string.Empty;
      //  private User tl = new User();
      //  private List<UserStory> userStories = new List<UserStory>();
      //  private Tim tim = new Tim();
        private int tezina = 0;
      //  private List<string> tasks = new List<string>();
        
       


        public Project() { }
        public Project(string name, string desc, double start, double end, User po, List<UserStory> userStories)
        {
            this.name = name;
            this.description = desc;
            this.startTime = start;
            this.endTime = end;
           // this.tl = po;
           // this.userStories = userStories;
        }
        [Key]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
       
        public string Kompanija
        {
            get { return kompanija; }
            set { kompanija = value; }
        }

         public string Tim
        {
            get { return tim; }
            set { tim = value; }
        }

       /* public List<string> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }*/

       /* public Tim Tim
        {
            get { return tim; }
            set { tim = value; }
        }*/

        public int  Tezina
        {
            get { return tezina; }
            set { tezina = value; }
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
        /*public User Tl
        {
            get { return tl; }
            set { tl = value; }
        }*/
       /* public List<UserStory> UserStories
        {
            get { return userStories; }
            set { userStories = value; }
        }*/
    }
}
