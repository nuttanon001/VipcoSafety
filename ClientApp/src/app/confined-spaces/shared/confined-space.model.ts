import { ConfinedSpacePer } from "./confined-space-per.model";
import { ConfinedSpaceEquip } from "./confined-space-equip.model";
import { ConfinedSpaceCheck } from "./confined-space-check.model";
import { ConfinedSpaceEmpwork } from "./confined-space-empwork.model";
import { ConfinedSpaceEmphelp } from "./confined-space-emphelp.model";
import { StatusWorkPermit } from "../../shared/basemodel/status-work-permit.enum";
import { BasemodelRequireWorkpermit } from "../../shared/basemodel/basemodel-require-workpermit.model";

export interface ConfinedSpace extends BasemodelRequireWorkpermit {
  ConfinedSpaceWorkPermitId: number;
  InstallWork?: boolean;
  RepairWork?: boolean;
  HasHotPermit?: boolean;
  // Max 50
  HotPermitNo?: string;
  HotWorkGrinding?: boolean;
  HotWorkCutting?: boolean;
  HotWorkWelding?: boolean;
  HotWorkOther?: boolean;
  HotWorkOtherString?: string;
  StatusWorkPermit?: StatusWorkPermit;
  //FK
  // GroupWorkPermit
  GroupWorkPermitId?: number;
  // ConfinedHasEmpWork
  ConfinedHasEmpWorks?: Array<ConfinedSpaceEmpwork>;
  //ConfinedHasEmpHelp
  ConfinedHasEmpHelps?: Array<ConfinedSpaceEmphelp>;
  //ConfinedHasCheckList
  ConfinedHasCheckLists?: Array<ConfinedSpaceCheck>;
  //ConfinedHasEquip
  ConfinedHasEquips?: Array<ConfinedSpaceEquip>;
  // ConfinedHasPrecautions
  ConfinedHasPrecautions?: Array<ConfinedSpacePer>;
  //ViewModel
  TypeWork?: string;
  TypeHotWork?: string;
  HasHotWorkString ?:string;
}
