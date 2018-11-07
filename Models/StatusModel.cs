using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VipcoSafety.Models
{
    public enum StatusModel
    {
        Open = 1,
        Hold,
        Cancelled
    }

    public enum StatusWorkPermit
    {
        Require = 1,
        Approved,
        Cancelled
    }
}
