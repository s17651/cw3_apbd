using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class Nauczyciel
    {
        public Nauczyciel()
        {
            Proba = new HashSet<Proba>();
            Uczen = new HashSet<Uczen>();
        }

        public int IdOsoba { get; set; }
        public int IdNaukowy { get; set; }
        public int IdAwansu { get; set; }

        public virtual StopienAwansu IdAwansuNavigation { get; set; }
        public virtual StopienNaukowy IdNaukowyNavigation { get; set; }
        public virtual Osoba IdOsobaNavigation { get; set; }
        public virtual ICollection<Proba> Proba { get; set; }
        public virtual ICollection<Uczen> Uczen { get; set; }
    }
}
