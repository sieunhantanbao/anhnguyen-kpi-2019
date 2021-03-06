import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ManagementSelectors } from '../../management/management.state/management.selectors';
import { Observable } from 'rxjs';
import { PagingRequestModel } from '../models/paging-request.model';
import { BookLendingRequestModel } from '../models/book-lending-request.model';
import { BookReturnRequestModel } from '../models/book-return-request.model';

@Injectable()
export class BookService extends BaseService {
    constructor(protected http: HttpClient,
        private router: Router) {
        super(http);
    }
    // Get list books from server
    public listBooks(pagingRequestModel: PagingRequestModel): Observable<any>{
        return this.get(`/books?pageIndex=${pagingRequestModel.pageIndex}&&pageSize=${pagingRequestModel.pageSize}`);
    }

    public bookDetail(slug: string): Observable<any>{
        return this.get(`/books/${slug}`);
    }

    public borrowABook(bookLendingRequest: BookLendingRequestModel): Observable<any>{
        return this.post<any>(`/booklending/book-lending`, bookLendingRequest);
    }

    public returnABook(bookReturningRequest: BookReturnRequestModel): Observable<any>{
        return this.put<any>(`/booklending/book-returning/${bookReturningRequest.id}`, bookReturningRequest);
    }

    public getBorrowedABooks(userId: string): Observable<any>{
        return this.get(`/booklending/${userId}/books`);
    }
}