using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VipcoSafety.Models.LiftingWorkPermits
{
    public class Lifting1WorkPermit : BaseModel
    {
        [Key]
        public int Lifting1WorkPermitId { get; set; }
        [StringLength(50)]
        public string RequireByEmpCode { get; set; }
        [StringLength(150)]
        public string RequireByEmpName { get; set; }
        public bool? OverTenTon { get; set; }
        public bool? LengthOverTwelveMeter { get; set; }
        public bool? WidthOverThreeMeter { get; set; }
        public bool? TwoCraneLift { get; set; }
        public bool? IsSendMail { get; set; }

        [StringLength(150)]
        public string ApprovedByEmpName { get; set; }
        public DateTime? ApprovedDate { get; set; }
        [StringLength(200)]
        public string RepayMail { get; set; }
        public StatusWorkPermit StatusWorkPermit { get; set; }
        //Option 2
        #region Option2
        public DateTime? LiftDate { get; set; }
        [StringLength(50)]
        public string LiftDateTimeString { get; set; }
        public DateTime? LiftFinishDate { get; set; }
        [StringLength(50)]
        public string LiftFinishDateTimeString { get; set; }
        [StringLength(100)]
        public string JobNo { get; set; }
        [StringLength(100)]
        public string WorkGroup { get; set; }
        [StringLength(100)]
        public string Location { get; set; }
        [StringLength(150)]
        public string SupervisorName { get; set; }
        [StringLength(150)]
        public string EngineerName { get; set; }
        [StringLength(150)]
        public string SignalName { get; set; }
        [StringLength(150)]
        public string ControlCraneName { get; set; }
        [StringLength(150)]
        public string ControlName { get; set; }
        [StringLength(150)]
        public string ConnectName { get; set; }
        #endregion
        // Option 3
        #region Option3
        /// <summary>
        /// Line - 1
        /// </summary>
        public double? Line1TotalWeight { get; set; }
        [StringLength(200)]
        public string Line1Comment { get; set; }
        /// <summary>
        /// Line - 2
        /// </summary>
        /// 
        [StringLength(50)]
        public string Line2OverHeadCrancSize { get; set; }
        public int? Line2OverHeadCrancEa { get; set; }
        [StringLength(50)]
        public string Line2MobileCrancSize { get; set; }
        public int? Line2MobileCrancEa { get; set; }
        /// <summary>
        /// Line - 3
        /// </summary>
        public double? Line3WidthWork { get; set; }
        public double? Line3LengthWork { get; set; }
        public double? Line3HeightWork { get; set; }
        /// <summary>
        /// Line - 4
        /// </summary>
        [StringLength(50)]
        public string Line4SlingSize { get; set; }
        public double? Line4SlingTotal { get; set; }
        public double? Line4SlingLength { get; set; }
        /// <summary>
        /// Line - 5
        /// </summary>
        [StringLength(50)]
        public string Line5ChainSize { get; set; }
        public double? Line5ChainTotal { get; set; }
        public double? Line5ChainLength { get; set; }
        /// <summary>
        /// Line - 6
        /// </summary>
        [StringLength(50)]
        public string Line6BurlapSize { get; set; }
        public double? Line6BurlapTotal { get; set; }
        public double? Line6burlapLength { get; set; }
        /// <summary>
        /// Line - 7
        /// </summary>

        [StringLength(50)]
        public string Line7ShacklesSize { get; set; }
        public double? Line7ShacklesTotal { get; set; }
        /// <summary>
        /// Line - 8
        /// </summary>
        public double? Line8TypeLiftTotal { get; set; }
        public string Line8LiftCarry { get; set; }
        public double? Line8LiftDegree { get; set; }
        /// <summary>
        /// Line - 9
        /// </summary>
        public double? Line9LiftingBeamLength { get; set; }
        public double? Line9LiftingBeamWeigth { get; set; }
        public double? Line9ChainHoistSize { get; set; }
        public double? Line9CummalongSize { get; set; }
        /// <summary>
        /// Line - 10
        /// </summary>
        public double? Line10Ton { get; set; }
        public double? Line10GG { get; set; }
        [StringLength(200)]
        public string Other { get; set; }
        #endregion
        // Option 4
        #region Option4
        public double WeightPerLift { get; set; }
        #endregion
        // Option 5
        #region Option5
        public bool? Verify { get; set; }
        public string VerifyTime { get; set; }
        public string VerifyFix { get; set; }
        public bool? Pass { get; set; }
        public string PassTime { get; set; }
        [StringLength(50)]
        public string ComplateBy { get; set; }
        [StringLength(200)]
        public string ComplateByName { get; set; }
        public DateTime? ComplateDate { get; set; }
        [StringLength(10)]
        public string ComplateTimeString { get; set; }
        #endregion
        // GroupWorkPermit
        public int? GroupWorkPermitId { get; set; }
        public GroupWorkPermit GroupWorkPermit { get; set; }
        // LiftingHasEquip
        public ICollection<LiftingHasEquip> LiftingHasEquips { get; set; } = new List<LiftingHasEquip>();
        // LiftingHasCheckList
        public ICollection<LiftingHasCheckList> LiftingHasCheckLists { get; set; } = new List<LiftingHasCheckList>();
        // LiftingHasPercaution
        public ICollection<LiftingHasPercaution> LiftingHasPercautions { get; set; } = new List<LiftingHasPercaution>();
    }
}
