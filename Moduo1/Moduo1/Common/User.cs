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
        PO = 2,
        SM = 3,
        Employee = 4
    }

    [Table("Users")]
    public class User
    {
        private string username;
        private string password;
        private string name;
        private string lastName;
        private string email;
        private bool loggedIn = false;
        private string workTimeStart;
        private string workTimeEnd;
        private Roles role;

        public User() { }
        public User(string name, string pass, string mail, string start, string end, Roles r)
        {
            this.username = name;
            this.password = pass;
            this.email = mail;
            this.workTimeStart = start;
            this.workTimeEnd = end;
            this.role = r;
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
        public string WorkTimeStart
        {
            get { return workTimeStart; }
            set { this.workTimeStart = value; }
        }
        public string WorkTimeEnd
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
