using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class ColdWorkPermit:BaseModelRequireWorkPermit
    {
        [Key]
        public int ColdWorkPermitId { get; set; }
        public bool? ConstructionWork { get; set; }
        public StatusWorkPermit StatusWorkPermit { get; set; }

        //FK
        //GroupWorkPermit
        public int? GroupWorkPermitId { get; set; }
        public GroupWorkPermit GroupWorkPermit { get; set; }
        //ColdHasCheckList
        public ICollection<ColdHasCheckList> ColdHasCheckLists { get; set; } = new List<ColdHasCheckList>();
        //ColdHasEquip
        public ICollection<ColdHasEquip> ColdHasEquips { get; set; } = new List<ColdHasEquip>();
    }
}
