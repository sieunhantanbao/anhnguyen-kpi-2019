import { Action } from '@ngrx/store';

export enum ManagementActionNames {
    ACTION_SUCCESS = '[Management] Success',
    ACTION_FAILED = '[Management] Failed',
}
export interface AuthenticationAction extends Action {
    type: ManagementActionNames;
    payload?: any
}


export class ManagementSuccessAction implements Action {
    type = ManagementActionNames.ACTION_SUCCESS;
    constructor(public subType: ManagementActionNames, public payload: any) {}
  }
  export class ManagementFailedAction implements Action {
    type = ManagementActionNames.ACTION_FAILED;
    constructor(public subType: ManagementActionNames, public payload: any) {}
}