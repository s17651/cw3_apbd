using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class Osoba
    {
        public int IdOsoba { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public virtual Kompozytor Kompozytor { get; set; }
        public virtual Nauczyciel Nauczyciel { get; set; }
        public virtual Pianista Pianista { get; set; }
        public virtual Uczen Uczen { get; set; }
    }
}
