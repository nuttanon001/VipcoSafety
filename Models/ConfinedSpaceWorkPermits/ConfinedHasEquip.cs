using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models.ConfinedSpaceWorkPermits
{
    public class ConfinedHasEquip:BaseModelHasEquip
    {
        [Key]
        public int ConfinedHasEquipId { get; set; }
        //FK
        //ConfinedSpacePermit
        public int? ConfinedSpacePermitId { get; set; }
        public ConfinedSpaceWorkPermit ConfinedSpacePermit { get; set; }
    }
}
