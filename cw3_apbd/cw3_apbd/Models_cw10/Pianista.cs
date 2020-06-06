using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class Pianista
    {
        public Pianista()
        {
            InverseKierownikSekcjiNavigation = new HashSet<Pianista>();
            Proba = new HashSet<Proba>();
            Uczen = new HashSet<Uczen>();
            Wystep = new HashSet<Wystep>();
        }

        public int IdOsoba { get; set; }
        public int IdNaukowy { get; set; }
        public int IdAwansu { get; set; }
        public int? KierownikSekcji { get; set; }

        public virtual StopienAwansu IdAwansuNavigation { get; set; }
        public virtual StopienNaukowy IdNaukowyNavigation { get; set; }
        public virtual Osoba IdOsobaNavigation { get; set; }
        public virtual Pianista KierownikSekcjiNavigation { get; set; }
        public virtual ICollection<Pianista> InverseKierownikSekcjiNavigation { get; set; }
        public virtual ICollection<Proba> Proba { get; set; }
        public virtual ICollection<Uczen> Uczen { get; set; }
        public virtual ICollection<Wystep> Wystep { get; set; }
    }
}
