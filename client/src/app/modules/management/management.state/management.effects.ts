import { Injectable } from '@angular/core';
import { Effect, Actions, ofType } from '@ngrx/effects';
import { ManagementActionNames, ManagementSuccessAction, ManagementFailedAction } from './management.actions';
import { switchMap } from 'rxjs/operators';
import { AuthenticationService } from '../../shared/services/authentication.service';
import { Observable } from 'rxjs';

@Injectable()
export class ManagementEffects {
    constructor (private actions$: Actions,
        private authenService: AuthenticationService){
        
    }
    @Effect()
    login$ = this.actions$.pipe(
        ofType(ManagementActionNames.ACTION_SUCCESS),
        switchMap(payload => {
            return this.authenService.generateToken(payload)
                       .map(res => {
                           return new ManagementSuccessAction(ManagementActionNames.ACTION_SUCCESS, res);
                       })
                       .catch(err =>
                           Observable.of(new ManagementFailedAction(ManagementActionNames.ACTION_FAILED, err))
                       )
        })
     )
}