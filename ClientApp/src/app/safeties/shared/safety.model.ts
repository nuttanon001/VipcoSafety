import { BaseModel } from "../../shared/base-model.model";

export interface Safety extends BaseModel {
  SafetyRepayMailId: number;
  SafetyName?: string;
  SafetyMail?: string;
  // FK
  //EmpCode
  EmpCode?: string;
}
