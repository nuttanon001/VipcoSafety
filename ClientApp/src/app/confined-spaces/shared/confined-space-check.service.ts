import { Injectable } from '@angular/core';
import { ConfinedSpaceCheck } from './confined-space-check.model';
import { BaseRestService } from '../../shared/base-rest.service';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';

@Injectable()
export class ConfinedSpaceCheckService extends BaseRestService<ConfinedSpaceCheck> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/ConfinedHasCheckList/",
      "ConfinedHasCheckListService",
      "ConfinedHasCheckListId",
      httpErrorHandler
    )
  }
}
