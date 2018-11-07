import { BasemodelHasCheck } from "../../shared/basemodel/basemodel-has-check.model";

export interface LiftingCheck extends BasemodelHasCheck {
  LiftingHasCheckListId?: number;
  // FK
  // ConfinedSpacePermitId
  Lifting1WorkPermitId?: number;
}
