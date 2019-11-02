import { Component, OnInit } from '@angular/core';
import { Dispatcher } from '../../app/app.dispatcher';
import { SafeUnsubscriber } from '../../shared/utility/safe-unsubscriber';
import { Subscription } from 'rxjs/internal/Subscription';
import { ManagementSelectors } from '../management.state/management.selectors';
import { ManagementActionNames, GetListBookAction, LendABookAction } from '../management.state/management.actions';
import { PagingRequestModel } from '../../shared/models/paging-request.model';
import { BookLendingRequestModel } from '../../shared/models/book-lending-request.model';
import { AuthenticationService } from '../../shared/services/authentication.service';

@Component({
  selector: 'app-bookmanagement',
  templateUrl: './bookmanagement.component.html',
  styleUrls: ['./bookmanagement.component.scss']
})
export class BookmanagementComponent extends SafeUnsubscriber implements OnInit {

  constructor(private dispatcher: Dispatcher,
      private authenticationService: AuthenticationService,
      private managementSelector: ManagementSelectors) { 
    super();
  }

  lstBooks: any;
  ngOnInit() {
    this.safeSubscriptions(this.registerSubscriptions());
     var requestModel = new PagingRequestModel(0,10);
     this.dispatcher.fire(new GetListBookAction(requestModel));
  }

  registerSubscriptions(): Subscription[] {
    return [
      this.managementSelector.actionSuccessOfSubtype$(ManagementActionNames.GET_LIST_BOOKS)
          .subscribe((res) => {
            this.lstBooks = res.payload;
          }),

      this.managementSelector.actionSuccessOfSubtype$(ManagementActionNames.LEND_A_BOOK)
          .subscribe((res) =>{
              let bookId = res.payload.bookId;
              let available2Lend = res.payload.available2Lend;
              this.lstBooks.data.forEach(function(book){
                  if(book.id==bookId){
                    book.available2Lend = available2Lend;
                    return;
                  }
              });
          })
    ];
  }

  lendABook(id){
    if(confirm('Are you sure you want to borrow this book?')){
      var requestModel = new BookLendingRequestModel();
      requestModel.bookId = id;
      requestModel.userId = this.authenticationService.getAuthenticatedUser().userId;
      this.dispatcher.fire(new LendABookAction(requestModel));
    }
  }
}
