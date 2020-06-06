using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class Ocena
    {
        public int IdOceny { get; set; }
        public int IdStudent { get; set; }
        public decimal Wartosc { get; set; }
        public string Przedmiot { get; set; }
    }
}
