using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public enum Uloge
    {
        CEO = 0,
        HR = 1,
        PO = 2,
        SM = 3,
        Radnik = 4
    }

    public class User
    {
        private string username;
        private string password;
        private string email;
        private bool loggedIn = false;
        private double radnoVremePoc;
        private double radnoVremeKraj;
        private Uloge uloga;

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
        public double RadnoVremePoc
        {
            get { return radnoVremePoc; }
            set { this.radnoVremePoc = value; }
        }
        public double RadnoVremeKraj
        {
            get { return radnoVremeKraj; }
            set { this.radnoVremeKraj = value; }
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
