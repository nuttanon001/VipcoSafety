using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VipcoSafety.Models
{
    public class ElectricalHasCheckList:BaseModelHasCheck
    {
        [Key]
        public int ElectricalHasCheckListId { get; set; }
        //FK
        // ElectricalPermit
        public int? ElectricalPermitId { get; set; }
        public ElectricalWorkPermit ElectricalPermit { get; set; }
    }
}
