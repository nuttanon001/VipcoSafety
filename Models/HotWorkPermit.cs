using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class HotWorkPermit:BaseModelRequireWorkPermit
    {
        [Key]
        public int HotWorkPermitId { get; set; }
        public bool? PostWeldWork { get; set; }
        public bool? HotWork { get; set; }
        public StatusWorkPermit StatusWorkPermit { get; set; }

        // Fk
        // GroupWorkPermit
        public int? GroupWorkPermitId { get; set; }
        public GroupWorkPermit GroupWorkPermit { get; set; }
        // HotHasCheckList
        public ICollection<HotHasCheckList> HotHasCheckLists { get; set; } = new List<HotHasCheckList>();
        // HotHasEquip
        public ICollection<HotHasEquip> HotHasEquips { get; set; } = new List<HotHasEquip>();
    }
}
