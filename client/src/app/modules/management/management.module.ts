import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { AppSelectors } from 'src/app/app.state/app.selectors';
import { ManagementRoutes } from './management.routing';
import { ManagementEffects } from './management.state/management.effects';
import { NgModule } from '@angular/core';
import { managementModule } from './management.state/management.reducer';
import { ManagementSelectors } from './management.state/management.selectors';
import { BookmanagementComponent } from './bookmanagement/bookmanagement.component';
import { BookdetailComponent } from './bookmanagement/bookdetail/bookdetail.component';
import { UsermanagementComponent } from './usermanagement/usermanagement.component';
import { UserdetailComponent } from './usermanagement/userdetail/userdetail.component';
import { BookService } from '../shared/services/book.service';
import { MyprofileComponent } from './usermanagement/myprofile/myprofile.component';
import { UserService } from '../shared/services/user.service';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule(
    {
        imports: [
            CommonModule,
            FormsModule,
            ReactiveFormsModule,
            RouterModule.forChild(ManagementRoutes),
            StoreModule.forFeature('managementModule', managementModule),
            EffectsModule.forRoot([ManagementEffects])
        ],
        declarations: [
           // LoginComponent
        BookmanagementComponent,
           BookdetailComponent,
           UsermanagementComponent,
           UserdetailComponent,
           MyprofileComponent,
           DashboardComponent],
        providers: [
            AppSelectors,
            ManagementSelectors,
            BookService,
            UserService
        ],
        exports: [

        ]
    }
)
export class ManagementModule{

}