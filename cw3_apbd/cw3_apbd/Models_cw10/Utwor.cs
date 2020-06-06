using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class Utwor
    {
        public Utwor()
        {
            UczenUtworProba = new HashSet<UczenUtworProba>();
            UczenUtworWystep = new HashSet<UczenUtworWystep>();
        }

        public int IdUtwor { get; set; }
        public string Tytul { get; set; }
        public int IdKompozytor { get; set; }
        public int IdTonacja { get; set; }
        public string Opus { get; set; }
        public string Numer { get; set; }

        public virtual Kompozytor IdKompozytorNavigation { get; set; }
        public virtual Tonacja IdTonacjaNavigation { get; set; }
        public virtual ICollection<UczenUtworProba> UczenUtworProba { get; set; }
        public virtual ICollection<UczenUtworWystep> UczenUtworWystep { get; set; }
    }
}
