using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class Tonacja
    {
        public Tonacja()
        {
            Utwor = new HashSet<Utwor>();
        }

        public int IdTonacja { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Utwor> Utwor { get; set; }
    }
}
