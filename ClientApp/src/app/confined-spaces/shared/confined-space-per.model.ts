import { BasemodelHasPercaution } from "../../shared/basemodel/basemodel-has-percaution.model";

export interface ConfinedSpacePer extends BasemodelHasPercaution {
  ConfinedHasPreId?: number;
  //FK
  // ConfinedSpaceWorkPermit
  ConfinedSpaceWorkPermitId?: number;
}
