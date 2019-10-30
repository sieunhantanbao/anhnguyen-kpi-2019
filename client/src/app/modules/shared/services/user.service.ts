import { Injectable } from "@angular/core";
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class UserService extends BaseService{
    constructor(protected http: HttpClient){
        super(http);
    }

    public getMyProfile():Observable<any>{
        return this.get("/users/my-profile");
    }
}