﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VipcoSafety.Models
{
    public class BaseModel
    {
        [StringLength(50)]
        public string Creator { get; set; }
        public DateTime? CreateDate { get; set; }
        [StringLength(50)]
        public string Modifyer { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
