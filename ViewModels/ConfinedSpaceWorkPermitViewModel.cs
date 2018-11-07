using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VipcoSafety.Models;
using VipcoSafety.Models.ConfinedSpaceWorkPermits;

namespace VipcoSafety.ViewModels
{
    public class ConfinedSpaceWorkPermitViewModel:ConfinedSpaceWorkPermit
    {
        public string TypeWork { get; set; }
        public string TypeHotWork { get; set; }
        public string HasHotWorkString { get; set; }
    }
}
