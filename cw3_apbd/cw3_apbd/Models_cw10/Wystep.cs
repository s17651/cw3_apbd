using System;
using System.Collections.Generic;

namespace cw3_apbd.Models_cw10
{
    public partial class Wystep
    {
        public Wystep()
        {
            UczenUtworWystep = new HashSet<UczenUtworWystep>();
        }

        public int IdWystep { get; set; }
        public byte[] DataGodzina { get; set; }
        public int IdPianista { get; set; }
        public int IdMiejsce { get; set; }
        public int IdCharakterWystepu { get; set; }

        public virtual CharakterWystepu IdCharakterWystepuNavigation { get; set; }
        public virtual MiejsceWystepu IdMiejsceNavigation { get; set; }
        public virtual Pianista IdPianistaNavigation { get; set; }
        public virtual ICollection<UczenUtworWystep> UczenUtworWystep { get; set; }
    }
}
