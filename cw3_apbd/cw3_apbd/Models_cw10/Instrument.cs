using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class Instrument
    {
        public Instrument()
        {
            Uczen = new HashSet<Uczen>();
        }

        public int IdInstrument { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Uczen> Uczen { get; set; }
    }
}
