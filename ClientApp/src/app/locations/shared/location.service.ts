import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseRestService } from '../../shared/base-rest.service';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { Location } from './location.model';

@Injectable()
export class LocationService extends BaseRestService<Location> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/Location/",
      "LocationService",
      "LocationId",
      httpErrorHandler
    )
  }
}
