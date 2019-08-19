import { Routes } from '@angular/router';
import { GuestComponent } from './layouts/guest/guest.component';
import { AuthenticatedComponent } from './layouts/authenticated/authenticated.component';

export const AppRoutes : Routes = [
    {
        path:'',
        component: GuestComponent,
        children: [
            {
                path: 'authentication',
                component: AuthenticatedComponent,
                loadChildren: './modules/authentication/authentication.module#AuthenticationModule'
            }
        ]
    },
    // {
    //     path: 'book-management',

    // }
]