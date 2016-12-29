using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using SRV1.Access;

namespace SRV1
{
    public class CompanyService : ICompanyService
    {
        public List<User> onlineUsers = new List<User>();

        public User Login(string username, string pass)
        {
            Console.WriteLine("Username: " + username + "\nPassword: " + pass);

            User u = new User();
            u = DB.Instance.CheckUser(username, pass);

            u.LoggedIn = true;

            DateTime dt = DateTime.Now;
            if (ProveriDaLiKasni(dt, u.WorkTimeStart))
            {
                //poslati poruku Useru da kasni na posao!
            }

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

        public bool ProveriDaLiKasni(DateTime ulogovao, string timestart)
        {
            //{0:HH:mm:ss}
            //string ulogovao = string.Format("{0:HH:mm:ss}", DateTime.Now);
            /*
            string[] vreme = ulogovao.Split(':');
            int[] intVr = new int[3];
            int[] intVr2 = new int[3];

            try
            {
                intVr[0] = Int32.Parse(vreme[0]);
                intVr[1] = Int32.Parse(vreme[1]);
                intVr[2] = Int32.Parse(vreme[2]);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            string[] definisanoVreme = timestart.Split(':');
            try
            {
                intVr2[0] = Int32.Parse(definisanoVreme[0]);
                intVr2[1] = Int32.Parse(definisanoVreme[1]);
                intVr2[2] = Int32.Parse(definisanoVreme[2]);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            if ((intVr2[0] - intVr[0]) == 0)
            {

            }
             * */
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
    }
}
