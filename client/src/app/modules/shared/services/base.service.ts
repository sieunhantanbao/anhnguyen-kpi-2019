import { Injectable } from "@angular/core";
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class BaseService {
  protected baseUrl: string;

  constructor(protected http: HttpClient) {
    this.baseUrl = environment.baseUrl;
  }

  protected post<Type>(url: string, data: Type, options?: any) {
    return this.http.post(this.baseUrl + url, data, options)
      .catch(this.handleError);
  }
   protected get(url: string, options?: any): Observable<ArrayBuffer> {
     return this.http.get(this.baseUrl + url, options)
       .catch(this.handleError);
   }
  protected put<Type>(url: string, data: Type) {
    return this.http.put(this.baseUrl + url, data)
      .catch(this.handleError);
  }

  protected delete<Type>(url: string, data?: Type) {
    return this.http.delete(this.baseUrl + url, data)
      .catch(this.handleError);
  }

  protected handleError(error: HttpErrorResponse) {
    return Observable.throw(error);
  }
}
