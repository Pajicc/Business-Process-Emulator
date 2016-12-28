﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace SRV1.Access
{
    public class DB : IDB
    {
        private static IDB myDB;

        public static IDB Instance
        {
            get
            {
                if (myDB == null)
                    myDB = new DB();

                return myDB;
            }
            set
            {
                if (myDB == null)
                    myDB = value;
            }
        }

        public bool AddUser(User user)
        {
            using (var access = new AccessDB())
            {
                access.Actions.Add(user);
                int i = access.SaveChanges();

                if (i > 0)
                    return true;
                return false;
            }
        }

        public User CheckUser(string username, string pass)
        {
            using (var access = new AccessDB())
            {
                if (access.Actions.Find(username).Username == username)
                {
                    if (access.Actions.Find(username).Password == pass)
                    {
                        return access.Actions.Find(username);
                    }
                }
                
                return null;
            }
        }

        public User GetUser(string username)
        {
            using (var access = new AccessDB())
            {
                if (access.Actions.Find(username).Username == username)
                {
                    return access.Actions.Find(username);
                }

                return null;
            }
        }

        public bool EditUser(User userMain, User userEdit)
        {
            User usr = new User();

            using (var access = new AccessDB())
            {
                if (access.Actions.Find(userMain.Username).Username == userMain.Username)
                {
                    if (access.Actions.Find(userMain.Username).Password == userMain.Password)
                    {
                        access.Actions.Find(userMain.Username).Username = userEdit.Username;
                        access.Actions.Find(userMain.Username).Password = userEdit.Password;
                        access.Actions.Find(userMain.Username).Email = userEdit.Email;
                        access.Actions.Find(userMain.Username).Role = userEdit.Role;

                        int k = access.SaveChanges();

                        if (k > 0)
                            return true;
                    }
                }
            }

            return false;
        }

        public List<User> GetAllEmployees()
        {
            List<User> usrs = new List<User>();

            List<User> usrEmpl = new List<User>();

            using (var access = new AccessDB())
            {
                usrs = access.Actions.ToList();

                foreach (User uu in usrs)
                {
                    if (uu.Role == Roles.Employee)
                    {
                        usrEmpl.Add(uu);
                    }
                }

                return usrEmpl;
            }
        }

    }
}
