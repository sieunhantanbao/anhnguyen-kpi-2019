import { Routes } from '@angular/router';
import { LoginComponent } from '../app/layouts/shared-components/login/login.component';

export const AuthenticationRoutes: Routes = [
    {
        path:'',
        children: [
            {
                path: '',
                redirectTo: 'login',
                pathMatch: 'full'
            },
            {
                path: 'login',
                component: LoginComponent
            }
        ]
    }
]