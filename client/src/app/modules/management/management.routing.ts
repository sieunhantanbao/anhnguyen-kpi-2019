import { Routes } from '@angular/router';
import { BookmanagementComponent } from './bookmanagement/bookmanagement.component';

export const ManagementRoutes: Routes = [
    {
        path:'',
        children: [
            {
                path: '',
                redirectTo: 'book-management',
                pathMatch: 'full'
            },
            {
                path: 'book-management',
                component: BookmanagementComponent
            }
        ]
    }
]