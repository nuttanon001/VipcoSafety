using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class ChemicalWorkPermit : BaseModelRequireWorkPermit
    {
        [Key]
        public int ChemicalWorkPermitId { get; set; }
        public bool? PassivationWokr { get; set; }
        public bool? InsulationWork { get; set; }
        public bool? PaintAndBlastWork { get; set; }
        public StatusWorkPermit StatusWorkPermit { get; set; }

        //FK
        //GroupWorkPermit
        public int? GroupWorkPermitId { get; set; }
        public GroupWorkPermit GroupWorkPermit { get; set; }
        // ChemicalHasCheckList
        public ICollection<ChemicalHasCheckList> ChemicalHasCheckLists { get; set; } = new List<ChemicalHasCheckList>();
        // ChemicalHasEquip
        public ICollection<ChemicalHasEquip> ChemicalHasEquips { get; set; } = new List<ChemicalHasEquip>();
    }
}
