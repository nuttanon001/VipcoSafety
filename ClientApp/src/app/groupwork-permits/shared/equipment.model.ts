import { BaseModel } from "../../shared/base-model.model";
import { StatusModel } from "./groupwork-permit.model";

export interface Equipment extends BaseModel {
  SafetyEquipmentId: number;
  NameThai?: string;
  NameEng?: string;
  Description?: string;
  Status?: StatusModel
}
