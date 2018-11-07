import { BaseModel } from "../../shared/base-model.model";
import { ApprovdFlowDetail } from "./approvd-flow-detail.model";

export interface ApprovdFlow extends BaseModel {
  ApprovedFlowMasterId: number;
  ApprovedByEmp?: string;
  ApprovedByNameThai?: string;
  ApprovedByMail?: string;
  //FK
  //ApprovedFlowDetail
  ApprovedFlowDetails?: Array<ApprovdFlowDetail>;
}
