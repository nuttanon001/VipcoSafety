using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using VipcoSafety.Models.LiftingWorkPermits;
using VipcoSafety.Models.ConfinedSpaceWorkPermits;

using Microsoft.EntityFrameworkCore;
using VipcoSafety.Models.SafetyData;

namespace VipcoSafety.Models
{
    public class SafetyContext : DbContext
    {
        public SafetyContext(DbContextOptions<SafetyContext> option) : base(option)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
        public DbSet<ApprovedFlowDetail> ApprovedFlowDetails { get; set; }
        public DbSet<ApprovedFlowMaster> ApprovedFlowMasters { get; set; }
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<ChemicalHasCheckList> ChemicalHasCheckLists { get; set; }
        public DbSet<ChemicalHasEquip> ChemicalHasEquips { get; set; }
        public DbSet<ChemicalWorkPermit> ChemicalWorkPermits { get; set; }
        public DbSet<ColdHasCheckList> ColdHasCheckLists { get; set; }
        public DbSet<ColdHasEquip> ColdHasEquips { get; set; }
        public DbSet<ColdWorkPermit> ColdWorkPermits { get; set; }
        public DbSet<ConfinedHasCheckList> ConfinedHasCheckLists { get; set; }
        public DbSet<ConfinedHasEmpHelp> ConfinedHasEmpHelps { get; set; }
        public DbSet<ConfinedHasEmpWork> ConfinedHasEmpWorks { get; set; }
        public DbSet<ConfinedHasEquip> ConfinedHasEquips { get; set; }
        public DbSet<ConfinedHasPrecaution> ConfinedHasPrecautions { get; set; }
        public DbSet<ConfinedSpaceWorkPermit> ConfinedSpaceWorkPermits { get; set; }
        public DbSet<ElectricalHasCheckList> ElectricalHasCheckLists { get; set; }
        public DbSet<ElectricalHasEquip> ElectricalHasEquips { get; set; }
        public DbSet<ElectricalWorkPermit> ElectricalWorkPermits { get; set; }
        public DbSet<GroupPermitHasCheckList> GroupPermitHasCheckLists { get; set; }
        public DbSet<GroupPermitHasEquipment> GroupPermitHasEquipments { get; set; }
        public DbSet<GroupWorkPermit> GroupWorkPermits { get; set; }
        public DbSet<HeightHasCheckList> HeightHasCheckLists { get; set; }
        public DbSet<HeightHasEquip> HeightHasEquips { get; set; }
        public DbSet<HeightWorkPermit> HeightWorkPermit { get; set; }
        public DbSet<HotHasCheckList> HotHasCheckList { get; set; }
        public DbSet<HotHasEquip> HotHasEquips { get; set; }
        public DbSet<HotWorkPermit> HotWorkPermits { get; set; }
        public DbSet<Lifting1WorkPermit> Lifting1WorkPermit { get; set; }
        public DbSet<LiftingHasCheckList> LiftingHasCheckList { get; set; }
        public DbSet<LiftingHasEquip> LiftingHasEquip { get; set; }
        public DbSet<LiftingHasPercaution> LiftingHasPercaution { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<MachineAtWorkPermit> MachineAtWorkPermits { get; set; }
        public DbSet<MachineHasCheckList> MachineHasCheckLists { get; set; }
        public DbSet<MachineHasEquip> MachineHasEquips { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PressureHasCheckList> PressureHasCheckList { get; set; }
        public DbSet<PressureHasEquip> PressureHasEquips { get; set; }
        public DbSet<PressureWorkPermit> PressureWorkPermits { get; set; }
        public DbSet<RayHasCheckList> RayHasCheckLists { get; set; }
        public DbSet<RayHasEquip> RayHasEquips { get; set; }
        public DbSet<RayWorkPermit> RayWorkPermits { get; set; }
        public DbSet<SafetyEquipment> SafetyEquipments { get; set; }
        public DbSet<SafetyRepayMail> SafetyRepayMail { get; set; }
        public DbSet<TypeWorkPermit> TypeWorkPermits { get; set; }
    }
}
