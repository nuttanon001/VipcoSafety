using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models.SafetyData
{
    public class SafetyRepayMail:BaseModel
    {
        [Key]
        public int SafetyRepayMailId { get; set; }
        [StringLength(200)]
        public string SafetyName { get; set; }
        [StringLength(200)]
        public string SafetyMail { get; set; }
        // FK
        //EmpCode
        public string EmpCode { get; set; }
    }
}
