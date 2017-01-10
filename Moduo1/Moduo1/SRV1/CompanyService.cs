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
    public class CompanyService : ICompanyService
    {
       // public List<User> onlineUsers = new List<User>();

        public User Login(string username, string pass)
        {
            Console.WriteLine("Username: " + username + "\nPassword: " + pass);

            User u = new User();
            u = DB.Instance.CheckUser(username, pass);

            u.LoggedIn = true;

            #region testProjekat(add/remove)
            /* //testiranje za addovanje i brisanje projekta
            Project prj = new Project();
            List<UserStory> us = new List<UserStory>();

            prj.Name = "Projekat24411";
            prj.Active = true;
            prj.Description = "testProjekat";
            prj.Po = GetUser("poTest");

            for (int i = 0; i < 5; i++)
            {
                UserStory story = new UserStory();
                story.Ime = "us" + i;
                story.Criteria = "criteria" + i;

                us.Add(story);
            }

            prj.UserStories = us;

            //CreateProject(prj);

            DeleteProject(prj);    
            */
            #endregion

            DateTime dt = DateTime.Now;
            if (ProveriDaLiKasni(dt, u.WorkTimeStart))
            {
                DialogResult result = MessageBox.Show("You are late for work!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //SendMail(u);
            }

            if (u != null)
            {
                //onlineUsers.Add(u);
                Program.log.Info("User: " + username + " Has been loggedIn!");
                return u;
            }
            else
            {
                Program.log.Info("Failed login! User: " + username);
                return null; 
            }

                
        }

        public bool LogOut(string username, string pass)
        {
            bool done = false;
            Console.WriteLine("User: " + username + " is now logged out.");

            User u = new User();
            u = DB.Instance.CheckUser(username, pass);

            u.LoggedIn = false;

            done = DB.Instance.LogOut(username, pass);

            return done;
        }

        public bool AddUser(User user)
        {
            bool done = false;
            user.WorkTimeStart = "09:00:00";

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
            Console.WriteLine("Poslata lista Usera!");

            List<User> lista = new List<User>();

            lista = DB.Instance.GetAllEmployees();

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

        public bool ProveriDaLiKasni(DateTime ulogovao, string timestart)
        {
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

        public void SendMail(User u)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp-mail.outlook.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("email", "pass"); //ko salje

            MailMessage mm = new MailMessage("CEO@hiringcompany.com", u.Email, "Obavestenje!", "KASNIS NA POSO DRUZE!");
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }

        public bool CreateProject(Project prj)
        {
            bool done = false;

            Console.WriteLine("Dodat nov Projekat!");
            Console.WriteLine("Ime projekta: " + prj.Name);

            done = DB.Instance.CreateProject(prj);

            return done;
        }

        public List<Project> GetAllProjects()
        {
            Console.WriteLine("Poslata lista Usera!");

            List<Project> projekti = new List<Project>();

            projekti = DB.Instance.GetAllProjects();

            return projekti;
        }

        public bool DeleteProject(Project prj)
        {
            bool done = false;

            Console.WriteLine("Obrisan Projekat: " + prj.Name);

            done = DB.Instance.DeleteProject(prj);

            return done;
        }

        public bool UpdateProject(Project prj)
        {
            bool done = false;

            Console.WriteLine("Updateovan Projekat: " + prj.Name);

            done = DB.Instance.UpdateProject(prj);

            return done;
        }

        public List<string> GetAllParnterCompanies(string username)
        {
            List<string> companies = new List<string>();

            companies = DB.Instance.GetAllParnterCompanies(username);

            return companies;
        }
        public bool AddHiringCompany(HiringCompany hc)
        {
            bool done = false;

            Console.WriteLine("Dodata nova Kompanija!");
            Console.WriteLine("Ime Kompanije: " + hc.Name);

            done = DB.Instance.AddHiringCompany(hc);

            return done;
        }

        public bool AddParnterCompany(string ceo, string partner)
        {
            bool done = false;

            Console.WriteLine("Dodata nova Parnter kompanija!");
            Console.WriteLine("Ime Kompanije: " + partner);

            done = DB.Instance.AddParnterCompany(ceo, partner);

            return done;
        }
    }
}
