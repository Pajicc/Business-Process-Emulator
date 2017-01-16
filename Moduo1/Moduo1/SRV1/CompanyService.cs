using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using SRV1.Access;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using SRV1;

namespace SRV1
{
    public class CompanyService : ICompanyService, IHiringCompanyService
    {
        public bool Login(string username, string pass)
        { 
            Program.Log.Info("Login method from CompanyService called");

            if (DB.Instance.Login(username, pass))
            {
                User u = DB.Instance.GetUser(username);

                DateTime dt = DateTime.Now;
                if (CheckIfLate(dt, u.WorkTimeStart))
                {
                    MessageBox.Show("You are late for work!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Program.Log.Info("User: " + username + " Has been loggedIn!");
                return true;
            }
            else
            {
                Program.Log.Info("Failed login! User: " + username);
                return false;
            }

        }

        public bool LogOut(string username)
        {
            Program.Log.Info("Logout method from CompanyService called");
            return DB.Instance.LogOut(username);
        }

        public bool AddUser(User user)
        {
            Program.Log.Info("AddUser method from CompanyService called");
            return DB.Instance.AddUser(user);
        }

        public List<User> GetAllOnlineUsers()
        {
            Program.Log.Info("GetAllOnlineUsers method from CompanyService called");
            return DB.Instance.GetAllOnlineUsers();
        }

        public bool EditUser(User editUser)
        {
            Program.Log.Info("EditUser method from CompanyService called");
            return DB.Instance.EditUser(editUser);
        }

        public List<User> GetAllEmployees()
        {
            Program.Log.Info("GetAllEmployees method from CompanyService called");
            return DB.Instance.GetAllEmployees(); 
        }

        public User GetUser(string username)
        {
            Program.Log.Info("GetUser method from CompanyService called");
            return DB.Instance.GetUser(username); 
        }

        public bool CreateProject(Project prj)
        {
            Program.Log.Info("CreateProject method from CompanyService called"); 
            return DB.Instance.CreateProject(prj);
        }

        public List<Project> GetAllProjectsForUser(User user)
        {
            Program.Log.Info("GetAllProjectsForUser method from CompanyService called"); 
            return DB.Instance.GetAllProjectsForUser(user);
        }

        public List<Project> GetAllProjects()
        {
            Program.Log.Info("GetAllProjects method from CompanyService called"); 
            return DB.Instance.GetAllProjects();
        }

        public bool UpdateProject(Project prj)
        {
            Program.Log.Info("UpdateProject method from CompanyService called");
            return DB.Instance.UpdateProject(prj);
        }

        public List<string> GetAllPartnerCompanies(User user)
        {
            Program.Log.Info("GetAllPartnerCompanies method from CompanyService called"); 
            return DB.Instance.GetAllPartnerCompanies(user);
        }

        public bool AddHiringCompany(HiringCompany hc)
        {
            Program.Log.Info("AddHiringCompany method from CompanyService called");
            return DB.Instance.AddHiringCompany(hc);
        }

        public bool AddPartnerCompany(User user, string partner)
        {
            Program.Log.Info("AddPartnerCompany method from CompanyService called");
            return DB.Instance.AddPartnerCompany(user, partner);
        }
      
        public bool ChangePass(string username, string oldPass, string newPass)
        {
            Program.Log.Info("ChangePass method from CompanyService called");
            return DB.Instance.ChangePass(username, oldPass, newPass);
        }

        public List<string> GetAllHiringCompanies()
        {
            Program.Log.Info("GetAllHiringCompanies method from CompanyService called"); 
            return DB.Instance.GetAllHiringCompanies();
        }

        public bool ApproveUserStory(string usName, string usCriteria, string projectName)
        {
            Program.Log.Info("ApproveUserStory method from CompanyService called");

            DialogResult result = MessageBox.Show("Da li zelite da prihvatite UserStory?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                DB.Instance.AddUserStory(usName, usCriteria, projectName);
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<string> GetAllUserStories(Project proj)
        {
            Program.Log.Info("GetAllUserStories method from CompanyService called");
            return DB.Instance.GetAllUserStories(proj);
        }

        public bool CheckIfLate(DateTime ulogovao, string timestart)
        {
            Program.Log.Info("CheckIfLate method from CompanyService called");

            DateTime definisanoVreme = Convert.ToDateTime(timestart);

            TimeSpan span = ulogovao.Subtract(definisanoVreme);

            double minutes = span.TotalMinutes;
            int minutesRounded = (int)Math.Round(span.TotalMinutes);

            if (minutesRounded > 15)
            {
                return true;
            }

            return false;
        }

        public bool SendProcentageProj(Procent procent)
        {
            Program.Log.Info("ChangePass method from CompanyService called");
            return DB.Instance.UpdateProject2(procent);
        }
    }
}
