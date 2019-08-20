import { Injectable } from "@angular/core";
import { JwtHelperService } from '@auth0/angular-jwt';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { AppSelectors } from 'src/app/app.state/app.selectors';
import { UserDetail } from '../models/user-detail.model';
import { TOKEN_NAME } from 'src/app/app.state/app.actions';
import { Observable } from 'rxjs';
import { LoginModel } from '../models/login.model';

@Injectable()
export class AuthenticationService extends BaseService {
    private jwtHelperService: JwtHelperService;
    private token: string = '';
    private userDetail: UserDetail;
    constructor(protected http: HttpClient,
        private router: Router,
        private appSelector: AppSelectors) {

        super(http);
        // Subscribe token from App Selector
        this.appSelector.token$.subscribe(t => { this.token = t });
        // Subscribe user detail from App Selector
        this.appSelector.userDetail$.subscribe(u => { this.userDetail = u });
        // New instance of jwt
        this.jwtHelperService = new JwtHelperService();
    }

    // Aquire token from Server 
    public generateToken(loginModel: LoginModel): Observable<any>{
        return this.post<any>('/authentication/generate-token', loginModel);
    }
    // Set token
    public setToken(token: string) {
        this.setTokenInLocalStorage(token);
    }

    // Get token
    public getToken(){
        this.token =  this.getTokenFromLocalStorage();
        if(!this.isValidToken(this.token)){
            this.clearToken();
        }
        return this.token;
    }

    // Clear token
    public clearToken(){
        this.setTokenInLocalStorage('');
    }

    public isAuthenticated(){
        return this.jwtHelperService.isTokenExpired(this.getToken());
    }

    private setTokenInLocalStorage(token: string) {
        localStorage.setItem(TOKEN_NAME, token);
    }

    private getTokenFromLocalStorage(){
        return localStorage.getItem(TOKEN_NAME);
    }

    private isValidToken(token: string){
        return !this.jwtHelperService.isTokenExpired(token);
    }
}