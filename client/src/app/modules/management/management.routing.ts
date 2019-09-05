import { Routes } from '@angular/router';
import { BookmanagementComponent } from './bookmanagement/bookmanagement.component';
import { UsermanagementComponent } from './usermanagement/usermanagement.component';
import { UserdetailComponent } from './usermanagement/userdetail/userdetail.component';
import { MyprofileComponent } from './usermanagement/myprofile/myprofile.component';
import { BookdetailComponent } from './bookmanagement/bookdetail/bookdetail.component';

export const ManagementRoutes: Routes = [
    {
        path:'',
        children: [
            {
                path: '',
                redirectTo: 'my-profile',
                pathMatch: 'full'
            },
            {
                path: 'book-management',
                component: BookmanagementComponent
            },
            {
                path: 'book-detail/:id',
                component: BookdetailComponent
            },
            {
                path:'user-management',
                component: UsermanagementComponent,
            },
            {
                path:'user-detail',
                component: UserdetailComponent
            },
            {
                path:'my-profile',
                component: MyprofileComponent
            }
        ]
    }
]