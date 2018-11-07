import { BaseModel } from "../base-model.model";

export interface BasemodelHasPercaution extends BaseModel {
  Risk ?: string;
  Measure ?:string;
  Description ?:string;
  Remark?: string;
  // ViewModel
  RowIndex?: number;
}
