import { Action } from '@ngrx/store/src/models';

export enum AppActionNames{
    LOG_OUT = '[APP] - Log out',
    GO_TO_LOGIN_PAGE = '[APP] - Go to login page',
    SAVE_USER_DETAIL = '[APP] - Save user detail',
    SAVE_TOKEN = '[APP] - Save Token',
    SUCCESS_ACTION = '[APP] - Success Action',
    FAILED_ACTION = '[APP] - Failed Action'
}
export const TOKEN_NAME = 'bearer_token';
export const USER_PROP = 'user_prop';

export interface AppAction extends Action{
    type: AppActionNames,
    payload?: any
}

export class AppSuccessAction implements Action {
    type = AppActionNames.SUCCESS_ACTION;
    constructor(public subType: AppActionNames, public payload: any){ }
}
export class AppFailedAction implements Action {
    type = AppActionNames.FAILED_ACTION;
    constructor(public subType: AppActionNames, public payload: any) {}
}

export class GotoLoginPageAction implements Action {
    type: AppActionNames.GO_TO_LOGIN_PAGE;
    constructor(public payload: any = null) { }
}
export class LogOutAction implements Action{
    type: AppActionNames.LOG_OUT;
    constructor(){}
}
export class SaveTokenAction implements Action{
    type: AppActionNames.SAVE_TOKEN;
    constructor(public payload:string) { }
}
export class SaveUserDetailAction implements Action{
    type: AppActionNames.SAVE_USER_DETAIL;
    constructor(public payload: any){ }
}