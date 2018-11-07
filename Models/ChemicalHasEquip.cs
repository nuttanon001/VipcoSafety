using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace VipcoSafety.Models
{
    public class ChemicalHasEquip:BaseModelHasEquip
    {
        [Key]
        public int ChemicalHasEquipId { get; set; }
        //FK
        //ChemicalWorkPermit
        public int? ChemicalWorkPermitId { get; set; }
        public ChemicalWorkPermit ChemicalWorkPermit { get; set; }
    }
}
