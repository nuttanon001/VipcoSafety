import { BaseModel } from "../base-model.model";

export interface BasemodelRequireWorkpermit extends BaseModel {
  RequireByEmpCode?: string;
  RequireByEmpName?: string;
  ApprovedByEmpName?: string;
  ApprovedDate?: Date;
  // Max 250
  SubContractor?: string;
  // Max 200
  Location?: string;
  // Max 500
  WorkDescription?: string;
  WpStartDate?: Date;
  WpStartTimeString?: string;
  WpEndDate?: Date;
  WpEndTimeString?: string;
  TotalWorker?: number;
  // Max 500
  SpecialTool?: string;
  //Safety Condition
  WorkComplate?: boolean;
  AreaClear?: boolean;
  KeepOutClear?: boolean;
  ComplateBy?: string;
  ComplateByName?: string;
  ComplateDate?: Date;
  ComplateTimeString?: string;
  RepayMail?: string;
  IsSendMail?: boolean;
  // ViewModel
  Copying?: boolean;
}
