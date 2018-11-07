import { BaseModel } from "../base-model.model";

export interface BasemodelHasEquip extends BaseModel {
  HasCheck?: boolean;
  //FK
  //SafetyEquipment
  SafetyEquipmentId?: number;
  //ViewModel
  SafetyEquipmentNameThai?: string;
  SafetyEquipmentNameEng?: string;
}
