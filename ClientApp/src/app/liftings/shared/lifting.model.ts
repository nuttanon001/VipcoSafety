import { BaseModel } from "../../shared/base-model.model";
import { LiftingEquip } from "./lifting-equip.model";
import { LiftingCheck } from "./lifting-check.model";
import { LiftingPercaution } from "./lifting-percaution.model";

export interface Lifting extends BaseModel {
  Lifting1WorkPermitId: number;
  // Max 50
  RequireByEmpCode?: string;
  // Max 150
  RequireByEmpName?: string;
  OverTenTon?: boolean;
  LengthOverTwelveMeter?: boolean;
  WidthOverThreeMeter?: boolean;
  TwoCraneLift?: boolean;
  StatusWorkPermit?: number;
  RepayMail?: string;
  //Option 2
  LiftDate?: Date;
  // Max 50
  LiftDateTimeString?: string;
  LiftFinishDate?: Date;
  // Max 50
  LiftFinishDateTimeString?: string;
  // Max 100
  JobNo?: string;
  // Max 100
  WorkGroup?: string;
  // Max 100
  Location?: string;
  SupervisorName?: string;
  // Max 150
  EngineerName?: string;
  // Max 150
  SignalName?: string;
  // Max 150
  ControlCraneName?: string;
  // Max 150
  ControlName?: string;
  // Max 150
  ConnectName?: string;
  /// <summary>
  /// Line - 1
  /// </summary>
  Line1TotalWeight?: number;
  // Max 200
  Line1Comment?: string;
  /// <summary>
  /// Line - 2
  /// </summary>
  Line2OverHeadCrancSize?: string;
  Line2OverHeadCrancEa?: number;
  Line2MobileCrancSize?: string;
  Line2MobileCrancEa?: number;
  /// <summary>
  /// Line - 3
  /// </summary>
  Line3WidthWork?: number;
  Line3LengthWork?: number;
  Line3HeightWork?: number;
  /// <summary>
  /// Line - 4
  /// </summary>
  Line4SlingSize?: string;
  Line4SlingTotal?: number;
  Line4SlingLength?: number;
  /// <summary>
  /// Line - 5
  /// </summary>
  Line5ChainSize?: string;
  Line5ChainTotal?: number;
  Line5ChainLength?: number;
  /// <summary>
  /// Line - 6
  /// </summary>
  Line6BurlapSize?: string;
  Line6BurlapTotal?: number;
  Line6burlapLength?: number;
  /// <summary>
  /// Line - 7
  /// </summary>
  Line7ShacklesSize?: string;
  Line7ShacklesTotal?: number;
  /// <summary>
  /// Line - 8
  /// </summary>
  Line8TypeLiftTotal?: number;
  Line8LiftCarry?: string;
  Line8LiftDegree?: number;
  /// <summary>
  /// Line - 9
  /// </summary>
  Line9LiftingBeamLength?: number;
  Line9LiftingBeamWeigth?: number;
  Line9ChainHoistSize?: number;
  Line9CummalongSize?: number;
  /// <summary>
  /// Line - 10
  /// </summary>
  Line10Ton?: number;
  Line10GG?: number;
  // Max 200
  Other?: string;
  // Option 4
  WeightPerLift?: number;
  // Option 5
  Verify?: boolean;
  VerifyTime?: string;
  VerifyFix?: string;
  Pass?: boolean;
  PassTime?: string;
  // Max 50
  ComplateBy?: string;
  // Max 200
  ComplateByName?: string;
  ComplateDate?: Date;
  // Max 10
  ComplateTimeString?: string;
  // GroupWorkPermit
  GroupWorkPermitId?: number;
  //LiftingHasEquips
  LiftingHasEquips?: Array<LiftingEquip>;
  //LiftingHasCheckLists
  LiftingHasCheckLists?: Array<LiftingCheck>;
  //LiftingHasPercautions
  LiftingHasPercautions?: Array<LiftingPercaution>;
  // Add New
  IsSendMail?: boolean;
  ApprovedByEmpName?: string;
  ApprovedDate?: Date;
  //ViewModel
  TypeWork?: string;
  Copying?: boolean;
}
