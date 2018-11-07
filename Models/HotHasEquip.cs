using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class HotHasEquip : BaseModelHasEquip
    {
        [Key]
        public int HasHasEquipId { get; set; }
        //FK
        // HotWorkPermit
        public int? HotWorkPermitId { get; set; }
        public HotWorkPermit HotWorkPermit { get; set; }
        
    }
}
