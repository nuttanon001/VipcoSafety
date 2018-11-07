using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class RayWorkPermit:BaseModelRequireWorkPermit
    {
        [Key]
        public int RayWorkPermitId { get; set; }
        public bool? XRay { get; set; }
        public bool? GemmaRay { get; set; }
        [StringLength(50)]
        public string RayStrength { get; set; }
        public double SafetyLength { get; set; }
        [StringLength(200)]
        public string ControlBy { get; set; }
        [StringLength(200)]
        public string RayNo { get; set; }
        public StatusWorkPermit StatusWorkPermit { get; set; }

        //Fk
        //GroupWorkPermit
        public int? GroupWorkPermitId { get; set; }
        public GroupWorkPermit GroupWorkPermit { get; set; }
        // RayHasCheckList
        public ICollection<RayHasCheckList> RayHasCheckLists { get; set; } = new List<RayHasCheckList>();
        // RayHasEquip
        public ICollection<RayHasEquip> RayHasEquips { get; set; } = new List<RayHasEquip>();
    }
}
