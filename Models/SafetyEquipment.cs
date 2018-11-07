using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class SafetyEquipment:BaseModel
    {
        [Key]
        public int SafetyEquipmentId { get; set; }
        [StringLength(150)]
        public string NameThai { get; set; }
        [StringLength(150)]
        public string NameEng { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public StatusModel Status { get; set; }
    }
}
