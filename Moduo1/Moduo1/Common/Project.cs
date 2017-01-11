using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common
{
    public enum States
    {
        approved = 0,
        notApproved = 1,
        inProgress = 2,
        finished = 3
    }

    [Table("Projects")]
    public class Project
    {
        private string name;
        private string description;
        private string startTime;
        private string endTime;
        private States state;
        private string po;
        private string hiringCompany;

        public Project() { }
        public Project(string name, string desc, string start, string end, string po)
        {
            this.name = name;
            this.description = desc;
            this.startTime = start;
            this.endTime = end;
            this.po = po;
        }

        [Key]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public States State
        {
            get { return state; }
            set { state = value; }
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

        public string HiringCompany
        {
            get { return hiringCompany; }
            set { hiringCompany = value; }
        }
    }
}
