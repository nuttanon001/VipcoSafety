import { Injectable } from '@angular/core';
import { BaseRestService } from '../../shared/base-rest.service';
import { Lifting } from './lifting.model';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { HttpErrorHandler } from '../../shared/http-error-handler.service';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class LiftingService extends BaseRestService<Lifting> {
  constructor(
    http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    super(
      http,
      "api/Lifting1WorkPermit/",
      "Lifting1WorkPermitService",
      "Lifting1WorkPermitId",
      httpErrorHandler
    )
  }
  //ResendMail
  /** get one with key string */
  getResendMail(key: number): Observable<any> {
    // Add safe, URL encoded search parameter if there is a search term
    const options = { params: new HttpParams().set("key", key.toString()) };

    return this.http.get<any>(this.baseUrl + "ResendMail/", options)
      .pipe(catchError(this.handleError("Resend mail with key", {})));
  }

  getXlsx(key?:number): Observable<any> {
    let url: string = this.baseUrl + "GetReport/";

    return this.http.get(url, {
      params: new HttpParams().set("key", key.toString()),
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        'Accept': 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
      }),
      responseType: 'blob' // <-- changed to blob 
    }).map(res => this.downloadFile(res, 'application/xlsx', 'liftingWorkPermit.xlsx'));
  }
}
