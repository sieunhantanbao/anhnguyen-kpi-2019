import {
  HttpClientModule, HTTP_INTERCEPTORS
} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { AppComponent } from './app.component';
import {StoreModule} from '@ngrx/store';
import { appModule } from './app.state/app.reducer';
import { AppSelectors } from './app.state/app.selectors';
import { EffectsModule } from '@ngrx/effects';
import { AppEffect } from './app.state/app.effects';
import { RouterModule, PreloadAllModules } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Dispatcher } from './modules/app/app.dispatcher';
import { AuthenticatedComponent } from './modules/app/layouts/authenticated/authenticated.component';
import { GuestComponent } from './modules/app/layouts/guest/guest.component';
import { TopNavBarComponent } from './modules/app/layouts/shared-components/top-nav-bar/top-nav-bar.component';
import { CopyRightComponent } from './modules/app/layouts/shared-components/copy-right/copy-right.component';
import { AuthenticationService } from './modules/shared/services/authentication.service';
import { AppRoutes } from './app.routing';
import { BearerAuthInterceptor } from './helpers/bearer-auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    AuthenticatedComponent,
    GuestComponent,
    TopNavBarComponent,
    CopyRightComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    RouterModule.forRoot(AppRoutes, {
      preloadingStrategy: PreloadAllModules}),
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    StoreModule.forRoot({
      app: appModule
    }),
    StoreDevtoolsModule.instrument(
      {
        maxAge: 10 //  Buffers the last 10 states
      }
    ),
    EffectsModule.forRoot([AppEffect])
  ],
  providers: [
    AppSelectors,
    Dispatcher,
    AuthenticationService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: BearerAuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
