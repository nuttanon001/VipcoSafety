using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class ElectricalHasEquip:BaseModelHasEquip
    {
        [Key]
        public int ElectricalHasEquipId { get; set; }
        //FK
        //ElectricalPermit
        public int? ElectricalPermitId { get; set; }
        public ElectricalWorkPermit ElectricalPermit { get; set; }
    }
}
