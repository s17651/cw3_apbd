using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class Kategoria
    {
        public Kategoria()
        {
            Pokoj = new HashSet<Pokoj>();
        }

        public int IdKategoria { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }

        public virtual ICollection<Pokoj> Pokoj { get; set; }
    }
}
