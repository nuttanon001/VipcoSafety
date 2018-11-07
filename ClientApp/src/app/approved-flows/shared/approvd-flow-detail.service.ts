import { Injectable } from '@angular/core';
import { ApprovdFlowDetail } from './approvd-flow-detail.model';
import { BaseRestService } from '../../shared/base-rest.service';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';

@Injectable()
export class ApprovdFlowDetailService extends BaseRestService<ApprovdFlowDetail> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/ApprovedFlowDetail/",
      "ApprovedFlowDetailService",
      "ApprovedFlowDetailId",
      httpErrorHandler
    )
  }
}
