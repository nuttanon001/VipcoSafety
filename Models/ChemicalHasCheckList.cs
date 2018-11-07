using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models
{
    public class ChemicalHasCheckList:BaseModelHasCheck
    {
        [Key]
        public int ChemicalHasCheckListId { get; set; }
        //Fk
        //ChemicalWorkPermit
        public int? ChemicalWorkPermitId { get; set; }
        public ChemicalWorkPermit ChemicalWorkPermit { get; set; }
    }
}
