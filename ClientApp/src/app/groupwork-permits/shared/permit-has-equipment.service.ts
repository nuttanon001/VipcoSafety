import { Injectable } from '@angular/core';
import { PermitHasEquipment } from './permit-has-equipment';
import { BaseRestService } from '../../shared/base-rest.service';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';

@Injectable()
export class PermitHasEquipmentService extends BaseRestService<PermitHasEquipment> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/GroupPermitHasEquipment/",
      "GroupPermitHasEquipmentService",
      "GroupHasEquipId",
      httpErrorHandler
    )
  }
}
