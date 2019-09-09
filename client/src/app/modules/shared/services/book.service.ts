import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { ManagementSelectors } from '../../management/management.state/management.selectors';
import { Observable } from 'rxjs';
import { PagingRequestModel } from '../models/paging-request.model';
import { BookLendingRequestModel } from '../models/book-lending-request.model';

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

    public bookDetail(id: string): Observable<any>{
        return this.get(`/books/${id}`);
    }

    public borrowABook(bookLendingRequest: BookLendingRequestModel): Observable<any>{
        return this.post<any>(`/booklending/book-lending`,bookLendingRequest);
    }
}