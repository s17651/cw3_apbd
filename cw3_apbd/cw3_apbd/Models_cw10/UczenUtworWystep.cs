using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class UczenUtworWystep
    {
        public int IdUczen { get; set; }
        public int IdUtwor { get; set; }
        public int IdWystep { get; set; }

        public virtual Uczen IdUczenNavigation { get; set; }
        public virtual Utwor IdUtworNavigation { get; set; }
        public virtual Wystep IdWystepNavigation { get; set; }
    }
}
