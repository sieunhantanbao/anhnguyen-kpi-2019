import { Action } from '@ngrx/store/src/models';

export enum AuthenticationActionNames {
    LOGIN = '[Authentication] Login',
    GET_CLAIM = '[Authentication] Get claim'
}

export interface AuthenticationAction extends Action {
    type: AuthenticationActionNames;
    payload?: any;
  }