import { Injectable } from '@angular/core';
import { Effect, Actions, ofType } from '@ngrx/effects';
import { ManagementActionNames, ManagementSuccessAction, ManagementFailedAction, GetListBookAction, GetMyProfileAction, GetBookDetailAction, LendABookAction } from './management.actions';
import 'rxjs/Rx';
import { Observable } from 'rxjs/Rx';
import { BookService } from '../../shared/services/book.service';
import { map, switchMap } from 'rxjs/operators';
import { UserService } from '../../shared/services/user.service';

@Injectable()
export class ManagementEffects {
    constructor (private actions$: Actions,
        private bookService: BookService,
        private userService: UserService){
        
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
     @Effect()
     bookDetail$ = this.actions$.pipe(
         ofType(ManagementActionNames.GET_BOOK_DETAIL),
         map((action: GetBookDetailAction) => action.payload),
         switchMap(payload => {
             return this.bookService.bookDetail(payload)
                        .map(res => {
                            return new ManagementSuccessAction(ManagementActionNames.GET_BOOK_DETAIL, res);
                        })
                        .catch(err =>
                            Observable.of(new ManagementFailedAction(ManagementActionNames.GET_BOOK_DETAIL, err))
                        )
         })
      )
    
    @Effect()
    lendingABook = this.actions$.pipe(
        ofType(ManagementActionNames.LEND_A_BOOK),
        map((action: LendABookAction)=> action.payload),
        switchMap(payload => {
            return this.bookService.borrowABook(payload)
                .map(res => {
                    return new ManagementSuccessAction(ManagementActionNames.LEND_A_BOOK, res);
                })
                .catch(err =>
                    Observable.of(new ManagementFailedAction(ManagementActionNames.LEND_A_BOOK, err))
                )
        })
    )
    @Effect()
    myProfile$ = this.actions$.pipe(
        ofType(ManagementActionNames.GET_MY_PROFILE),
        map((action: GetMyProfileAction) => action),
        switchMap(payload => {
            return this.userService.getMyProfile()
                       .map(res => {
                           return new ManagementSuccessAction(ManagementActionNames.GET_MY_PROFILE, res);
                       })
                       .catch(err =>
                           Observable.of(new ManagementFailedAction(ManagementActionNames.GET_MY_PROFILE, err))
                       )
        })
     )
}