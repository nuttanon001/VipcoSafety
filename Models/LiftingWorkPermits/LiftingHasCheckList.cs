using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models.LiftingWorkPermits
{
    public class LiftingHasCheckList : BaseModelHasCheck
    {
        [Key]
        public int LiftingHasCheckListId { get; set; }
        // FK
        // ConfinedSpacePermit
        public int? Lifting1WorkPermitId { get; set; }
        public Lifting1WorkPermit Lifting1WorkPermit { get; set; }
    }
}
