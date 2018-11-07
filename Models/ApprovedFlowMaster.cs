using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class ApprovedFlowMaster : BaseModel
    {
        [Key]
        public int ApprovedFlowMasterId { get; set; }
        [StringLength(50)]
        public string ApprovedByEmp { get; set; }
        [StringLength(200)]
        public string ApprovedByNameThai { get; set; }
        [StringLength(200)]
        public string ApprovedByMail { get; set; }
        //FK
        // ApprovedFlowDetail
        public ICollection<ApprovedFlowDetail> ApprovedFlowDetails { get; set; }

    }
}
