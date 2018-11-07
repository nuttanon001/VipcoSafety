import { BaseModel } from "../../shared/base-model.model";

export interface ApprovdFlowDetail extends BaseModel {
  ApprovedFlowDetailId?: number;
  //FK
  // ApprovedFlowMaster
  ApprovedFlowMasterId?: number;
  // GroupMis
  GroupMis?: string;
  GroupMisName?: string;
}
