using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace VipcoSafety.Models
{
    public class GroupWorkPermit:BaseModel
    {
        [Key]
        public int GroupWorkPermitId { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public StatusModel Status { get; set; }
        // FK
        // GroupPermitHasCheckList
        public ICollection<GroupPermitHasCheckList> GroupPermitHasCheckList { get; set; } = new List<GroupPermitHasCheckList>();
        // GroupPermitHasEquipment
        public ICollection<GroupPermitHasEquipment> GroupPermitHasEquipments { get; set; } = new List<GroupPermitHasEquipment>();
    }
}
