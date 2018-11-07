import { Injectable } from '@angular/core';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { BaseRestService } from '../../shared/base-rest.service';
import { ApprovdFlow } from './approvd-flow.model';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ApprovdFlowService extends BaseRestService<ApprovdFlow> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/ApprovedFlowMaster/",
      "ApprovedFlowMasterService",
      "ApprovedFlowMasterId",
      httpErrorHandler
    )
  }
}
