import { Injectable } from "@angular/core";
import { BaseSelector } from '../modules/shared/models/base.selector';
import { Observable } from 'rxjs';
import { UserDetail } from '../modules/shared/models/user-detail.model';
import { Store } from '@ngrx/store';
import { Actions } from '@ngrx/effects';
import { AppActionNames } from './app.actions';

@Injectable()
export class AppSelectors extends BaseSelector{
    public token$ : Observable<string>;
    public userDetail$: Observable<UserDetail>;

    constructor(
        private store: Store<any>,
        private appActions: Actions 
    ){
        super(appActions, AppActionNames.SUCCESS_ACTION, AppActionNames.FAILED_ACTION);

        this.token$ = this.store.select(c=>c.app.token);
        this.userDetail$ = this.store.select(c=>c.app.userDetail);
    }
}