using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        private string projekat = string.Empty;
        private int tezina = 0;
        private string task1 = string.Empty;
        private string task2 = string.Empty;
        private string task3 = string.Empty;
        private bool closed = false;
        private bool task1_done = false;
        private bool task2_done = false;
        private bool task3_done = false;


        public UserStory() { }

        public UserStory(string name, string criteria, DateTime start, DateTime end,string task1,string task2, string task3 , int tezina,string pro)
        {
            this.name = name;
            this.criteria = criteria;
            this.startTime = start;
            this.endTime = end;
            this.tezina = tezina;
            this.projekat = pro;
            this.task1 = task1;
            this.task2 = task2;
            this.task3 = task3;
 
        }


        public bool Task1_done
        {
            get { return task1_done; }
            set { task1_done = value; }
        }

        public bool Task2_done
        {
            get { return task2_done; }
            set { task2_done = value; }
        }

        public bool Task3_done
        {
            get { return task3_done; }
            set { task3_done = value; }
        }

         public bool Closed
        {
            get { return closed; }
            set { closed = value; }
        }

        public int Tezina
        {
            get { return tezina; }
            set { tezina = value; }
        }

        public string Task1
        {
            get { return task1; }
            set { task1 = value; }
        }
        public string Task2
        {
            get { return task2; }
            set { task2 = value; }
        }
        public string Task3
        {
            get { return task3; }
            set { task3 = value; }
        }
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        [Key]
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

        public string Projekat
        {
            get { return projekat; }
            set { projekat = value; }
        }
    }
}
