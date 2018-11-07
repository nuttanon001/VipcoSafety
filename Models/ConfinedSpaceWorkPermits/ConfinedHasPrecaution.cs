using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models.ConfinedSpaceWorkPermits
{
    public class ConfinedHasPrecaution:BaseModelPercaution
    {
        [Key]
        public int ConfinedHasPreId { get; set; }
        //FK
        // ConfinedSpaceWorkPermit
        public int? ConfinedSpaceWorkPermitId { get; set; }
        public ConfinedSpaceWorkPermit ConfinedSpaceWorkPermit { get; set; }

    }
}
