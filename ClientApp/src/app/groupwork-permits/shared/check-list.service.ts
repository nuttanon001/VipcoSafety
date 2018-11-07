import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { CheckList } from './check-list.model';
import { HttpClient } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';

@Injectable()
export class CheckListService extends BaseRestService<CheckList> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/CheckList/",
      "CheckListService",
      "CheckListId",
      httpErrorHandler
    )
  }
}
