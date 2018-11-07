import { BasemodelHasPercaution } from "../../shared/basemodel/basemodel-has-percaution.model";

export interface LiftingPercaution extends BasemodelHasPercaution {
  LiftingHasPerId ?: number;
  // Fk
  // Lifting1WorkPermit
  Lifting1WorkPermitId ?:number;
}
