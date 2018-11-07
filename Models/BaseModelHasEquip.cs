using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class BaseModelHasEquip:BaseModel
    {
        public bool? HasCheck { get; set; }
        //FK
        //SafetyEquipment
        public int? SafetyEquipmentId { get; set; }
        [StringLength(200)]
        public string SafetyEquipmentNameThai { get; set; }
        [StringLength(200)]
        public string SafetyEquipmentNameEng { get; set; }

    }
}
