import { BaseModel } from "../../shared/base-model.model";

export interface Location extends BaseModel {
  LocationId?: number;
  Name?: string;
  Description?: string;
}
