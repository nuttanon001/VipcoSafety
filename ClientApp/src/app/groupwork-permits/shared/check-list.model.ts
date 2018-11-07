import { BaseModel } from "../../shared/base-model.model";
import { StatusModel } from "./groupwork-permit.model";

export interface CheckList extends BaseModel {
  CheckListId: number;
  NameThai?: string;
  NameEng?: string;
  Description?: string;
  Status?: StatusModel
}
