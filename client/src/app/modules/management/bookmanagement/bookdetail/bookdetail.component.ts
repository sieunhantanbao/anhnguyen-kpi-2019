import { Component, OnInit } from '@angular/core';
import { BookService } from 'src/app/modules/shared/services/book.service';
import { SafeUnsubscriber } from 'src/app/modules/shared/utility/safe-unsubscriber';
import { Subscription } from 'rxjs';
import { ManagementSelectors } from '../../management.state/management.selectors';
import { ManagementActionNames, GetBookDetailAction } from '../../management.state/management.actions';
import { Dispatcher } from 'src/app/modules/app/app.dispatcher';
import { ActivatedRoute } from '@angular/router';
import { BookDetailModel } from 'src/app/modules/shared/models/book-detail.model';

@Component({
  selector: 'app-bookdetail',
  templateUrl: './bookdetail.component.html',
  styleUrls: ['./bookdetail.component.scss']
})
export class BookdetailComponent extends SafeUnsubscriber implements OnInit {

  constructor(private bookService: BookService,
    private managementSelector: ManagementSelectors,
    private dispatcher: Dispatcher,
    private activatedRoute: ActivatedRoute) { 
    super();
  }

  bookDetail: any;

  ngOnInit() {
    let bookId = this.activatedRoute.snapshot.paramMap.get('id');
    this.dispatcher.fire(new GetBookDetailAction(bookId));
    this.safeSubscriptions(this.registerSubscriptions());
  }

  registerSubscriptions(): Subscription[]{
    return [
        this.managementSelector.actionSuccessOfSubtype$(ManagementActionNames.GET_BOOK_DETAIL)
          .subscribe((res)=>{
              this.bookDetail = res.payload;
          })
    ]
  }
}
