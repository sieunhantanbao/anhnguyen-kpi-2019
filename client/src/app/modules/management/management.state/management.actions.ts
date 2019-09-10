import { Action } from '@ngrx/store';
import { PagingRequestModel } from '../../shared/models/paging-request.model';
import { BookLendingRequestModel } from '../../shared/models/book-lending-request.model';
import { BookReturnRequestModel } from '../../shared/models/book-return-request.model';

export enum ManagementActionNames {
    GET_LIST_BOOKS = '[Management] Get List Books',
    GET_BOOK_DETAIL = '[Management] Get Book Detail',
    LEND_A_BOOK ='[Management] Lend a book',
    RETURN_A_BOOK ='[Management] Return a book',
    GET_BORROWED_BOOKS ='[Management] Get borrowed books',
    GET_MY_PROFILE = '[Management] My profile',
    ACTION_SUCCESS = '[Management] Success',
    ACTION_FAILED = '[Management] Failed',
}
export interface AuthenticationAction extends Action {
    type: ManagementActionNames;
    payload?: any
}

export class GetListBookAction implements Action {
    type = ManagementActionNames.GET_LIST_BOOKS;
    constructor(public payload: PagingRequestModel){}
}

export class GetBookDetailAction implements Action {
    type = ManagementActionNames.GET_BOOK_DETAIL;
    constructor(public payload: string){}
}

export class LendABookAction implements Action {
    type = ManagementActionNames.LEND_A_BOOK;
    constructor(public payload: BookLendingRequestModel){}
}

export class ReturnABookAction implements Action {
    type = ManagementActionNames.RETURN_A_BOOK;
    constructor(public payload: BookReturnRequestModel){}
}

export class GetBorrowedBooksAction implements Action{
    type = ManagementActionNames.GET_BORROWED_BOOKS;
    constructor(public payload: string){}
}
export class GetMyProfileAction implements Action {
    type = ManagementActionNames.GET_MY_PROFILE;
    constructor(){}
}

export class ManagementSuccessAction implements Action {
    type = ManagementActionNames.ACTION_SUCCESS;
    constructor(public subType: ManagementActionNames, public payload: any) {}
  }
  export class ManagementFailedAction implements Action {
    type = ManagementActionNames.ACTION_FAILED;
    constructor(public subType: ManagementActionNames, public payload: any) {}
}