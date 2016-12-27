using System;
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

        public bool AddUser(User action)
        {
            using (var access = new AccessDB())
            {
                access.Actions.Add(action);
                int i = access.SaveChanges();

                if (i > 0)
                    return true;
                return false;
            }
        }

        public bool CheckUser(string username, string pass)
        {
            using (var access = new AccessDB())
            {
                for(int i=1; i<=access.Actions.Count(); i++)
                {
                    if(access.Actions.Find(i).Username == username)
                    {
                        if(access.Actions.Find(i).Password == pass)
                        {
                            return true;
                        }
                    }
                }
            }   
            return false;
        }
        
        public bool EditUser(string username, string pass)
        {
            User usr = new User();

            using (var access = new AccessDB())
            {
                for (int i = 1; i <= access.Actions.Count(); i++)
                {
                    if (access.Actions.Find(i).Username == username)
                    {
                        if (access.Actions.Find(i).Password == pass)
                        {
                            access.Actions.Find(i).Email = "safsfda";
                            int k = access.SaveChanges();

                            if (k > 0)
                                return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
