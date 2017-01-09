﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using SRV2.Access;

namespace SRV2
{
    public class CompanyService : ICompanyService
    {
        static public List<User> onlineUsers = new List<User>();
        static public List<OutsourcingCompany> outsrc = new List<OutsourcingCompany>();
        static public List<Tim> timovi = new List<Tim>();
        



        public User Login(string username, string pass)
        {
            Console.WriteLine("Username: " + username + "\nPassword: " + pass);

            User u = new User();
            u = DB.Instance.CheckUser(username, pass);

            u.LoggedIn = true;

            if (u != null)
            {
                onlineUsers.Add(u);
                return u;
            }
            else
                return null;
        }

        public bool LogOut(string username, string pass)
        {
            bool done = false;
            Console.WriteLine("User: " + username + " is now logged out.");

            User u = new User();
            u = DB.Instance.CheckUser(username, pass);

            u.LoggedIn = false;

            done = DB.Instance.LogOut(username, pass);

            if (done)
            {
                onlineUsers.Remove(u);
            }

            return done;
        }

        public bool AddUser(User user)
        {
            bool done = false;

            Console.WriteLine("Dodat nov User!");
            Console.WriteLine("Username: " + user.Username + "\nPassword: " + user.Password);

            done = DB.Instance.AddUser(user);

            return done;
        }

        public bool EditUser(User userMain, User editUser)
        {
            bool done = false;

            Console.WriteLine("Editovan User!");
            Console.WriteLine("Username: " + editUser.Username + "\nPassword: " + editUser.Password);

            done = DB.Instance.EditUser(userMain, editUser);

            return done;
        }

        public List<User> GetAllEmployees()
        {
            Console.WriteLine("Ucitana lista Usera!");

            List<User> lista = new List<User>();

            lista = DB.Instance.GetAllEmployees();

            return lista;
        }

        public List<string> GetCompanyes()
        {
            Console.WriteLine("Getcoomp() ok!");

            List<string> lista = SRV2.Wcf.kompanije;

            

            return lista;
        }

        public User GetUser(string username)
        {
            Console.WriteLine("GetUsername: " + username);

            User u = new User();
            u = DB.Instance.GetUser(username);

            if (u != null)
                return u;
            else
                return null;
        }

        public List<User> GetOnlineUsers()
        {
            Console.WriteLine("Pozvana funkcija za GetOnlineUsers!");

            return onlineUsers;
        }


        public List<Tim> GetAllTims()
        {
            Console.WriteLine("GetAllTims() ok!");

            return timovi;
        }
    }
}
