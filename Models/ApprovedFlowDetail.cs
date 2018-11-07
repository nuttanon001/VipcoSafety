using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class ApprovedFlowDetail:BaseModel
    {
        [Key]
        public int ApprovedFlowDetailId { get; set; }
        //FK
        // ApprovedFlowMaster
        public int? ApprovedFlowMasterId { get; set; }
        public ApprovedFlowMaster ApprovedFlowMaster { get; set; }
        // GroupMis
        [StringLength(50)]
        public string GroupMis { get; set; }
        [StringLength(200)]
        public string GroupMisName { get; set; }
    }
}
