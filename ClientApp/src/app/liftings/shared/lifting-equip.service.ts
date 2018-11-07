// Angular Core
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
// Models
import { LiftingEquip } from './lifting-equip.model';
// Services
import { BaseRestService } from '../../shared/base-rest.service';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
// LiftingHasEquip
@Injectable()
export class LiftingEquipService extends BaseRestService<LiftingEquip> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/LiftingHasEquip/",
      "LiftingHasEquipService",
      "LiftingHasEquipId",
      httpErrorHandler
    )
  }
}
