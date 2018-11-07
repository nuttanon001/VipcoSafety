using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models.LiftingWorkPermits
{
    public class LiftingHasPercaution: BaseModelPercaution
    {
        [Key]
        public int LiftingHasPerId { get; set; }
        // Fk
        // Lifting1WorkPermit
        public int? Lifting1WorkPermitId { get; set; }
        public Lifting1WorkPermit Lifting1WorkPermit { get; set; }
    }
}
