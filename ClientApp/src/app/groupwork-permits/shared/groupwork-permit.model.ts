import { BaseModel } from "../../shared/base-model.model";
import { PermitHasChecklist } from "./permit-has-checklist";
import { PermitHasEquipment } from "./permit-has-equipment";

export interface GroupworkPermit extends BaseModel {
  GroupWorkPermitId: number;
  Name?: string;
  Description?: string;
  Status?: StatusModel;
  // FK
  // GroupPermitHasCheckList
  GroupPermitHasCheckList?: Array<PermitHasChecklist>
  // GroupPermitHasEquipment
  GroupPermitHasEquipments?: Array<PermitHasEquipment>
}

export enum StatusModel {
  Open = 1,
  Hold,
  Cancelled
}
