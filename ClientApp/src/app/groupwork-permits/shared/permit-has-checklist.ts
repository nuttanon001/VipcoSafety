import { BaseModel } from "../../shared/base-model.model";

export interface PermitHasChecklist extends BaseModel {
  GroupHasCheckId?: number;
  OptionValue?: boolean;
  SequenceNo?: number;
  // FK
  // GroupWorkPermit
  GroupWorkPermitId?: number;
  // CheckList
  CheckListId?: number;
  //ViewModel
  CheckListNameThai?: string;
  CheckListNameEng?: string;
  UpdateSequenceNo?: number;
}
