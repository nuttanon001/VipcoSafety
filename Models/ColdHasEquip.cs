using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class ColdHasEquip:BaseModelHasEquip
    {
        [Key]
        public int ColdHasEquipId { get; set; }
        //Fk
        //ColdWorkPermit
        public int? ColdWorkPermitId { get; set; }
        public ColdWorkPermit ColdWorkPermit { get; set; }
    }
}
