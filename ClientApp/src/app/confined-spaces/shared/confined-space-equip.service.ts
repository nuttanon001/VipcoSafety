import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { ConfinedSpaceEquip } from './confined-space-equip.model';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ConfinedSpaceEquipService extends BaseRestService<ConfinedSpaceEquip> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/ConfinedHasEquip/",
      "ConfinedHasEquipService",
      "ConfinedHasEquipId",
      httpErrorHandler
    )
  }
}
