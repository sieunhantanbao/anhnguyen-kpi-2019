import { Injectable } from '@angular/core';
import { Effect, Actions, ofType } from '@ngrx/effects';
import { Dispatcher } from '../modules/app/app.dispatcher';
import { AppActionNames, SaveTokenAction, TOKEN_NAME, AppSuccessAction } from './app.actions';
import { switchMap } from 'rxjs/operators';
import { of } from 'rxjs';

@Injectable()
export class AppEffect{
    constructor(
        private actions$: Actions,
        private dispatcher : Dispatcher
    ){}
    @Effect()
    saveToken$ = this.actions$.pipe(
        ofType(AppActionNames.SAVE_TOKEN),
        switchMap((action: SaveTokenAction) =>{
            const token: string = action.payload;
            localStorage.setItem(TOKEN_NAME, token);
            return of(new AppSuccessAction(AppActionNames.SAVE_TOKEN, null));
        })
    )
}