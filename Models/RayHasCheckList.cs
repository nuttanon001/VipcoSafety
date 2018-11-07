using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class RayHasCheckList:BaseModelHasCheck
    {
        [Key]
        public int RayHasCheckListId { get; set; }
        // FK
        // RayWorkPermit
        public int? RayWorkPermitId { get; set; }
        public RayWorkPermit RayWorkPermit { get; set; }
    }
}
