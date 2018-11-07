import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { Safety } from './safety.model';

@Injectable()
export class SafetyService extends BaseRestService<Safety> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/SafetyRepayMail/",
      "SafetyRepayMailService",
      "SafetyRepayMailId",
      httpErrorHandler
    )
  }
}
