using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class MachineHasCheckList:BaseModelHasCheck
    {
        [Key]
        public int MachineHasCheckListId { get; set; }
        //Fk
        //MachineAtWorkPermit
        public int? MachineAtWorkPermitId { get; set; }
        public MachineAtWorkPermit MachineAtWorkPermit { get; set; }
    }
}
