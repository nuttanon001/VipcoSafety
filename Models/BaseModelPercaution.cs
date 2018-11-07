using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VipcoSafety.Models
{
    public class BaseModelPercaution:BaseModel
    {
        [StringLength(200)]
        public string Risk { get; set; }
        [StringLength(200)]
        public string Measure { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [StringLength(200)]
        public string Remark { get; set; }
    }
}
