import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { BaseRestService } from '../../shared/base-rest.service';
import { Equipment } from './equipment.model';

@Injectable()
export class EquipmentService extends BaseRestService<Equipment> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/SafetyEquipment/",
      "SafetyEquipmentService",
      "SafetyEquipmentId",
      httpErrorHandler
    )
  }
}
