import { Injectable } from '@angular/core';
import { PermitHasChecklist } from './permit-has-checklist';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { BaseRestService } from '../../shared/base-rest.service';

@Injectable()
export class PermitHasChecklistService extends BaseRestService<PermitHasChecklist> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/GroupPermitHasCheckList/",
      "GroupPermitHasCheckListService",
      "GroupHasCheckId",
      httpErrorHandler
    )
  }
}
