import { Component, OnInit } from '@angular/core';
import { SafeUnsubscriber } from '../../shared/utility/safe-unsubscriber';
import { ManagementSelectors } from '../management.state/management.selectors';
import { Dispatcher } from '../../app/app.dispatcher';
import { Subscription } from 'rxjs';
import { ManagementActionNames, GetBorrowedBooksAction, ReturnABookAction } from '../management.state/management.actions';
import { AuthenticationService } from '../../shared/services/authentication.service';
import { BookReturnRequestModel } from '../../shared/models/book-return-request.model';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent extends SafeUnsubscriber implements OnInit {

  constructor(private managementSelector: ManagementSelectors,
    private dispatcher: Dispatcher,
    private authenticationService: AuthenticationService) { 
    super();
  }

  listBooks: any;
  userId: string;
  ngOnInit() {
    this.getBorrowedBooks();
    this.safeSubscriptions(this.registerSubscriptions());
  }

  registerSubscriptions(): Subscription[]{
    return [
      this.managementSelector.actionSuccessOfSubtype$(ManagementActionNames.GET_BORROWED_BOOKS)
        .subscribe(res =>{
            this.listBooks = res.payload;
        }),
      this.managementSelector.actionSuccessOfSubtype$(ManagementActionNames.RETURN_A_BOOK)
        .subscribe(res =>{
          this.getBorrowedBooks();
        })
    ];
  }
  getBorrowedBooks(){
    this.userId = this.authenticationService.getAuthenticatedUser().userId;
    this.dispatcher.fire(new GetBorrowedBooksAction(this.userId));
  }
  returnBook(bookLendingId:number, bookId:number){
    var request = new BookReturnRequestModel();
    request.id = bookLendingId;
    request.userId = this.userId;
    request.bookId = bookId;

    this.dispatcher.fire(new ReturnABookAction(request));
  }
}
