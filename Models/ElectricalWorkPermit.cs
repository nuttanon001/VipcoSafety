using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class ElectricalWorkPermit : BaseModelRequireWorkPermit
    {
        [Key]
        public int ElectricalPermitId { get; set; }
        public bool? InstallWork { get; set; }
        public bool? RepairWork { get; set; }
        public StatusWorkPermit? StatusWorkPermit { get; set; }
        // FK
        // GroupWorkPermit
        public int? GroupWorkPermitId { get; set; }
        public GroupWorkPermit GroupWorkPermit { get; set; }

        // ElectricalHasCheckList
        public ICollection<ElectricalHasCheckList> ElectricalHasCheckLists { get; set; } = new List<ElectricalHasCheckList>();
        // ElectricalHasEquip
        public ICollection<ElectricalHasEquip> ElectricalHasEquips { get; set; } = new List<ElectricalHasEquip>();
    }
}
