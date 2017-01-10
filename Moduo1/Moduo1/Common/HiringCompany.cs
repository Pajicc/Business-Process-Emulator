﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common
{
    [Table("HiringCompanies")]
    public class HiringCompany
    {
        private string name = string.Empty;
        private User ceo = new User();
        private List<string> partnerCompanies = new List<string>();

        public HiringCompany() { }
        public HiringCompany(string name, User ceo)
        {
            this.name = name;
            this.ceo = ceo;
        }

        [Key]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public User CEO
        {
            get { return ceo; }
            set { ceo = value; }
        }

        public List<string> ParnterCompanies
        {
            get { return partnerCompanies; }
            set { partnerCompanies = value; }
        }
       
    }
}
