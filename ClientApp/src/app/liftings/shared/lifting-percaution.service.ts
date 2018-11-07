import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { LiftingPercaution } from './lifting-percaution.model';

@Injectable()
export class LiftingPercautionService extends BaseRestService<LiftingPercaution> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/LiftingHasPercaution/",
      "LiftingPercautionService",
      "LiftingHasPerId",
      httpErrorHandler
    )
  }
}
