using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoSafety.Models;

namespace VipcoSafety.ViewModels
{
    public class GroupPermitHasEquipmentViewModel:GroupPermitHasEquipment
    {
        public string SafetyEquipmentNameThai { get; set; }
        public string SafetyEquipmentNameEng { get; set; }
    }
}
