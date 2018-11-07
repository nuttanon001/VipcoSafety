using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class MachineAtWorkPermit:BaseModelRequireWorkPermit
    {
        [Key]
        public int MachineAtWorkPermitId { get; set; }
        public bool? BendingMachine { get; set; }
        public bool? HydraulicMachine { get; set; }
        public bool? FormingNachine { get; set; }
        [StringLength(200)]
        public string MachineNo { get; set; }
        public StatusWorkPermit StatusWorkPermit { get; set; }

        // Fk
        // GroupWorkPermit
        public int? GroupWorkPermitId { get; set; }
        public GroupWorkPermit GroupWorkPermit { get; set; }
        // MachineHasCheckList
        public ICollection<MachineHasCheckList> MachineHasCheckLists { get; set; }
        // MachineHasEquip
        public ICollection<MachineHasEquip> MachineHasEquips { get; set; }
    }
}
