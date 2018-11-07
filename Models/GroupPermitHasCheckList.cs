using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class GroupPermitHasCheckList : BaseModel
    {
        [Key]
        public int GroupHasCheckId { get; set; }
        public bool? OptionValue { get; set; }
        public int? SequenceNo { get; set; }
        // FK
        // GroupWorkPermit 
        public int? GroupWorkPermitId { get; set; }
        public GroupWorkPermit GroupWorkPermit { get; set; }
        // CheckList
        public int? CheckListId { get; set; }
        public CheckList CheckList { get; set; }
    }
}
