using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class HotHasCheckList:BaseModelHasCheck
    {
        [Key]
        public int HotHasCheckListId { get; set; }
        // Fk
        // HotWorkPermit
        public int? HotWorkPermitId { get; set; }
        public HotWorkPermit HotWorkPermit { get; set; }
    }
}
