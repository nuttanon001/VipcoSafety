using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using AutoMapper;
using VipcoSafety.Models;
using VipcoSafety.ViewModels;
using VipcoSafety.Models.LiftingWorkPermits;
using VipcoSafety.Models.ConfinedSpaceWorkPermits;
using VipcoSafety.Models.Machines;

namespace VipcoSafety.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // GroupPermitHasCheckList
            CreateMap<GroupPermitHasCheckList, GroupPermitHasCheckListViewModel>()
                .ForMember(x => x.CheckListNameThai, o => o.MapFrom(s => s.CheckList.NameThai))
                .ForMember(x => x.CheckListNameEng, o => o.MapFrom(s => s.CheckList.NameEng))
                .ForMember(x => x.GroupWorkPermit,o => o.Ignore())
                .ForMember(x => x.CheckList, o => o.Ignore());

            // GroupPermitHasCheckList
            CreateMap<GroupPermitHasEquipment, GroupPermitHasEquipmentViewModel>()
                .ForMember(x => x.SafetyEquipmentNameThai, o => o.MapFrom(s => s.SafetyEquipment.NameThai))
                .ForMember(x => x.SafetyEquipmentNameEng, o => o.MapFrom(s => s.SafetyEquipment.NameEng))
                .ForMember(x => x.GroupWorkPermit, o => o.Ignore())
                .ForMember(x => x.SafetyEquipment, o => o.Ignore());

            // ConfinedSpaceWorkPermit
            CreateMap<ConfinedSpaceWorkPermit, ConfinedSpaceWorkPermitViewModel>()
                .ForMember(x => x.TypeWork, o => o.MapFrom(s => s.InstallWork != null && s.InstallWork.Value ? "Installation Work" : "Repair Work"))
                .ForMember(x => x.HasHotWorkString, o => o.MapFrom(s => s.HasHotPermit != null && s.HasHotPermit.Value ? "Yes" : "No"))
                .ForMember(x => x.TypeHotWork, o => o.MapFrom(s => s.HotWorkGrinding != null && s.HotWorkGrinding.Value ? "Grinding" :
                                                             (s.HotWorkCutting != null && s.HotWorkCutting.Value ? "Cutting" :
                                                             (s.HotWorkWelding != null && s.HotWorkWelding.Value ? "Welding" : "Other"))));
            // Lifting1WorkPermit
            CreateMap<Lifting1WorkPermit, Lifting1WorkPermitViewModel>()
                .ForMember(x => x.TypeWork, o => o.MapFrom(s => s.OverTenTon != null && s.OverTenTon.Value ? "ขนาดชิ้นงานเกิน 10 Ton." : 
                                                          (s.LengthOverTwelveMeter != null && s.LengthOverTwelveMeter.Value ? "ชิ้นงานยาวเกิน 12 เมตร" : 
                                                          (s.WidthOverThreeMeter != null && s.WidthOverThreeMeter.Value ? "ชิ้นงานกว้างเกิน 3 เมตร" : "มีรูปร่างซับซ้อน/ใช้เครน 2 เครื่องในการเคลื่อนย้าย"))));
            // User
            CreateMap<User, UserViewModel>()
                .ForMember(x => x.NameThai, o => o.MapFrom(s => s.EmpCodeNavigation != null ? s.EmpCodeNavigation.NameThai : ""))
                .ForMember(x => x.GroupCode, o => o.MapFrom(s => s.EmpCodeNavigation != null ? s.EmpCodeNavigation.GroupCode : ""))
                .ForMember(x => x.GroupName, o => o.MapFrom(s => s.EmpCodeNavigation != null ? s.EmpCodeNavigation.GroupName : ""))
                .ForMember(x => x.EmpCodeNavigation,o => o.Ignore());

        }
    }
}
