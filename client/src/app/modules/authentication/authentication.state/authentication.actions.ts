import { Action } from '@ngrx/store/src/models';
import { LoginModel } from '../../shared/models/login.model';

export enum AuthenticationActionNames {
    LOGIN = '[Authentication] Login',
    GET_CLAIM = '[Authentication] Get claim',
    ACTION_SUCCESS = '[Authentication] Success',
    ACTION_FAILED = '[Authentication] Failed',
}
export interface AuthenticationAction extends Action {
    type: AuthenticationActionNames;
    payload?: any
}

export class AuthenticationLoginAction implements Action {
    type =  AuthenticationActionNames.LOGIN;
    constructor(public payload: LoginModel){}
}

export class AuthenticationSuccessAction implements Action {
    type = AuthenticationActionNames.ACTION_SUCCESS;
    constructor(public subType: AuthenticationActionNames, public payload: any) {}
  }
  export class AuthenticationFailedAction implements Action {
    type = AuthenticationActionNames.ACTION_FAILED;
    constructor(public subType: AuthenticationActionNames, public payload: any) {}
}