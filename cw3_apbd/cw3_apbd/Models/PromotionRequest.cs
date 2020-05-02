using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cw3_apbd.Models
{
    public class PromotionRequest
    {

        [Required]
        public string Studies { set; get; }
        [Required]
        public int Semester { set; get; }

    }
}
