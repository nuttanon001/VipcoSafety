import { BaseModel } from "../../shared/base-model.model";

export interface ConfinedSpaceEmpwork extends BaseModel {
  ConfinedHasEmpWorkId?: number;
  //FK
  // Employee
  EmpCode?: string;
  EmpNameThai?: string;
  // ConfinedSpacePermit
  ConfinedSpacePermitId?: number;
}
