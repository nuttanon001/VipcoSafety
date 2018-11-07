import { BasemodelHasEquip } from "../../shared/basemodel/basemodel-has-equip.model";

export interface LiftingEquip extends BasemodelHasEquip {
  LiftingHasEquipId?: number;
  //FK
  //ConfinedSpacePermit
  Lifting1WorkPermitId?: number;
}
