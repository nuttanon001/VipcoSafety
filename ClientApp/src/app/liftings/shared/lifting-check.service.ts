import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { LiftingCheck } from './lifting-check.model';

@Injectable()
export class LiftingCheckService extends BaseRestService<LiftingCheck> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/LiftingHasCheckList/",
      "LiftingHasCheckListService",
      "LiftingHasCheckListId",
      httpErrorHandler
    )
  }
}
