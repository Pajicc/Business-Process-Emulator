using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common
{
    [Table("Partners")]
    public class Partner
    {
        private int id;
        private string imeHiringKompanije;
        private string imeOutKompanije;

        public Partner() { }

        public Partner(string imehkmp, string imeokmp)
        {
            this.imeHiringKompanije = imehkmp;
            this.imeOutKompanije = imeokmp;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string ImeHiringKompanije
        {
            get
            {
                return imeHiringKompanije;
            }

            set
            {
                imeHiringKompanije = value;
            }
        }

        public string ImeOutKompanije
        {
            get
            {
                return imeOutKompanije;
            }

            set
            {
                imeOutKompanije = value;
            }
        }
    }
}
