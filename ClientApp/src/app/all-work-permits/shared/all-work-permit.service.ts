import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { AllWorkPermit } from './all-work-permit.model';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class AllWorkPermitService extends BaseRestService<AllWorkPermit> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/AllWorkPermit/",
      "AllWorkPermitService",
      "AllWorkPermitId",
      httpErrorHandler
    )
  }

  setComplate(nObject: AllWorkPermit): Observable<any | AllWorkPermit> {
    return this.http.post<AllWorkPermit>(this.baseUrl + "SetComplate/", JSON.stringify(nObject),
      {
        headers: new HttpHeaders({
          "Content-Type": "application/json",
        })
      }).pipe(catchError(this.handleError("Add model", nObject)));
  }
}
