import { BaseModel } from "../base-model.model";

export interface BasemodelHasCheck extends BaseModel {
  HasCheck?: boolean;
  //FK
  //ChekList
  CheckListId?: number;
  //ViewModel
  CheckListNameThai?: string;
  CheckListNameEng?: string;
}
