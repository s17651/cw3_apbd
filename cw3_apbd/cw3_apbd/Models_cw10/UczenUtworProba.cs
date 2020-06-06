using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class UczenUtworProba
    {
        public int IdUczen { get; set; }
        public int IdUtwor { get; set; }
        public int IdProba { get; set; }

        public virtual Proba IdProbaNavigation { get; set; }
        public virtual Uczen IdUczenNavigation { get; set; }
        public virtual Utwor IdUtworNavigation { get; set; }
    }
}
