import { Routes, RouterModule } from '@angular/router';
import { GuestComponent } from './modules/app/layouts/guest/guest.component';

export const AppRoutes : Routes = [
  {
      path:'authentication',
      component: GuestComponent,
      loadChildren: './modules/authentication/authentication.module#AuthenticationModule'
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

// const routes: Routes = [];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
// export class AppRoutingModule { }
