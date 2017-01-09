using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum Roles
    {
        CEO = 0,
        HR = 1,
        TL = 2,
        SM = 3,
        Employee = 4


    }

    public class User
    {
          
        private string username = string.Empty;
        private string password = string.Empty;
        private string name = string.Empty;
        private string lastName = string.Empty;
        private string email = string.Empty;
        private bool loggedIn = false;
        private int workTimeStarthour = 0;
        private int workTimeStartMin = 0;
        private double workTimeEnd = 0;
        private Roles role;

        public User() { }
        public User( string name, string pass, string email, int starth,int startm, double end, Roles role)
        {
            
            this.username = name;
            this.password = pass;
            this.email = email;
            this.workTimeStarthour = starth;
            this.workTimeStartMin = startm;
            this.workTimeEnd = end;
            this.role = role;
        }

        [Key]
        public string Username
        {
            get { return username; }
            set { this.username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set { this.email = value; }
        }
        public bool LoggedIn
        {
            get { return loggedIn; }
            set { this.loggedIn = value; }
        }
        public int WorkTimeStartHour
        {
            get { return workTimeStarthour; }
            set { this.workTimeStarthour = value; }
        }
        public int WorkTimeStartMin
        {
            get { return workTimeStartMin; }
            set { this.workTimeStartMin = value; }
        }
        public double WorkTimeEnd
        {
            get { return workTimeEnd; }
            set { this.workTimeEnd = value; }
        }
        public Roles Role
        {
            get { return role; }
            set { role = value; }
        }

        public void Login()
        {
            this.loggedIn = true;
        }
        public void Logout()
        {
            this.loggedIn = false;
        }
    }
}
