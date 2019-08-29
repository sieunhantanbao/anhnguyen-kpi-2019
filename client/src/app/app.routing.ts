import { Routes, RouterModule } from '@angular/router';
import { GuestComponent } from './modules/app/layouts/guest/guest.component';
import { AuthenticatedComponent } from './modules/app/layouts/authenticated/authenticated.component';

export const AppRoutes : Routes = [
  {
      path:'authentication',
      component: GuestComponent,
      loadChildren: './modules/authentication/authentication.module#AuthenticationModule'
  },
  {
    path: 'management',
    component: AuthenticatedComponent,
    loadChildren: './modules/management/management.module#ManagementModule'
  }
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

// const routes: Routes = [];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
// export class AppRoutingModule { }
