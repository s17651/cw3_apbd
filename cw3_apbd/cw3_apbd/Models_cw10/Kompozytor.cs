using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class Kompozytor
    {
        public Kompozytor()
        {
            Utwor = new HashSet<Utwor>();
        }

        public int IdOsoba { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public DateTime? DataSmierci { get; set; }

        public virtual Osoba IdOsobaNavigation { get; set; }
        public virtual ICollection<Utwor> Utwor { get; set; }
    }
}
