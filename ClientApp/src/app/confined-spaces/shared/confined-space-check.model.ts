import { BasemodelHasCheck } from "../../shared/basemodel/basemodel-has-check.model";

export interface ConfinedSpaceCheck extends BasemodelHasCheck {
  ConfinedHasCheckListId?: number;
  // FK
  // ConfinedSpacePermitId
  ConfinedSpacePermitId?: number;
}
