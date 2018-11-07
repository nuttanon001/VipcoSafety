﻿using System;
using System.Collections.Generic;

namespace VipcoSafety.Models.Machines
{
    public partial class EmployeeGroupMis
    {
        public EmployeeGroupMis()
        {
            Employee = new HashSet<Employee>();
        }

        public string GroupMis { get; set; }
        public string GroupDesc { get; set; }
        public string Remark { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
