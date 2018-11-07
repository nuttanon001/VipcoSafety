using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class GroupPermitHasEquipment : BaseModel
    {
        [Key]
        public int GroupHasEquipId { get; set; }
        public bool? OptionValue { get; set; }
        public int? SequenceNo { get; set; }
        //FK
        // GroupWorkPermit
        public int? GroupWorkPermitId { get; set; }
        public GroupWorkPermit GroupWorkPermit { get; set; }
        // SafetyEquipment
        public int? SafetyEquipmentId { get; set; }
        public SafetyEquipment SafetyEquipment { get; set; }
    }
}
