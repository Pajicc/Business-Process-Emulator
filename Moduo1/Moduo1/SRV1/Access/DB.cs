using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using SRV1;

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

        /// <summary>
        /// Metoda za adovanje Usera u bazu
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(User user)
        {
            using (var access = new AccessDB())
            {
                access.Users.Add(user);
                
                int i = access.SaveChanges();

                if (i > 0)
                {
                    Program.log.Info("User: " + user.Username + " has been added to database!");
                    return true;
                }
                else
                {
                    Program.log.Info("Failed to add to database! User: " + user.Username);
                    return false;
                }
               
            }
        }

        /// <summary>
        /// Metoda za proveravanje Usera pri logovanju
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public User CheckUser(string username, string pass)
        {
            using (var access = new AccessDB())
            {
                if (access.Users.Find(username).Username == username)
                {
                    if (access.Users.Find(username).Password == pass)
                    {
                        access.Users.Find(username).LoggedIn = true;
                        Program.log.Info("Check username for login: " + username);
                        return access.Users.Find(username);
                    }
                }

                Program.log.Info("Check username for login failed! Username: " + username);
                return null;
            }
        }

        /// <summary>
        /// Metoda za logout
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool LogOut(string username, string pass)
        {
            using (var access = new AccessDB())
            {
                if (access.Users.Find(username).Username == username)
                {
                    access.Users.Find(username).LoggedIn = false;
                    Program.log.Info("User: " + username + " has been logged out!");
                    return true;
                }

                Program.log.Info("User: " + username + " has failed to logout!");
                return false;
            }
        }

        /// <summary>
        /// Metoda za vracanje Usera iz baze na osnovu username-a
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUser(string username)
        {
            using (var access = new AccessDB())
            {
                if (access.Users.Find(username).Username == username)
                {
                    Program.log.Info("GetUser: " + username);
                    return access.Users.Find(username);
                }

                Program.log.Info("Failed to GetUser: " + username);
                return null;
            }
        }

        /// <summary>
        /// Metoda za editovanje Usera u bazi
        /// </summary>
        /// <param name="userMain"></param>
        /// <param name="userEdit"></param>
        /// <returns></returns>
        public bool EditUser(User userMain, User userEdit)
        {
            User usr = new User();

            using (var access = new AccessDB())
            {
                if (access.Users.Find(userMain.Username).Username == userMain.Username)
                {
                    access.Users.Find(userMain.Username).Name = userEdit.Name;
                    access.Users.Find(userMain.Username).LastName = userEdit.LastName;
                    access.Users.Find(userMain.Username).Password = userEdit.Password;
                    access.Users.Find(userMain.Username).Email = userEdit.Email;
                    access.Users.Find(userMain.Username).Role = userEdit.Role;
                    access.Users.Find(userMain.Username).WorkTimeStart = userEdit.WorkTimeStart;
                    access.Users.Find(userMain.Username).WorkTimeEnd = userEdit.WorkTimeEnd;

                    

                    int k = access.SaveChanges();

                    if (k > 0)
                    {
                        Program.log.Info("User: " + userMain.Username + " has been edited!");
                        return true;
                    }
                }
            }

            Program.log.Info("User: " + userMain.Username + " wasnt edited ERROR!");
            return false;
        }

        /// <summary>
        /// Metoda koja vraca listu svih zaposlenih
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllEmployees()
        {
            List<User> usrs = new List<User>();

            List<User> usrEmpl = new List<User>();

            using (var access = new AccessDB())
            {
                usrs = access.Users.ToList();

                foreach (User uu in usrs)
                {
                    if (uu.Role == Roles.Employee)
                    {
                        usrEmpl.Add(uu);
                    }
                }

                Program.log.Info("GetAllEmployee function has been called");

                return usrEmpl;
            }
        }

        /// <summary>
        /// Metoda za kreiranje projekata i storovanja u bazi
        /// </summary>
        /// <param name="prj"></param>
        /// <returns></returns>
        public bool CreateProject(Project prj)
        {
            using (var access = new AccessDB())
            {
                User usr = access.Users.Find(prj.Po);

                prj.Po = usr.Username;

                prj.State = States.notApproved;

                access.Projects.Add(prj);

                int i = access.SaveChanges();

                if (i > 0)
                {
                    Program.log.Info("Project: " + prj.Name + " has been created by: " + usr.Username);
                    return true;
                }
                else
                {
                    Program.log.Info("Project: " + prj.Name + " has failed to be created by: " + usr.Username);
                    return false;
                }
            }
        }

        public bool UpdateProject(Project prj)
        {
            using (var access = new AccessDB())
            {
                if (access.Projects.Find(prj.Name).Name == prj.Name)
                {
                    access.Projects.Find(prj.Name).State = prj.State;       //dodati ako treba jos nesto da se izmeni

                    int k = access.SaveChanges();

                    if (k > 0)
                    {
                        Program.log.Info("Project: " + prj.Name + " has been activated!");
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Metoda za vracanje svih kreiranih projekata
        /// </summary>
        /// <returns></returns>
        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();

            using (var access = new AccessDB())
            {
                projects = access.Projects.ToList();

                Program.log.Info("GetAllProjects function has been called");

                return projects;
            }
        }

        /// <summary>
        /// Brisanje projekta iz baze
        /// </summary>
        /// <param name="proj"></param>
        /// <returns></returns>
        public bool DeleteProject(Project proj)
        {
            using (var access = new AccessDB())
            {
                List<UserStory> usdb = new List<UserStory>();
                foreach(UserStory us in access.UserStories)
                {
                    if(us.Name == proj.Name)
                    {
                        usdb.Add(us);
                    }
                }

                foreach(UserStory usrstr in usdb)
                {
                    access.UserStories.Remove(usrstr);
                }

                Project projDB = access.Projects.FirstOrDefault(f => f.Name == proj.Name);

                if (projDB != null)
                {
                    access.Projects.Remove(projDB);

                    int i = access.SaveChanges();

                    if (i > 0)
                    {
                        Program.log.Info("Project: " + projDB.Name + " is deleted");
                        return true;
                    } 
                }

                Program.log.Info("Failed to delete Project: " + projDB.Name);
                return false;
            }
        }
        /*
        public bool SetUserStory(List<UserStory> us)
        {
            using (var access = new AccessDB())
            {
                foreach (UserStory story in us)
                {
                    access.UserStories.Add(story);
                }
          
                Program.log.Info("SetUserStory function has been called");

                int i = access.SaveChanges();

                if (i > 0)
                    return true;
                return false;
            }
        }
         */

        public bool AddHiringCompany(HiringCompany hc)
        {
            using (var access = new AccessDB())
            {
                access.HiringCompanies.Add(hc);

                int i = access.SaveChanges();

                if (i > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<string> GetAllParnterCompanies(string username)
        {
            List<string> companies = new List<string>();

            using (var access = new AccessDB())
            {
                List<UserStory> usdb = new List<UserStory>();
                foreach (HiringCompany hc in access.HiringCompanies)
                {
                    if (hc.CEO.Username == username)
                    {
                        companies.Add(hc.Name);
                    }
                }             
            }
            return companies;
        }

        public bool AddParnterCompany(string ceo, string partner)
        {
            using (var access = new AccessDB())
            {
                foreach (HiringCompany hc in access.HiringCompanies)
                {
                    if (hc.CEO.Name == ceo)
                    {
                        if(!hc.ParnterCompanies.Contains(partner))
                            access.HiringCompanies.Find(hc.Name).ParnterCompanies.Add(partner);

                        int k = access.SaveChanges();

                        if(k > 0)
                            return true;
                    }
                }     
            }

            return false;
        }
    }
}
