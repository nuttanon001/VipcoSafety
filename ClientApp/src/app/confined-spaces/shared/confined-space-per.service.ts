import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { ConfinedSpacePer } from './confined-space-per.model';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';

@Injectable()
export class ConfinedSpacePerService extends BaseRestService<ConfinedSpacePer> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/ConfinedHasPrecaution/",
      "ConfinedHasPrecautionService",
      "ConfinedHasPreId",
      httpErrorHandler
    )
  }
}
