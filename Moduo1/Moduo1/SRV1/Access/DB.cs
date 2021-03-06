﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using SRV1;
using System.Windows.Forms;

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
                {
                    myDB = new DB();
                }

                return myDB;
            }
            set
            {
                if (myDB == null)
                {
                    myDB = value;
                }
            }
        }

        /// <summary>
        /// Metoda za adovanje Usera u bazu
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(User user)
        {
            DateTime registerTime = DateTime.Now;

            using (var access = new AccessDB())
            {
                user.Passeditime = registerTime.ToString();
                access.Users.Add(user);

                int i = access.SaveChanges();

                if (i > 0)
                {
                    Program.Log.Info("User: " + user.Username + " has been added to database!");
                    return true;
                }
                else
                {
                    Program.Log.Info("Failed to add to database! User: " + user.Username);
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
        public bool Login(string username, string pass)
        {
            using (var access = new AccessDB())
            {
                if (access.Users.Find(username).Username == username)
                {
                    if (access.Users.Find(username).Password == pass)
                    {
                        if (access.Users.Find(username).LoggedIn != true)
                        {
                            access.Users.Find(username).LoggedIn = true;

                            access.SaveChanges();

                            Program.Log.Info("Check username for login: " + username);
                            //return access.Users.Find(username);
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("You are already logged in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Wrong password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Username doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Program.Log.Info("Check username for login failed! Username: " + username);
                //return null;
                return false;
            }
        }

        /// <summary>
        /// Metoda za logout
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool LogOut(string username)
        {
            using (var access = new AccessDB())
            {
                if (access.Users.Find(username).Username == username)
                {
                    access.Users.Find(username).LoggedIn = false;

                    access.SaveChanges();

                    Program.Log.Info("User: " + username + " has been logged out!");
                    return true;
                }

                Program.Log.Info("User: " + username + " has failed to logout!");
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
            using (AccessDB context = new AccessDB())
            {

                User user = context.Users.FirstOrDefault((x) => x.Username == username);
                if (user != null)
                {
                    Program.Log.Info("GetUser succeded: " + username);

                    return user;
                }
            }
            Program.Log.Info("Failed to GetUser: " + username);
            return null;
 
        }

        /// <summary>
        /// Metoda za editovanje Usera u bazi
        /// </summary>
        /// <param name="userMain"></param>
        /// <param name="userEdit"></param>
        /// <returns></returns>
        public bool EditUser(User userEdit)
        {
            User usr = new User();

            using (var access = new AccessDB())
            {
                if (access.Users.Find(userEdit.Username).Username == userEdit.Username)
                {
                    access.Users.Find(userEdit.Username).Name = userEdit.Name;
                    access.Users.Find(userEdit.Username).LastName = userEdit.LastName;
                    access.Users.Find(userEdit.Username).Password = userEdit.Password;
                    access.Users.Find(userEdit.Username).Email = userEdit.Email;
                    access.Users.Find(userEdit.Username).Role = userEdit.Role;
                    access.Users.Find(userEdit.Username).WorkTimeStart = userEdit.WorkTimeStart;
                    access.Users.Find(userEdit.Username).WorkTimeEnd = userEdit.WorkTimeEnd;

                    int k = access.SaveChanges();

                    if (k > 0)
                    {
                        Program.Log.Info("User: " + userEdit.Username + " has been edited!");
                        return true;
                    }
                }
            }

            Program.Log.Info("User: " + userEdit.Username + " wasnt edited ERROR!");
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

                Program.Log.Info("GetAllEmployee function has been called");

                return usrEmpl;
            }
        }

        public List<User> GetAllOnlineUsers()
        {
            List<User> usrs = new List<User>();

            List<User> usrOn = new List<User>();

            using (var access = new AccessDB())
            {
                usrs = access.Users.ToList();

                foreach (User uu in usrs)
                {
                    if (uu.LoggedIn == true)
                    {
                        usrOn.Add(uu);
                    }
                }

                Program.Log.Info("GetAllOnlineUsers function has been called");

                return usrOn;
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

                prj.NotifikovanSM = true;           

                access.Projects.Add(prj);

                int i = access.SaveChanges();

                if (i > 0)
                {
                    Program.Log.Info("Project: " + prj.Name + " has been created by: " + usr.Username);
                    return true;
                }
                else
                {
                    Program.Log.Info("Project: " + prj.Name + " has failed to be created by: " + usr.Username);
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
                    access.Projects.Find(prj.Name).State = prj.State;                     //dodati ako treba jos nesto da se izmeni
                    access.Projects.Find(prj.Name).HiringCompany = prj.HiringCompany;
                    access.Projects.Find(prj.Name).NotifikovanSM = prj.NotifikovanSM;

                    int k = access.SaveChanges();

                    if (k > 0)
                    {
                        Program.Log.Info("Project: " + prj.Name + " has been activated!");
                        return true;
                    }
                    else
                    {
                        Program.Log.Info("Project: " + prj.Name + "failed to update!");
                        return false;
                    }
                }
                return false;
            }
        }

        public bool UpdateProject2(Procent procent)
        {
            using (var access = new AccessDB())
            {
                if (access.Projects.Find(procent.ImeProj).Name == procent.ImeProj)
                {
                    access.Projects.Find(procent.ImeProj).NotifikovanSM = false;
                    access.Projects.Find(procent.ImeProj).Percent = procent.Procenat;

                    int k = access.SaveChanges();

                    if (k > 0)
                    {
                        Program.Log.Info("Project: " + procent.ImeProj + " has been updated2!");
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Metoda za vracanje svih kreiranih projekata
        /// </summary>
        /// <returns></returns> }        
        public List<Project> GetAllProjectsForUser(User user)
        {
            List<Project> projects = new List<Project>();

            using (var access = new AccessDB())
            {
                foreach (Project p in access.Projects)
                {
                    if (user.Username == p.Po)
                    {
                        projects.Add(p);
                    }
                    else
                    {
                        if (p.HiringCompany == user.Company)
                        {
                            projects.Add(p);
                        }
                    }
                    
                }

                Program.Log.Info("GetAllProjects function has been called");

                return projects;
            }
        }


        public List<Project> GetAllProjects()
        {
            List<Project> projects = new List<Project>();

            using (var access = new AccessDB())
            {
                foreach (Project p in access.Projects)
                {
                    projects.Add(p);
                }
                Program.Log.Info("GetAllProjects function has been called");

                return projects;
            }
        }

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

        public List<string> GetAllPartnerCompanies(User user)
        {
            List<string> partCompanies = new List<string>();

            using (var access = new AccessDB())
            {           
                foreach (Partner part in access.Partners)
                {
                    if (part.ImeHiringKompanije == user.Company)
                    {
                        partCompanies.Add(part.ImeOutKompanije);
                    }
                }

                return partCompanies;
            }
        }

        public bool AddPartnerCompany(User user, string partner)
        {
            using (var access = new AccessDB())
            {
                Partner part1 = new Partner(user.Company, partner);
                access.Partners.Add(part1);

                int k = access.SaveChanges();

                if (k > 0)
                {
                    return true;
                }           
            }

            return false;
        }
       
        public bool ChangePass(string username, string oldPass, string newPass)
        {
            DateTime currentTime = DateTime.Now;

            using (var access = new AccessDB())
            {
                if (access.Users.Find(username).Password == oldPass)
                {
                    access.Users.Find(username).Password = newPass;
                    access.Users.Find(username).Passeditime = currentTime.ToString();

                    int k = access.SaveChanges();

                    if (k > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public List<string> GetAllHiringCompanies()
        {
            List<string> hiringCompanies = new List<string>();

            using (var access = new AccessDB())
            {
                foreach (HiringCompany hc in access.HiringCompanies)
                {
                    hiringCompanies.Add(hc.Name);
                }

                return hiringCompanies;
            }
        }

        public bool AddUserStory(string usName, string usCriteria, string projectName)
        {
            using (var access = new AccessDB())
            {
                UserStory us = new UserStory();
                us.Name = usName;
                us.Criteria = usCriteria;
                us.Project = projectName;

                access.UserStories.Add(us);

                int k = access.SaveChanges();

                if (k > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public List<string> GetAllUserStories(Project proj)
        {
            List<string> userStories = new List<string>();

            using (var access = new AccessDB())
            {
                foreach (UserStory us in access.UserStories)
                {
                    if (us.Project == proj.Name)
                    {
                        userStories.Add(us.Name);
                    }
                }

                return userStories;
            }
        }
    }
}
