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

    public class User
    {
        private int id;       
        private string username = string.Empty;
        private string password = string.Empty;
        private string email = string.Empty;
        private bool loggedIn = false;
        private double workTimeStart = 0;
        private double workTimeEnd = 0;
        private Roles role;

        public User() { }
        public User(int ID, string name, string pass, string mail, double start, double end, Roles r)
        {
            this.id = ID;
            this.username = name;
            this.password = pass;
            this.email = mail;
            this.workTimeStart = start;
            this.workTimeEnd = end;
            this.role = r;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
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
        public double WorkTimeStart
        {
            get { return workTimeStart; }
            set { this.workTimeStart = value; }
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
