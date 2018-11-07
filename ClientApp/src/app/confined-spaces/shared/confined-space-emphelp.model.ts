import { BaseModel } from "../../shared/base-model.model";

export interface ConfinedSpaceEmphelp extends BaseModel {
  ConfinedHasEmpHelpId?: number;
  //FK
  // Employee
  EmpCode?: string;
  EmpNameThai?: string;
  // ConfinedSpacePermit
  ConfinedSpacePermitId?: number;
}
