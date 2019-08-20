import { Routes } from '@angular/router';
import { GuestComponent } from './layouts/guest/guest.component';

export const AppRoutes : Routes = [
    {
        path:'authentication',
        component: GuestComponent,
        loadChildren: './modules/authentication/authentication.module#AuthenticationModule'
        //component: GuestComponent,
        // children: [
        //     {
        //         path: 'authentication',
        //         component: AuthenticatedComponent,
        //         loadChildren: './modules/authentication/authentication.module#AuthenticationModule'
        //     }
        // ]
    },
    // {
    //     path: 'authentication',
    //     component: AuthenticatedComponent,
    //     children: [
    //         {
    //             path: '',
    //             component: LoginComponent,
    //             loadChildren: './modules/authentication/authentication.module#AuthenticationModule'
    //         }
    //     ]
    // }
    // {
    //     path: 'book-management',

    // }
]