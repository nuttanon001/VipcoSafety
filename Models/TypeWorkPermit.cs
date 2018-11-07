using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class TypeWorkPermit:BaseModel
    {
        [Key]
        public int TypeWorkPermitId { get; set; }
        [StringLength(150)]
        public string NameThai { get; set; }
        [StringLength(150)]
        public string NameEng { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        public StatusModel Status { get; set; }
        public int SequenceNo { get; set; }
        public StatusWorkPermit StatusWorkPermit { get; set; }

        //FK
        // GroupWorkPermit
        public int? GroupWorkPermitId { get; set; }
        public GroupWorkPermit GroupWorkPermit { get; set; }
    }
}
