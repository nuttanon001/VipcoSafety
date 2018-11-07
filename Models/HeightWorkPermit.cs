using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace VipcoSafety.Models
{
    public class HeightWorkPermit:BaseModelRequireWorkPermit
    {
        [Key]
        public int HeightWorkPermitId { get; set; }
        public bool? InstallWork { get; set; }
        public bool? RepairWork { get; set; }
        public StatusWorkPermit StatusWorkPermit { get; set; }

        // FK   
        // GroupWorkPermit
        public int? GroupWorkPermitId { get; set; }
        public GroupWorkPermit GroupWorkPermit { get; set; }
        // HeightHasCheckList
        public ICollection<HeightHasCheckList> HeightHasCheckLists { get; set; } = new List<HeightHasCheckList>();
        // HeightHasEquip
        public ICollection<HeightHasEquip> HeightHasEquips { get; set; } = new List<HeightHasEquip>();
    }
}
