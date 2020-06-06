using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class Proba
    {
        public Proba()
        {
            UczenUtworProba = new HashSet<UczenUtworProba>();
        }

        public int IdProba { get; set; }
        public int IdPianista { get; set; }
        public int IdUczen { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime DataZakonczenia { get; set; }
        public string NrSali { get; set; }
        public int? IdNauczyciel { get; set; }

        public virtual Nauczyciel IdNauczycielNavigation { get; set; }
        public virtual Pianista IdPianistaNavigation { get; set; }
        public virtual Uczen IdUczenNavigation { get; set; }
        public virtual ICollection<UczenUtworProba> UczenUtworProba { get; set; }
    }
}
