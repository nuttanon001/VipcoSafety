using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class HeightHasCheckList:BaseModelHasCheck
    {
        [Key]
        public int HeightHasCheckListId { get; set; }
        //FK
        public int? HeightWorkPermitId { get; set; }
        public HeightWorkPermit HeightWorkPermit { get; set; }
    }
}
