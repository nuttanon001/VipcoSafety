import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { ConfinedSpaceEmphelp } from './confined-space-emphelp.model';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';

@Injectable()
export class ConfinedSpaceEmphelpService extends BaseRestService<ConfinedSpaceEmphelp> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/ConfinedHasEmpHelp/",
      "ConfinedHasEmpHelpService",
      "ConfinedHasEmpHelpId",
      httpErrorHandler
    )
  }
}
