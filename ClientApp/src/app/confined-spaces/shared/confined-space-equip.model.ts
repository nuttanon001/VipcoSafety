import { BasemodelHasEquip } from "../../shared/basemodel/basemodel-has-equip.model";

export interface ConfinedSpaceEquip extends BasemodelHasEquip {
  ConfinedHasEquipId?: number;
  //FK
  //ConfinedSpacePermit
  ConfinedSpacePermitId?: number;
}
