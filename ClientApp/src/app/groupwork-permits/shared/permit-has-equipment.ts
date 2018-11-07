import { BaseModel } from "../../shared/base-model.model";

export interface PermitHasEquipment extends BaseModel {
  GroupHasEquipId?: number;
  OptionValue?: boolean;
  SequenceNo?: number;
  //FK
  // GroupWorkPermit
  GroupWorkPermitId?: number;
  // SafetyEquipment
  SafetyEquipmentId?: number;
  //ViewModel
  SafetyEquipmentNameThai?: string;
  SafetyEquipmentNameEng?: string;
  UpdateSequenceNo?: number;
}
