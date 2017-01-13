using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Procent
    {
        private string imeProj;
        private double procenat;

        public Procent() { }
        public Procent(string proj, double proc)
        {
            this.imeProj = proj;
            this.procenat = proc;
        }

        public string ImeProj
        {
            get { return imeProj; }
            set { imeProj = value; }
        }

        public double Procenat
        {
            get { return procenat; }
            set { procenat = value; }
        }
    }
}
