using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models.ConfinedSpaceWorkPermits
{
    public class ConfinedSpaceWorkPermit : BaseModelRequireWorkPermit
    {
        [Key]
        public int ConfinedSpaceWorkPermitId { get; set; }
        public bool? InstallWork { get; set; }
        public bool? RepairWork { get; set; }
        public bool? HasHotPermit { get; set; }
        [StringLength(50)]
        public string HotPermitNo { get; set; }
        public bool? HotWorkGrinding { get; set; }
        public bool? HotWorkCutting { get; set; }
        public bool? HotWorkWelding { get; set; }
        public bool? HotWorkOther { get; set; }
        [StringLength(50)]
        public string HotWorkOtherString { get; set; }
        public StatusWorkPermit StatusWorkPermit { get; set; }

        //FK
        // GroupWorkPermit
        public int? GroupWorkPermitId { get; set; }
        public GroupWorkPermit GroupWorkPermit { get; set; }

        // ConfinedHasEmpWork
        public ICollection<ConfinedHasEmpWork> ConfinedHasEmpWorks { get; set; } = new List<ConfinedHasEmpWork>();

        //ConfinedHasEmpHelp
        public ICollection<ConfinedHasEmpHelp> ConfinedHasEmpHelps { get; set; } = new List<ConfinedHasEmpHelp>();

        //ConfinedHasCheckList
        public ICollection<ConfinedHasCheckList> ConfinedHasCheckLists { get; set; } = new List<ConfinedHasCheckList>();

        //ConfinedHasEquip
        public ICollection<ConfinedHasEquip> ConfinedHasEquips { get; set; } = new List<ConfinedHasEquip>();

        //ConfinedHasPrecaution
        public ICollection<ConfinedHasPrecaution> ConfinedHasPrecautions { get; set; } = new List<ConfinedHasPrecaution>();

    }
}
