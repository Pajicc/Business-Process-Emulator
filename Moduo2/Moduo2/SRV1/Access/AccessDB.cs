using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace SRV2.Access
{
    public class AccessDB : DbContext
    {
        public AccessDB() : base("DB") { }

        public DbSet<User> Actions { get; set; }
    }
}
