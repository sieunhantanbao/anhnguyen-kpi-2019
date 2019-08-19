import { Injectable } from "@angular/core";
import { BaseSelector } from '../../shared/models/base.selector';
import { Observable } from 'rxjs';
import { AuthenticationSuccessAction, AuthenticationFailedAction, AuthenticationActionNames } from './authentication.actions';
import { Store } from '@ngrx/store';
import { Actions } from '@ngrx/effects';

@Injectable()
export class AuthenticationSelectors extends BaseSelector{
    public actionSuccess$: Observable<AuthenticationSuccessAction>;
    public actionFailed$ : Observable<AuthenticationFailedAction>;

    constructor(
        private store: Store<any>,
        private authenActions$: Actions
    ){
        super(authenActions$, AuthenticationActionNames.ACTION_SUCCESS, AuthenticationActionNames.ACTION_FAILED);
    }
}