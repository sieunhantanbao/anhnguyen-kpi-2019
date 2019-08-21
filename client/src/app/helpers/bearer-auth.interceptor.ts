import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { AuthenticationService } from '../modules/shared/services/authentication.service';
import { Observable } from 'rxjs';

@Injectable()
export class BearerAuthInterceptor implements HttpInterceptor {
    constructor(private authService: AuthenticationService){}
    intercept(request: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>> {
        if(this.authService.isAuthenticated()){
            request = request.clone({
                setHeaders:{Authorization: 'Bearer ' + this.authService.getToken()}
            })
        }
        return next.handle(request);
    }
}