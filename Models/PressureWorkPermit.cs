using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class PressureWorkPermit:BaseModelRequireWorkPermit
    {
        [Key]
        public int PressureWorkPermitId { get; set; }
        public bool? NitrogenWork { get; set; }
        public bool? AriLeakWork { get; set; }
        public bool? HydroWork { get; set; }
        public StatusWorkPermit StatusWorkPermit { get; set; }

        //FK
        //GroupWorkPermit
        public int? GroupWorkPermitId { get; set; }
        public GroupWorkPermit GroupWorkPermit { get; set; }
        // PressureHasCheckList 
        public ICollection<PressureHasCheckList> PressureHasCheckLists { get; set; } = new List<PressureHasCheckList>();
        // PressureHasEquip
        public ICollection<PressureHasEquip> PressureHasEquips { get; set; } = new List<PressureHasEquip>();
    }
}
