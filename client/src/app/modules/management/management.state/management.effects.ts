import { Injectable } from '@angular/core';
import { Effect, Actions, ofType } from '@ngrx/effects';
import { ManagementActionNames, ManagementSuccessAction, ManagementFailedAction, GetListBookAction } from './management.actions';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';
import { BookService } from '../../shared/services/book.service';
import { map, switchMap } from 'rxjs/operators';

@Injectable()
export class ManagementEffects {
    constructor (private actions$: Actions,
        private bookService: BookService){
        
    }
    @Effect()
    lstBooks$ = this.actions$.pipe(
        ofType(ManagementActionNames.GET_LIST_BOOKS),
        map((action: GetListBookAction) => action.payload),
        switchMap(payload => {
            return this.bookService.listBooks(payload)
                       .map(res => {
                           return new ManagementSuccessAction(ManagementActionNames.GET_LIST_BOOKS, res);
                       })
                       .catch(err =>
                           Observable.of(new ManagementFailedAction(ManagementActionNames.GET_LIST_BOOKS, err))
                       )
        })
     )
}