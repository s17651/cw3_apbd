using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class Rezerwacja
    {
        public int IdRezerwacja { get; set; }
        public DateTime DataOd { get; set; }
        public DateTime DataDo { get; set; }
        public int IdGosc { get; set; }
        public int NrPokoju { get; set; }
        public bool Zaplacona { get; set; }

        public virtual Gosc IdGoscNavigation { get; set; }
        public virtual Pokoj NrPokojuNavigation { get; set; }
    }
}
