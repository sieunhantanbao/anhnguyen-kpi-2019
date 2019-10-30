import { AuthenticationAction } from '../../authentication/authentication.state/authentication.actions';
import { IManagementState } from './management.state';

 
// Initial state
export const initialManagementState: IManagementState = {};

// Reducer
export function managementModule (
    managementState: IManagementState = initialManagementState,
    action: AuthenticationAction
): IManagementState {
    switch(action.type){
        default:
            return managementState
    }
}