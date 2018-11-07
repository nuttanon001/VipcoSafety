using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models.ConfinedSpaceWorkPermits
{
    public class ConfinedHasEmpHelp:BaseModel
    {
        [Key]
        public int ConfinedHasEmpHelpId { get; set; }
        //FK
        // Employee
        [StringLength(50)]
        public string EmpCode { get; set; }
        [StringLength(200)]
        public string EmpNameThai { get; set; }
        // ConfinedSpacePermit
        public int? ConfinedSpacePermitId { get; set; }
        public ConfinedSpaceWorkPermit ConfinedSpacePermit { get; set; }
    }
}
