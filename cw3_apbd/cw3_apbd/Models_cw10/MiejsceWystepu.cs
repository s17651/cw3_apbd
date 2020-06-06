using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class MiejsceWystepu
    {
        public MiejsceWystepu()
        {
            Wystep = new HashSet<Wystep>();
        }

        public int IdMiejsce { get; set; }
        public string Nazwa { get; set; }
        public string Adres { get; set; }

        public virtual ICollection<Wystep> Wystep { get; set; }
    }
}
