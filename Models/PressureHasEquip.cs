using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class PressureHasEquip:BaseModelHasEquip
    {
        [Key]
        public  int PressureHasEquipId { get; set; }
        //FK
        //PressureWorkPermit
        public int PressureWorkPermitId { get; set; }
        public PressureWorkPermit PressureWorkPermit { get; set; }
    }
}
