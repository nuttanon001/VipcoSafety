using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class BaseModelHasCheck:BaseModel
    {
        public bool? HasCheck { get; set; }
        //FK
        //CheckList
        public int? CheckListId { get; set; }
        [StringLength(200)]
        public string CheckListNameThai { get; set; }
        [StringLength(200)]
        public string CheckListNameEng { get; set; }
    }
}
