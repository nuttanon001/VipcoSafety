using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class Location:BaseModel
    {
        [Key]
        public int LocationId { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
    }
}
