using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace SRV1.Access
{
    /// <summary>
    /// Baza za storovanje Usera
    /// </summary>
    public class AccessDB : DbContext
    {
        public AccessDB() : base("DB") { }

        /// <summary>
        /// Actions za Usera
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Actions za Project
        /// </summary>
        public DbSet<Project> Projects { get; set; }

        /// <summary>
        /// Actions za HiringCompany
        /// </summary>
        public DbSet<HiringCompany> HiringCompanies { get; set; }

        /// <summary>
        /// Actions za UserStories
        /// </summary>
        public DbSet<UserStory> UserStories { get; set; }

        /// <summary>
        /// Actions za Partnere
        /// </summary>
        public DbSet<Partner> Partners { get; set; }
    }
}
