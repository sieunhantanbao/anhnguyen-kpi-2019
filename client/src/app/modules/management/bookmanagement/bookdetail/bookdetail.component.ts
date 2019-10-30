import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/modules/shared/services/book.service';
import { SafeUnsubscriber } from 'src/app/modules/shared/utility/safe-unsubscriber';
import { Subscription } from 'rxjs';
import { ManagementSelectors } from '../../management.state/management.selectors';
import { ManagementActionNames, GetBookDetailAction, LendABookAction } from '../../management.state/management.actions';
import { Dispatcher } from 'src/app/modules/app/app.dispatcher';
import { ActivatedRoute } from '@angular/router';
import { BookDetailModel } from 'src/app/modules/shared/models/book-detail.model';
import { BookLendingRequestModel } from 'src/app/modules/shared/models/book-lending-request.model';
import { AuthenticationService } from 'src/app/modules/shared/services/authentication.service';

@Component({
  selector: 'app-bookdetail',
  templateUrl: './bookdetail.component.html',
  styleUrls: ['./bookdetail.component.scss']
})
export class BookdetailComponent extends SafeUnsubscriber implements OnInit {

  constructor(private authenticationService: AuthenticationService,
    private managementSelector: ManagementSelectors,
    private dispatcher: Dispatcher,
    private activatedRoute: ActivatedRoute) { 
    super();
  }

  bookDetail: any;

  ngOnInit() {
    this.getBookDetail();
    this.safeSubscriptions(this.registerSubscriptions());
  }

  registerSubscriptions(): Subscription[]{
    return [
        this.managementSelector.actionSuccessOfSubtype$(ManagementActionNames.GET_BOOK_DETAIL)
          .subscribe((res)=>{
              this.bookDetail = res.payload;
          })
        ,
        this.managementSelector.actionSuccessOfSubtype$(ManagementActionNames.LEND_A_BOOK)
          .subscribe((res)=>{
            this.getBookDetail();
          })
    ]
  }
  getBookDetail(){
    let bookId = this.activatedRoute.snapshot.paramMap.get('id');
    this.dispatcher.fire(new GetBookDetailAction(bookId));
  }
  lendABook(){
    if(confirm('Are you sure you want to borrow this book?')){
      var requestModel = new BookLendingRequestModel();
      requestModel.bookId = this.bookDetail.id;
      requestModel.userId = this.authenticationService.getAuthenticatedUser().userId;
      this.dispatcher.fire(new LendABookAction(requestModel));
    }
  }
}
