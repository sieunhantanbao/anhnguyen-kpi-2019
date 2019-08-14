import { IAuthenticationState } from './authentication.state';
import { Action } from '@ngrx/store';
import { AuthenticationActionNames, AuthenticationAction } from './authentication.actions';
  
// Initial state
export const initialAuthenticationState: IAuthenticationState = {};

// Reducer
export function authenticationModule (
    authenticationState: IAuthenticationState = initialAuthenticationState,
    action: AuthenticationAction
): IAuthenticationState {
    switch(action.type){
        default:
            return authenticationState
    }
}