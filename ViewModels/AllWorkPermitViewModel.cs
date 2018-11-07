using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoSafety.Models;

namespace VipcoSafety.ViewModels
{
    public class AllWorkPermitViewModel:BaseModel
    {
        public int? GroupWPId { get; set; }
        public string GroupWPName { get; set; }
        public int WorkPermitId { get; set; }
        public StatusWorkPermit StatusWorkPermit { get; set; }
        public string StatusWorkPermitString => System.Enum.GetName(typeof(StatusWorkPermit), this.StatusWorkPermit);
        public string RequireByName { get; set; }
        public string RequireByCode { get; set; }
        public DateTime? WorkPermitDate { get; set; }
        public string WorkPermitDateString => this.WorkPermitDate != null ? this.WorkPermitDate.Value.ToString("dd/MM/yy HH:mm") : "";
        public string ComplateBy { get; set; }
        public string ComplateString { get; set; }
        public DateTime? ComplateDate { get; set; }
        public string ComplateDateString => this.ComplateDate != null ? this.ComplateDate.Value.ToString("dd/MM/yy HH:mm") : "";
        public bool? Complate { get; set; }
        public bool? IsCancel { get; set; }
    }
}
