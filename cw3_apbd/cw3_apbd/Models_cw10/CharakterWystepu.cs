using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class CharakterWystepu
    {
        public CharakterWystepu()
        {
            Wystep = new HashSet<Wystep>();
        }

        public int IdCharakterWystepu { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Wystep> Wystep { get; set; }
    }
}
