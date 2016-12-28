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
        public User Login(string username, string pass)
        {
            Console.WriteLine("Username: " + username + "\nPassword: " + pass);

            User u = new User();
            u = DB.Instance.CheckUser(username, pass);

            if (u != null)
                return u;
            else
                return null;

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
    }
}
