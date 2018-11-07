using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class Permission:BaseModel
    {
        [Key]
        public int PremissionId { get; set; }
        /// <summary>
        /// User FK from Table User in MachineDataBase
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Level of user for safety
        /// </summary>
        public int LevelPermission { get; set; }
    }
}
