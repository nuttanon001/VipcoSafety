import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { BaseRestService } from '../../shared/base-rest.service';
import { GroupworkPermit } from './groupwork-permit.model';

@Injectable()
export class GroupworkPermitService extends BaseRestService<GroupworkPermit> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/GroupWorkPermit/",
      "GroupWorkPermitService",
      "GroupWorkPermitId",
      httpErrorHandler
    )
  }
}
