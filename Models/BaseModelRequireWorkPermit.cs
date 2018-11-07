using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VipcoSafety.Models
{
    public class BaseModelRequireWorkPermit:BaseModel
    {

        // Common Data
        [StringLength(50)]
        public string RequireByEmpCode { get; set; }

        [StringLength(150)]
        public string RequireByEmpName { get; set; }
        [StringLength(150)]
        public string ApprovedByEmpName { get; set; }
        public DateTime? ApprovedDate { get; set; }

        [StringLength(250)]
        public string SubContractor { get; set; }

        [StringLength(200)]
        public string Location { get; set; }

        [StringLength(500)]
        public string WorkDescription { get; set; }

        public DateTime? WpStartDate { get; set; }

        [StringLength(10)]
        public string WpStartTimeString { get; set; }

        public DateTime? WpEndDate { get; set; }

        [StringLength(10)]
        public string WpEndTimeString { get; set; }

        public int? TotalWorker { get; set; }

        [StringLength(500)]
        public string SpecialTool { get; set; }

        //Safety Condition
        public bool? WorkComplate { get; set; }

        public bool? AreaClear { get; set; }

        public bool? KeepOutClear { get; set; }
        [StringLength(50)]
        public string ComplateBy { get; set; }
        [StringLength(200)]
        public string ComplateByName { get; set; }
        public DateTime? ComplateDate { get; set; }
        [StringLength(10)]
        public string ComplateTimeString { get; set; }
        [StringLength(200)]
        public string RepayMail { get; set; }
        public bool? IsSendMail { get; set; }
    }
}
