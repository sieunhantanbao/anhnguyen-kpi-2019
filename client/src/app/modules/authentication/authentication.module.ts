import { NgModule } from "@angular/core";
import { StoreModule } from '@ngrx/store';
import { authenticationModule } from './authentication.state/authentication.reducer';
import { AppSelectors } from 'src/app/app.state/app.selectors';
import { RouterModule } from '@angular/router';
import { AuthenticationRoutes } from './authentication.routing';
import { LoginComponent } from '../app/layouts/shared-components/login/login.component';
import { AuthenticationSelectors } from './authentication.state/authentication.selectors';
import { AuthenticatedComponent } from '../app/layouts/authenticated/authenticated.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthenticationEffects } from './authentication.state/authentication.effects';
import { EffectsModule } from '@ngrx/effects';

@NgModule(
    {
        imports: [
            CommonModule,
            FormsModule,
            ReactiveFormsModule,
            RouterModule.forChild(AuthenticationRoutes),
            StoreModule.forFeature('authenticationModule', authenticationModule),
            EffectsModule.forRoot([AuthenticationEffects])
        ],
        declarations: [
            LoginComponent
        ],
        providers: [
            AppSelectors,
            AuthenticationSelectors
        ],
        exports: [

        ]
    }
)
export class AuthenticationModule{

}