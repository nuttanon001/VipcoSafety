import { BaseModel } from "../../shared/base-model.model";
import { StatusWorkPermit } from "../../shared/basemodel/status-work-permit.enum";

export interface AllWorkPermit extends BaseModel {
  GroupWPId?: number;
  GroupWPName?: string;
  WorkPermitId?: number;
  StatusWorkPermit?: number;
  StatusWorkPermitString?: string;
  RequireByName?: string;
  RequireByCode?: string;
  WorkPermitDate?: Date;
  WorkPermitDateString?: string;
  Complate?: boolean;
  ComplateBy?: string;
  ComplateString?: string;
  ComplateDate?: Date;
  ComplateDateString?: string;
  IsCancel?: boolean;
}
