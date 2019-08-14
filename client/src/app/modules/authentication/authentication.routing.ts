import { Routes } from '@angular/router';

export const AuthenticationRoutes: Routes = [
    {
        path:'',
        children: [
            {
                path: 'test',
                redirectTo: '/login',
                pathMatch: 'full'
            }
        ]
    }
]