using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class StopienNaukowy
    {
        public StopienNaukowy()
        {
            Nauczyciel = new HashSet<Nauczyciel>();
            Pianista = new HashSet<Pianista>();
        }

        public int IdNaukowy { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Nauczyciel> Nauczyciel { get; set; }
        public virtual ICollection<Pianista> Pianista { get; set; }
    }
}
