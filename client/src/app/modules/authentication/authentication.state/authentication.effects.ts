import { Injectable } from "@angular/core";
import { Effect, Actions, ofType } from '@ngrx/effects';
import { AuthenticationActionNames, AuthenticationLoginAction, AuthenticationSuccessAction, AuthenticationFailedAction } from './authentication.actions';
import { map, switchMap } from 'rxjs/operators';
import { AuthenticationService } from '../../shared/services/authentication.service';
import { Dispatcher } from '../../app/app.dispatcher';
import { TOKEN_NAME } from 'src/app/app.state/app.actions';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';


@Injectable()
export class AuthenticationEffects {
    constructor (private actions$: Actions,
        private authenService: AuthenticationService,
        private dispatcher: Dispatcher){
        
    }
    @Effect()
    login$ = this.actions$.pipe(
        ofType(AuthenticationActionNames.LOGIN),
        map((action: AuthenticationLoginAction) => action.payload),
        switchMap(payload => {
            return this.authenService.generateToken(payload)
                       .map(res => {
                           localStorage.setItem(TOKEN_NAME, res.token);
                           return new AuthenticationSuccessAction(AuthenticationActionNames.LOGIN, res);
                       })
                       .catch(err =>
                           Observable.of(new AuthenticationFailedAction(AuthenticationActionNames.LOGIN, err))
                       )
        })
    )
}