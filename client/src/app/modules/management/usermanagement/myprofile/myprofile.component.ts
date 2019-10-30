import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/modules/shared/services/user.service';
import { SafeUnsubscriber } from 'src/app/modules/shared/utility/safe-unsubscriber';
import { Dispatcher } from 'src/app/modules/app/app.dispatcher';
import { GetMyProfileAction, ManagementActionNames } from '../../management.state/management.actions';
import { Subscription } from 'rxjs';
import { ManagementSelectors } from '../../management.state/management.selectors';
import { MyProfileModel } from 'src/app/modules/shared/models/my-profile.model';

@Component({
  selector: 'app-myprofile',
  templateUrl: './myprofile.component.html',
  styleUrls: ['./myprofile.component.scss']
})
export class MyprofileComponent extends SafeUnsubscriber implements OnInit {

  constructor(private userService: UserService,
      private dispatcher: Dispatcher,
      private managementSelector: ManagementSelectors) { 
    super();
  }

  public myProfile: MyProfileModel;
  ngOnInit() {
      this.dispatcher.fire(new GetMyProfileAction());
      this.safeSubscriptions(this.registerSubscriptions());
  }

  registerSubscriptions(): Subscription[]{
    return [
      this.managementSelector.actionSuccessOfSubtype$(ManagementActionNames.GET_MY_PROFILE)
        .subscribe((res)=>{
            this.myProfile = res.payload;
        })
    ]
  }
}
