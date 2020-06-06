using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class Uczen
    {
        public Uczen()
        {
            Proba = new HashSet<Proba>();
            UczenUtworProba = new HashSet<UczenUtworProba>();
            UczenUtworWystep = new HashSet<UczenUtworWystep>();
        }

        public int IdOsoba { get; set; }
        public string Klasa { get; set; }
        public int IdInstrument { get; set; }
        public int IdNauczyciel { get; set; }
        public int IdPianista { get; set; }

        public virtual Instrument IdInstrumentNavigation { get; set; }
        public virtual Nauczyciel IdNauczycielNavigation { get; set; }
        public virtual Osoba IdOsobaNavigation { get; set; }
        public virtual Pianista IdPianistaNavigation { get; set; }
        public virtual ICollection<Proba> Proba { get; set; }
        public virtual ICollection<UczenUtworProba> UczenUtworProba { get; set; }
        public virtual ICollection<UczenUtworWystep> UczenUtworWystep { get; set; }
    }
}
