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

        public User CheckUser(string username, string pass)
        {
            using (var access = new AccessDB())
            {

                for (int i = 1; i <= access.Actions.Count(); i++)
                {
                    if (access.Actions.Find(i).Username == username)
                    {
                        if (access.Actions.Find(i).Password == pass)
                        {
                            return access.Actions.Find(i);
                        }
                    }
                }
                return null;
            }
        }

        public bool EditUser(User userMain, User userEdit)
        {
            User usr = new User();

            using (var access = new AccessDB())
            {
                for (int i = 1; i <= access.Actions.Count(); i++)
                {
                    if (access.Actions.Find(i).Username == userMain.Username)
                    {
                        if (access.Actions.Find(i).Password == userMain.Password)
                        {
                            access.Actions.Find(i).Username = userEdit.Username;
                            access.Actions.Find(i).Password = userEdit.Password;
                            access.Actions.Find(i).Email = userEdit.Email;
                            access.Actions.Find(i).Role = userEdit.Role;

                            int k = access.SaveChanges();

                            if (k > 0)
                                return true;
                        }
                    }
                }
            }

            return false;
        }

        public List<User> GetAllEmployees()
        {
            List<User> usrs = new List<User>();

            using (var access = new AccessDB())
            {
                for (int i = 1; i <= access.Actions.Count(); i++)
                {
                    if (access.Actions.Find(i).Role == Roles.Employee)
                    {
                        usrs.Add(access.Actions.Find(i));
                    }
                }

                return usrs;
            }
        }

    }
}
