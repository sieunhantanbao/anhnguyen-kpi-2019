import { IAppState } from './app.state';
import { AppAction, AppActionNames, AppSuccessAction, AppFailedAction } from './app.actions';

// Initial app state
export const initialAppState: IAppState = {
    token: '',
    userDetail: null
}

// App reducer
export function appModule(appState: IAppState = initialAppState, action: AppAction): IAppState {
    switch(action.type){
        case AppActionNames.SAVE_TOKEN:
            return {
                ...appState,
                token: action.payload as string
            };
        case AppActionNames.SAVE_USER_DETAIL:
            return {
                ...appState,
                userDetail: action.payload
            };
        case AppActionNames.LOG_OUT:
            return {
                ...appState,
                userDetail: null,
                token: ''
            };
        case AppActionNames.GO_TO_LOGIN_PAGE:
            return {
                ...appState,

            };
        case AppActionNames.SUCCESS_ACTION:
            return appSuccessReducer(appState, action as AppSuccessAction);
        case AppActionNames.FAILED_ACTION:
            return appFailedReducer(appState, action as AppFailedAction);
        default:
            return appState;
    }
}

function appSuccessReducer(appState: IAppState, action: AppSuccessAction){
    switch(action.subType){
        default:
            return appState;
    }
}

function appFailedReducer(appState: IAppState, action: AppFailedAction){
    switch(action.subType){
        default:
            return appState;
    }
}