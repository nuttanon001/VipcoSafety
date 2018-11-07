using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class HeightHasEquip:BaseModelHasEquip
    {
        [Key]
        public int HeightHasEquipId { get; set; }
        //FK
        public int? HeightWorkPermitId { get; set; }
        public HeightWorkPermit HeightWorkPermit { get; set; }
    }
}
