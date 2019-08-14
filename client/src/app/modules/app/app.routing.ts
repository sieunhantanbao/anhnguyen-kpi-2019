import { Routes } from '@angular/router';

export const AppRoutes : Routes = [
    {
        path:'',
        children: [
            {
                path: 'authentication',
                loadChildren: './modules/authentication/authentication.module#AuthenticationModule'
            }
        ]
    },
    // {
    //     path: 'book-management',

    // }
]