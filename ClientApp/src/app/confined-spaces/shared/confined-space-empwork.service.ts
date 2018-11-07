import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { ConfinedSpaceEmpwork } from './confined-space-empwork.model';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';

@Injectable()
export class ConfinedSpaceEmpworkService extends BaseRestService<ConfinedSpaceEmpwork> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/ConfinedHasEmpWork/",
      "ConfinedHasEmpWorkService",
      "ConfinedHasEmpWorkId",
      httpErrorHandler
    )
  }
}
