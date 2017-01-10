using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace SRV2.Access
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

        public bool AddProject(Project project)
        {
            using (var access = new AccessDB())
            {
                access.Actions2.Add(project);
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
                        access.Actions.Find(username).LoggedIn = true;
                        int i = access.SaveChanges();
                        return access.Actions.Find(username);
                    }
                }

                return null;
            }
        }

        public bool LogOut(string username, string pass)
        {
            using (var access = new AccessDB())
            {
                if (access.Actions.Find(username).Username == username)
                {
                    access.Actions.Find(username).LoggedIn = false;
                    int i = access.SaveChanges();
                    return true;
                }

                return false;
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
                    access.Actions.Find(userMain.Username).Name = userEdit.Name;
                    access.Actions.Find(userMain.Username).LastName = userEdit.LastName;
                    access.Actions.Find(userMain.Username).Password = userEdit.Password;
                    access.Actions.Find(userMain.Username).Email = userEdit.Email;
                    access.Actions.Find(userMain.Username).Role = userEdit.Role;
                    access.Actions.Find(userMain.Username).WorkTimeStartHour = userEdit.WorkTimeStartHour;
                    access.Actions.Find(userMain.Username).WorkTimeStartMin = userEdit.WorkTimeStartMin;
                    access.Actions.Find(userMain.Username).WorkTimeEnd = userEdit.WorkTimeEnd;

                    int k = access.SaveChanges();

                    if (k > 0)
                        return true;

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
                    if (uu.LoggedIn==true)
                    {
                        usrEmpl.Add(uu);
                    }
                }

                return usrEmpl;
            }
        }


        public List<Project> GetAllProjects()
        {
            List<Project> proj = new List<Project>();

            List<Project> projlist = new List<Project>();

            using (var access = new AccessDB())
            {
                proj = access.Actions2.ToList();

                foreach (Project uu in proj)
                {
                    
                    
                        projlist.Add(uu);
                    
                }

                return projlist;
            }
        }

        public bool AddTeam(Tim tim)
        {
            using (var access = new AccessDB())
            {
                access.Actions3.Add(tim);
                int i = access.SaveChanges();

                if (i > 0)
                    return true;
                return false;
            }
        }

    }
}
