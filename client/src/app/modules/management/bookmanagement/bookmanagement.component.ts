import { Component, OnInit } from '@angular/core';
import { Dispatcher } from '../../app/app.dispatcher';
import { SafeUnsubscriber } from '../../shared/utility/safe-unsubscriber';
import { Subscription } from 'rxjs/internal/Subscription';
import { ManagementSelectors } from '../management.state/management.selectors';
import { ManagementActionNames, GetListBookAction } from '../management.state/management.actions';
import { PagingRequestModel } from '../../shared/models/paging-request.model';

@Component({
  selector: 'app-bookmanagement',
  templateUrl: './bookmanagement.component.html',
  styleUrls: ['./bookmanagement.component.scss']
})
export class BookmanagementComponent extends SafeUnsubscriber implements OnInit {

  constructor(private dispatcher: Dispatcher,
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
          }) 
    ];
  }
}
